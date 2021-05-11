
namespace ePASS
{
    partial class MD_Company
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchKeywordBox = new System.Windows.Forms.TextBox();
            this.SearchCategory = new System.Windows.Forms.ComboBox();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.AddCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateOne = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifyCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.Modify = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.Employee = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.SearchPanel.Controls.Add(this.SearchButton);
            this.SearchPanel.Controls.Add(this.SearchKeywordBox);
            this.SearchPanel.Controls.Add(this.SearchCategory);
            this.SearchPanel.Location = new System.Drawing.Point(0, 27);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(799, 34);
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
            this.WholeSelect.TabIndex = 3;
            this.WholeSelect.Text = "Select All Company";
            this.WholeSelect.UseVisualStyleBackColor = false;
            this.WholeSelect.Click += new System.EventHandler(this.WholeSelect_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.White;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButton.Location = new System.Drawing.Point(330, 5);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(93, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchKeywordBox
            // 
            this.SearchKeywordBox.Location = new System.Drawing.Point(139, 5);
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
            "UEN",
            "TypeOfWork"});
            this.SearchCategory.Location = new System.Drawing.Point(12, 5);
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
            this.GridPanel.Location = new System.Drawing.Point(0, 61);
            this.GridPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(799, 538);
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
            this.dataGrid.Size = new System.Drawing.Size(799, 538);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.GhostWhite;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCompany,
            this.ModifyCompany,
            this.Employee});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(799, 24);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // AddCompany
            // 
            this.AddCompany.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateOne});
            this.AddCompany.Name = "AddCompany";
            this.AddCompany.Size = new System.Drawing.Size(57, 20);
            this.AddCompany.Text = "Add(&A)";
            // 
            // CreateOne
            // 
            this.CreateOne.Name = "CreateOne";
            this.CreateOne.Size = new System.Drawing.Size(180, 22);
            this.CreateOne.Text = "Create Company(&C)";
            // 
            // ModifyCompany
            // 
            this.ModifyCompany.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Modify,
            this.Delete});
            this.ModifyCompany.Name = "ModifyCompany";
            this.ModifyCompany.Size = new System.Drawing.Size(76, 20);
            this.ModifyCompany.Text = "Modify(&M)";
            // 
            // Modify
            // 
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(183, 22);
            this.Modify.Text = "Modify Company(&Y)";
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(183, 22);
            this.Delete.Text = "Delete Company(&D)";
            // 
            // Employee
            // 
            this.Employee.Name = "Employee";
            this.Employee.Size = new System.Drawing.Size(88, 20);
            this.Employee.Text = "Employee(&O)";
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(108, 22);
            this.Exit.Text = "Exit(&X)";
            // 
            // MD_Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 599);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.Menu);
            this.Controls.Add(this.SearchPanel);
            this.MainMenuStrip = this.Menu;
            this.Name = "MD_Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MD_Company_Load);
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
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox SearchKeywordBox;
        private System.Windows.Forms.ComboBox SearchCategory;
        private System.Windows.Forms.ToolStripMenuItem Home;
        private System.Windows.Forms.ToolStripMenuItem AddCompany;
        private System.Windows.Forms.ToolStripMenuItem CreateOne;
        private System.Windows.Forms.ToolStripMenuItem ModifyCompany;
        private System.Windows.Forms.ToolStripMenuItem Modify;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem Employee;
        private System.Windows.Forms.Button WholeSelect;
        private System.Windows.Forms.ToolStripMenuItem Exit;
    }
}