namespace SalesForceMetaDataExplorer
{
  partial class frmPackageCreator
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnConnectSF = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.cbSFObjectList = new System.Windows.Forms.ComboBox();
      this.panel3 = new System.Windows.Forms.Panel();
      this.listView2 = new System.Windows.Forms.ListView();
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.btnGenerateTableDDL = new System.Windows.Forms.Button();
      this.btnGeneratePackage = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.txtPackageDestConnString = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtConnectionProvider = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel4.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnConnectSF
      // 
      this.btnConnectSF.Location = new System.Drawing.Point(12, 12);
      this.btnConnectSF.Name = "btnConnectSF";
      this.btnConnectSF.Size = new System.Drawing.Size(118, 45);
      this.btnConnectSF.TabIndex = 0;
      this.btnConnectSF.Text = "Connect to SalesForce";
      this.btnConnectSF.UseVisualStyleBackColor = true;
      this.btnConnectSF.Click += new System.EventHandler(this.btnConnectSF_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.btnConnectSF);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(495, 61);
      this.panel1.TabIndex = 2;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtUsername);
      this.groupBox2.Controls.Add(this.label2);
      this.groupBox2.Controls.Add(this.txtPassword);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Location = new System.Drawing.Point(136, 13);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(356, 44);
      this.groupBox2.TabIndex = 6;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "SalesForce Credentials";
      // 
      // txtUsername
      // 
      this.txtUsername.Location = new System.Drawing.Point(73, 18);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(99, 20);
      this.txtUsername.TabIndex = 2;
      this.txtUsername.Text = "kdkdjf.sdkjf@mailinator.com";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 21);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(55, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Username";
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(241, 18);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(109, 20);
      this.txtPassword.TabIndex = 3;
      this.txtPassword.Text = "S@l3sf0rce!112QwfhCZjmAttJPyQZpS6waptJ7";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(181, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Password";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.cbSFObjectList);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 61);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(495, 42);
      this.panel2.TabIndex = 3;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 13);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(131, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "SalesForce Source Object";
      // 
      // cbSFObjectList
      // 
      this.cbSFObjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbSFObjectList.FormattingEnabled = true;
      this.cbSFObjectList.Location = new System.Drawing.Point(157, 10);
      this.cbSFObjectList.Name = "cbSFObjectList";
      this.cbSFObjectList.Size = new System.Drawing.Size(227, 21);
      this.cbSFObjectList.TabIndex = 2;
      this.cbSFObjectList.SelectionChangeCommitted += new System.EventHandler(this.cbSFObjectList_SelectionChangeCommitted);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.listView2);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 103);
      this.panel3.Name = "panel3";
      this.panel3.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
      this.panel3.Size = new System.Drawing.Size(495, 168);
      this.panel3.TabIndex = 4;
      // 
      // listView2
      // 
      this.listView2.CheckBoxes = true;
      this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
      this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView2.Location = new System.Drawing.Point(12, 0);
      this.listView2.Name = "listView2";
      this.listView2.Size = new System.Drawing.Size(471, 168);
      this.listView2.TabIndex = 0;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "Name";
      this.columnHeader2.Width = 96;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Label";
      this.columnHeader3.Width = 99;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Type";
      this.columnHeader4.Width = 107;
      // 
      // btnGenerateTableDDL
      // 
      this.btnGenerateTableDDL.Location = new System.Drawing.Point(356, 128);
      this.btnGenerateTableDDL.Name = "btnGenerateTableDDL";
      this.btnGenerateTableDDL.Size = new System.Drawing.Size(124, 23);
      this.btnGenerateTableDDL.TabIndex = 7;
      this.btnGenerateTableDDL.Text = "Generate Table DDL";
      this.btnGenerateTableDDL.UseVisualStyleBackColor = true;
      this.btnGenerateTableDDL.Click += new System.EventHandler(this.btnGenerateTableDDL_Click);
      // 
      // btnGeneratePackage
      // 
      this.btnGeneratePackage.Location = new System.Drawing.Point(233, 129);
      this.btnGeneratePackage.Name = "btnGeneratePackage";
      this.btnGeneratePackage.Size = new System.Drawing.Size(117, 23);
      this.btnGeneratePackage.TabIndex = 8;
      this.btnGeneratePackage.Text = "Generate Package";
      this.btnGeneratePackage.UseVisualStyleBackColor = true;
      this.btnGeneratePackage.Click += new System.EventHandler(this.btnGeneratePackage_Click);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(6, 20);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(179, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Staging Database Connection String";
      // 
      // txtPackageDestConnString
      // 
      this.txtPackageDestConnString.Location = new System.Drawing.Point(9, 39);
      this.txtPackageDestConnString.Name = "txtPackageDestConnString";
      this.txtPackageDestConnString.Size = new System.Drawing.Size(353, 20);
      this.txtPackageDestConnString.TabIndex = 11;
      this.txtPackageDestConnString.Text = "Data Source=(local);Initial Catalog=tempdb;Integrated Security=SSPI;";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.txtConnectionProvider);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.textBox1);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtPackageDestConnString);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Location = new System.Drawing.Point(3, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(477, 119);
      this.groupBox1.TabIndex = 12;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Package Configuration";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(369, 20);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(73, 13);
      this.label6.TabIndex = 16;
      this.label6.Text = "SSIS Provider";
      // 
      // txtConnectionProvider
      // 
      this.txtConnectionProvider.Location = new System.Drawing.Point(369, 39);
      this.txtConnectionProvider.Name = "txtConnectionProvider";
      this.txtConnectionProvider.Size = new System.Drawing.Size(100, 20);
      this.txtConnectionProvider.TabIndex = 15;
      this.txtConnectionProvider.Text = "Provider=SQLOLEDB.1;";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(394, 80);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 14;
      this.button1.Text = "Browse";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(12, 83);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(376, 20);
      this.textBox1.TabIndex = 13;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(9, 66);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(106, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Package Destination";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.Filter = "SSIS Packages|*.dtsx";
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.groupBox1);
      this.panel4.Controls.Add(this.btnGenerateTableDDL);
      this.panel4.Controls.Add(this.btnGeneratePackage);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel4.Location = new System.Drawing.Point(0, 271);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(495, 160);
      this.panel4.TabIndex = 13;
      // 
      // frmPackageCreator
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(495, 431);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel4);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Name = "frmPackageCreator";
      this.Text = "SalesForce Staging Package Creator";
      this.panel1.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnConnectSF;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.ListView listView2;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.Button btnGenerateTableDDL;
    private System.Windows.Forms.Button btnGeneratePackage;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.ComboBox cbSFObjectList;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtPackageDestConnString;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtConnectionProvider;
    private System.Windows.Forms.Panel panel4;
  }
}

