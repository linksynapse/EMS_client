
namespace ePASS
{
    partial class MD_Employee
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
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.WholeSelect = new System.Windows.Forms.Button();
            this.lbTxtTotalCount = new System.Windows.Forms.Label();
            this.lbTotalCount = new System.Windows.Forms.Label();
            this.CompanyList = new System.Windows.Forms.CheckedListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchKeywordBox = new System.Windows.Forms.TextBox();
            this.SearchCategory = new System.Windows.Forms.ComboBox();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.AddEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.BulkImgUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateOne = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.Print = new System.Windows.Forms.ToolStripMenuItem();
            this.Export = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchPanel.SuspendLayout();
            this.GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchPanel
            // 
            this.SearchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.SearchPanel.Controls.Add(this.WholeSelect);
            this.SearchPanel.Controls.Add(this.lbTxtTotalCount);
            this.SearchPanel.Controls.Add(this.lbTotalCount);
            this.SearchPanel.Controls.Add(this.CompanyList);
            this.SearchPanel.Controls.Add(this.SearchButton);
            this.SearchPanel.Controls.Add(this.SearchKeywordBox);
            this.SearchPanel.Controls.Add(this.SearchCategory);
            this.SearchPanel.Location = new System.Drawing.Point(0, 27);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(799, 88);
            this.SearchPanel.TabIndex = 0;
            // 
            // WholeSelect
            // 
            this.WholeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WholeSelect.BackColor = System.Drawing.Color.White;
            this.WholeSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WholeSelect.Location = new System.Drawing.Point(665, 5);
            this.WholeSelect.Name = "WholeSelect";
            this.WholeSelect.Size = new System.Drawing.Size(122, 23);
            this.WholeSelect.TabIndex = 7;
            this.WholeSelect.Text = "Select All Employee";
            this.WholeSelect.UseVisualStyleBackColor = false;
            this.WholeSelect.Click += new System.EventHandler(this.WholeSelect_Click);
            // 
            // lbTxtTotalCount
            // 
            this.lbTxtTotalCount.AutoSize = true;
            this.lbTxtTotalCount.Location = new System.Drawing.Point(261, 31);
            this.lbTxtTotalCount.Name = "lbTxtTotalCount";
            this.lbTxtTotalCount.Size = new System.Drawing.Size(14, 15);
            this.lbTxtTotalCount.TabIndex = 6;
            this.lbTxtTotalCount.Text = "0";
            // 
            // lbTotalCount
            // 
            this.lbTotalCount.AutoSize = true;
            this.lbTotalCount.Location = new System.Drawing.Point(185, 31);
            this.lbTotalCount.Name = "lbTotalCount";
            this.lbTotalCount.Size = new System.Drawing.Size(70, 15);
            this.lbTotalCount.TabIndex = 4;
            this.lbTotalCount.Text = "Total Count";
            // 
            // CompanyList
            // 
            this.CompanyList.FormattingEnabled = true;
            this.CompanyList.Location = new System.Drawing.Point(12, 5);
            this.CompanyList.Name = "CompanyList";
            this.CompanyList.Size = new System.Drawing.Size(167, 76);
            this.CompanyList.TabIndex = 3;
            this.CompanyList.SelectedIndexChanged += new System.EventHandler(this.CompanyList_SelectedIndexChanged);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.White;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButton.Location = new System.Drawing.Point(503, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(93, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchKeywordBox
            // 
            this.SearchKeywordBox.Location = new System.Drawing.Point(312, 5);
            this.SearchKeywordBox.Name = "SearchKeywordBox";
            this.SearchKeywordBox.Size = new System.Drawing.Size(185, 23);
            this.SearchKeywordBox.TabIndex = 1;
            // 
            // SearchCategory
            // 
            this.SearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchCategory.FormattingEnabled = true;
            this.SearchCategory.Items.AddRange(new object[] {
            "Name",
            "NRIC"});
            this.SearchCategory.Location = new System.Drawing.Point(185, 5);
            this.SearchCategory.Name = "SearchCategory";
            this.SearchCategory.Size = new System.Drawing.Size(121, 23);
            this.SearchCategory.TabIndex = 0;
            // 
            // GridPanel
            // 
            this.GridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPanel.Controls.Add(this.dataGrid);
            this.GridPanel.Location = new System.Drawing.Point(0, 115);
            this.GridPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(799, 484);
            this.GridPanel.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 25;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(799, 484);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            this.dataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.GhostWhite;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEmployee,
            this.ModifyEmployee,
            this.DeleteEmployee,
            this.Print,
            this.Export});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(799, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // AddEmployee
            // 
            this.AddEmployee.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportExcel,
            this.BulkImgUpload,
            this.CreateOne});
            this.AddEmployee.Name = "AddEmployee";
            this.AddEmployee.Size = new System.Drawing.Size(57, 20);
            this.AddEmployee.Text = "Add(&A)";
            // 
            // ImportExcel
            // 
            this.ImportExcel.Name = "ImportExcel";
            this.ImportExcel.Size = new System.Drawing.Size(184, 22);
            this.ImportExcel.Text = "Import From Excel(&I)";
            // 
            // BulkImgUpload
            // 
            this.BulkImgUpload.Name = "BulkImgUpload";
            this.BulkImgUpload.ShortcutKeyDisplayString = "";
            this.BulkImgUpload.Size = new System.Drawing.Size(184, 22);
            this.BulkImgUpload.Text = "Image Upload(&U)";
            // 
            // CreateOne
            // 
            this.CreateOne.Name = "CreateOne";
            this.CreateOne.Size = new System.Drawing.Size(184, 22);
            this.CreateOne.Text = "Create Employee(&C)";
            // 
            // ModifyEmployee
            // 
            this.ModifyEmployee.Name = "ModifyEmployee";
            this.ModifyEmployee.Size = new System.Drawing.Size(76, 20);
            this.ModifyEmployee.Text = "Modify(&M)";
            // 
            // DeleteEmployee
            // 
            this.DeleteEmployee.Name = "DeleteEmployee";
            this.DeleteEmployee.Size = new System.Drawing.Size(70, 20);
            this.DeleteEmployee.Text = "Delete(&D)";
            // 
            // Print
            // 
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(92, 20);
            this.Print.Text = "ePass Print(&P)";
            // 
            // Export
            // 
            this.Export.Name = "Export";
            this.Export.Size = new System.Drawing.Size(68, 20);
            this.Export.Text = "Export(&X)";
            // 
            // MD_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 599);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.SearchPanel);
            this.MainMenuStrip = this.Menu;
            this.Name = "MD_Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SDK ePass";
            this.Shown += new System.EventHandler(this.MD_Employee_Shown);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.GridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchKeywordBox;
        private System.Windows.Forms.ComboBox SearchCategory;
        private System.Windows.Forms.ToolStripMenuItem Home;
        private System.Windows.Forms.ToolStripMenuItem AddCompany;
        private System.Windows.Forms.ToolStripMenuItem ImportExcel;
        private System.Windows.Forms.ToolStripMenuItem CreateOne;
        private System.Windows.Forms.ToolStripMenuItem DeleteEmployee;
        private System.Windows.Forms.ToolStripMenuItem AddEmployee;
        private System.Windows.Forms.ToolStripMenuItem Print;
        private System.Windows.Forms.Label lbTxtTotalCount;
        private System.Windows.Forms.Label lbTotalCount;
        private System.Windows.Forms.CheckedListBox CompanyList;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button WholeSelect;
        private System.Windows.Forms.ToolStripMenuItem BulkImgUpload;
        private System.Windows.Forms.ToolStripMenuItem ModifyEmployee;
        private System.Windows.Forms.ToolStripMenuItem Export;
    }
}