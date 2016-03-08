using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesForceMetaDataExplorer
{
  public partial class frmPackageCreator : Form
  {
    public frmPackageCreator()
    {
      InitializeComponent();
    }

    private SFPartnerAPI.SforceService sfPartnerAPI = new SFPartnerAPI.SforceService();
    private string tableName;
    private string query;


    private void btnConnectSF_Click(object sender, EventArgs e)
    {
      

      sfPartnerAPI.Url = "https://login.salesforce.com/services/Soap/u/21.0";
      SFPartnerAPI.LoginResult loginResult = sfPartnerAPI.login(txtUsername.Text, txtPassword.Text);

      sfPartnerAPI.SessionHeaderValue = new SFPartnerAPI.SessionHeader();
      sfPartnerAPI.SessionHeaderValue.sessionId = loginResult.sessionId;

      sfPartnerAPI.Url = loginResult.serverUrl;

      var allObjects = sfPartnerAPI.describeGlobal();

      cbSFObjectList.Items.Clear();
      
      foreach (var item in allObjects.sobjects)
      {
        cbSFObjectList.Items.Add(string.Format("{0} ({1})", item.label, item.name));
      }
    }

    //private void button2_Click(object sender, EventArgs e)
    //{
    //  if (listView2.CheckedItems.Count == 0)
    //  {
    //    return;
    //  }

    //  listView3.Items.Clear();
    //  listView3.Columns.Clear();

    //  List<string> cols = new List<string>();

    //  foreach (var item in listView2.CheckedItems)
    //  {
    //    var name = ((ListViewItem)item).Text;
    //    listView3.Columns.Add(name);

    //    cols.Add(name);

    //  }

    //  string queryCols = string.Join(",", cols);

    //  sfPartnerAPI.QueryOptionsValue = new SFPartnerAPI.QueryOptions();
    //  sfPartnerAPI.QueryOptionsValue.batchSize = 10;
    //  sfPartnerAPI.QueryOptionsValue.batchSizeSpecified = true;

    //  this.query = string.Format("select {0} from {1}", queryCols, tableName);

    //  var queryResult = sfPartnerAPI.query(this.query);



    //  foreach (var record in queryResult.records)
    //  {
    //    var elm = record.Any;

    //    ListViewItem lvItem = new ListViewItem(elm[0].InnerText);

    //    for (int i = 1; i < elm.Length; i++)
    //    {
    //      lvItem.SubItems.Add(elm[i].InnerText);
    //    }

    //    listView3.Items.Add(lvItem);
    //  }

    //}

    private void btnGenerateTableDDL_Click(object sender, EventArgs e)
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(string.Format("IF OBJECT_ID('staging.{0}', 'U') IS NOT NULL{1}\tDROP TABLE staging.{0}{1}{1}", tableName, Environment.NewLine));
      sb.Append(string.Format("CREATE TABLE staging.{0}{1}", tableName, Environment.NewLine));
      sb.Append(string.Format("({0}", Environment.NewLine));

      List<string> cols = new List<string>();

      foreach (ListViewItem item in listView2.CheckedItems)
      {
        SFPartnerAPI.Field fieldInfo = (SFPartnerAPI.Field)item.Tag;

        string columnType = ConvertFieldTypeToColumnType(fieldInfo);

        //string columnName = fieldInfo.label.Replace(' ', '_').ToLower();
        string columnName = fieldInfo.name;

        cols.Add(string.Format("\t{0} {1} {2}", columnName, columnType, (fieldInfo.nillable) ? "NULL" : "NOT NULL"));
      }

      sb.Append(string.Join("," + Environment.NewLine, cols));

      sb.Append(Environment.NewLine);
      sb.Append(")");

      var result = MessageBox.Show(sb.ToString() + Environment.NewLine + "Create Table?", "Table DDL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

      if (result == System.Windows.Forms.DialogResult.Yes)
      {
        using (SqlConnection conn = new SqlConnection(txtPackageDestConnString.Text))
        {
          using (var cmd = new SqlCommand(sb.ToString(), conn))
          {
            conn.Open();
            var res = cmd.ExecuteNonQuery();
            conn.Close();
          }
        }
      }
    }

    private string ConvertFieldTypeToColumnType(SFPartnerAPI.Field fieldType)
    {
      if (fieldType.type == SFPartnerAPI.fieldType.@string)
      {
        return string.Format("nvarchar({0})", fieldType.length);
      }
      else if (fieldType.type == SFPartnerAPI.fieldType.id)
      {
        return "nvarchar(18)";
      }
      else if (fieldType.type == SFPartnerAPI.fieldType.picklist)
      {
        return "nvarchar(255)";
      }
      else if (fieldType.type == SFPartnerAPI.fieldType.date)
      {
        return "smalldatetime";
      }
      else if (fieldType.type == SFPartnerAPI.fieldType.boolean)
      {
        return "bit";
      }
      else if (fieldType.type == SFPartnerAPI.fieldType.currency || fieldType.type == SFPartnerAPI.fieldType.@double)
      {
        return string.Format("decimal({0},{1})", fieldType.precision, fieldType.scale);
      }

      return fieldType.type.ToString();
    }

    private void btnGeneratePackage_Click(object sender, EventArgs e)
    {
      SalesForceConnectionSettings sfConn = new SalesForceConnectionSettings();
      sfConn.Username = txtUsername.Text;
      sfConn.PasswordWithToken = txtPassword.Text;

      List<string> cols = new List<string>();

      foreach (var item in listView2.CheckedItems)
      {
        var name = ((ListViewItem)item).Text;
        cols.Add(name);
      }

      string queryCols = string.Join(",", cols);
      this.query = string.Format("select {0} from {1}", queryCols, tableName);

      string connectionString = string.Concat(txtPackageDestConnString.Text, txtConnectionProvider.Text);

      PackageBuilder builder = new PackageBuilder();
      builder.BuildPackage(tableName, this.query, connectionString, sfConn, textBox1.Text);
      MessageBox.Show("Complete", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void cbSFObjectList_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(cbSFObjectList.SelectedItem.ToString()))
      {
        listView2.Items.Clear();

        string selectedObject = cbSFObjectList.SelectedItem.ToString();
        this.tableName = selectedObject;

        var objectMetaData = sfPartnerAPI.describeSObject(selectedObject);

        foreach (var item in objectMetaData.fields)
        {
          var lvItem = new ListViewItem(item.name);
          lvItem.SubItems.Add(item.label);
          lvItem.SubItems.Add(item.type.ToString());

          lvItem.Tag = item;

          listView2.Items.Add(lvItem);
        }
      }

    }

    private void button1_Click(object sender, EventArgs e)
    {
      if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        textBox1.Text = saveFileDialog1.FileName;
      }
    }
  }
}
