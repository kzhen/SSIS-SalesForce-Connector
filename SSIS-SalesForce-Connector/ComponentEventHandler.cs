using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Dts.Runtime;

namespace SalesForceMetaDataExplorer
{
  public class ComponentEventHandler : IDTSComponentEvents
  {

    public void FireBreakpointHit(BreakpointTarget breakpointTarget)
    {
      throw new NotImplementedException();
    }

    public void FireCustomEvent(string eventName, string eventText, ref object[] arguments, string subComponent, ref bool fireAgain)
    {
      Console.WriteLine("[Custom Event] {0}: {1}", eventName, eventText);
    }

    public bool FireError(int errorCode, string subComponent, string description, string helpFile, int helpContext)
    {
      MessageBox.Show(string.Format("[Error] {0}: {1}", subComponent, description), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
      return true;
    }

    public void FireInformation(int informationCode, string subComponent, string description, string helpFile, int helpContext, ref bool fireAgain)
    {
      throw new NotImplementedException();
    }

    public void FireProgress(string progressDescription, int percentComplete, int progressCountLow, int progressCountHigh, string subComponent, ref bool fireAgain)
    {
      throw new NotImplementedException();
    }

    public bool FireQueryCancel()
    {
      throw new NotImplementedException();
    }

    public void FireWarning(int warningCode, string subComponent, string description, string helpFile, int helpContext)
    {
      throw new NotImplementedException();
    }
  }
}
