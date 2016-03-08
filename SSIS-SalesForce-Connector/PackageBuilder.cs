using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime;

namespace SalesForceMetaDataExplorer
{
  public class PackageBuilder
  {
    internal void BuildPackage(string tableName, string query, string destConnectionString, 
      SalesForceConnectionSettings sfConnSettings, string fileNameAndPath)
    {
      try
      {
        Package package = new Package();
        Microsoft.SqlServer.Dts.Runtime.Application app = new Microsoft.SqlServer.Dts.Runtime.Application();

        var src = package.Connections.Add("SALESFORCE");
        src.Name = "TF SalesForce";
        var sf = src.InnerObject as PW.TaskFactory.SalesForceConnectionManager.SalesForceConnectionManager;
        sf.Username = sfConnSettings.Username;
        sf.Password = sfConnSettings.PasswordWithToken;

        var dest = package.Connections.Add("OLEDB");
        dest.Name = "STG";
        dest.ConnectionString = destConnectionString;

        Executable truncateTable = package.Executables.Add("STOCK:SQLTask");
        TaskHost tskHost1 = truncateTable as TaskHost;
        tskHost1.Name = "Truncate STG";

        var sqlTask = tskHost1.InnerObject as Microsoft.SqlServer.Dts.Tasks.ExecuteSQLTask.ExecuteSQLTask;
        sqlTask.Connection = package.Connections[0].ID;
        sqlTask.SqlStatementSourceType = Microsoft.SqlServer.Dts.Tasks.ExecuteSQLTask.SqlStatementSourceType.DirectInput;
        sqlTask.IsStoredProcedure = false;
        sqlTask.SqlStatementSource = "TRUNCATE TABLE staging." + tableName;

        Executable loadStaging = package.Executables.Add("STOCK:PipelineTask");
        TaskHost tskHost2 = loadStaging as TaskHost;
        tskHost2.Name = "Load Staging";

        MainPipe dataFlowTask = (MainPipe)tskHost2.InnerObject;

        ComponentEventHandler events = new ComponentEventHandler();
        dataFlowTask.Events = DtsConvert.GetExtendedInterface(events as IDTSComponentEvents);

        IDTSComponentMetaData100 component1 = dataFlowTask.ComponentMetaDataCollection.New();
        component1.Name = "SalesForce - " + tableName;
        component1.ComponentClassID = app.PipelineComponentInfos["TF SalesForce Source"].CreationName;
        component1.ValidateExternalMetadata = true;

        IDTSDesigntimeComponent100 component1DesignTime = component1.Instantiate();
        component1DesignTime.ProvideComponentProperties();
        component1DesignTime.SetComponentProperty("SalesForceConnectionManager", string.Empty);
        component1DesignTime.SetComponentProperty("BatchSize", 500);
        component1DesignTime.SetComponentProperty("SalesForceObjectName", tableName);
        component1DesignTime.SetComponentProperty("UseQuery", true);
        component1DesignTime.SetComponentProperty("IncludeDeleted", false);


        component1DesignTime.SetComponentProperty("QueryStatement", query);

        CManagedComponentWrapper component1Wrapper = component1.Instantiate();

        component1.RuntimeConnectionCollection[0].ConnectionManager =
          DtsConvert.GetExtendedInterface(package.Connections[1]);
        component1.RuntimeConnectionCollection[0].ConnectionManagerID =
          package.Connections[1].ID;


        component1DesignTime.AcquireConnections(null);
        component1DesignTime.ReinitializeMetaData();
        component1DesignTime.ReleaseConnections();


        IDTSComponentMetaData100 destComponent = dataFlowTask.ComponentMetaDataCollection.New();
        destComponent.Name = "STG - " + tableName;
        destComponent.ComponentClassID = "DTSAdapter.OleDbDestination";
        destComponent.ValidateExternalMetadata = true;

        IDTSDesigntimeComponent100 destDesignTimeComponent = destComponent.Instantiate();
        destDesignTimeComponent.ProvideComponentProperties();
        destComponent.Name = "OleDb Destination";

        destDesignTimeComponent.SetComponentProperty("AccessMode", 3);
        destDesignTimeComponent.SetComponentProperty("OpenRowset", "[staging].[" + tableName + "]");

        CManagedComponentWrapper component2Wrapper = destComponent.Instantiate();

        destComponent.RuntimeConnectionCollection[0].ConnectionManager =
          DtsConvert.GetExtendedInterface(package.Connections[0]);
        destComponent.RuntimeConnectionCollection[0].ConnectionManagerID =
          package.Connections[0].ID;

        destDesignTimeComponent.AcquireConnections(null);
        destDesignTimeComponent.ReinitializeMetaData();
        destDesignTimeComponent.ReleaseConnections();

        IDTSPath100 path = dataFlowTask.PathCollection.New();
        path.AttachPathAndPropagateNotifications(component1.OutputCollection[0], destComponent.InputCollection[0]);




        IDTSInput100 destInput = destComponent.InputCollection[0];
        IDTSVirtualInput100 destVirInput = destInput.GetVirtualInput();
        IDTSInputColumnCollection100 destInputCols = destInput.InputColumnCollection;
        IDTSExternalMetadataColumnCollection100 destExtCols = destInput.ExternalMetadataColumnCollection;
        IDTSOutputColumnCollection100 sourceColumns = component1.OutputCollection[0].OutputColumnCollection;

        // The OLEDB destination requires you to hook up the external columns
        foreach (IDTSOutputColumn100 outputCol in sourceColumns)
        {
          // Get the external column id
          IDTSExternalMetadataColumn100 extCol = (IDTSExternalMetadataColumn100)destExtCols[outputCol.Name];
          if (extCol != null)
          {
            // Create an input column from an output col of previous component.
            destVirInput.SetUsageType(outputCol.ID, DTSUsageType.UT_READONLY);
            IDTSInputColumn100 inputCol = destInputCols.GetInputColumnByLineageID(outputCol.ID);
            if (inputCol != null)
            {
              // map the input column with an external metadata column
              destDesignTimeComponent.MapInputColumn(destInput.ID, inputCol.ID, extCol.ID);
            }
          }
        }

        PrecedenceConstraint pc = package.PrecedenceConstraints.Add(truncateTable, loadStaging);
        pc.Value = DTSExecResult.Success;

        package.Name = string.Format("{0} Loader", tableName);

        app.SaveToXml(fileNameAndPath, package, null);

        Debug.WriteLine("Success.");

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Debug.WriteLine(ex.Message);
      }
    }
  }
}
