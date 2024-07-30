namespace FireWork
{
    partial class CompanyForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddStament = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnTwin = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatementNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatementEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnPrint1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.grd2Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceContentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnServiceStickers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grd2EditColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddService = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateCompany = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Име";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(687, 22);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Протоколи";
            // 
            // btnAddStament
            // 
            this.btnAddStament.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddStament.Location = new System.Drawing.Point(3, 716);
            this.btnAddStament.Name = "btnAddStament";
            this.btnAddStament.Size = new System.Drawing.Size(139, 34);
            this.btnAddStament.TabIndex = 4;
            this.btnAddStament.Text = "Добави";
            this.btnAddStament.UseVisualStyleBackColor = true;
            this.btnAddStament.Click += new System.EventHandler(this.btnAddStatement_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(16, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnTwin);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddStament);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddService);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(1612, 753);
            this.splitContainer1.SplitterDistance = 404;
            this.splitContainer1.TabIndex = 5;
            // 
            // btnTwin
            // 
            this.btnTwin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwin.Enabled = false;
            this.btnTwin.Location = new System.Drawing.Point(262, 716);
            this.btnTwin.Name = "btnTwin";
            this.btnTwin.Size = new System.Drawing.Size(139, 34);
            this.btnTwin.TabIndex = 6;
            this.btnTwin.Text = "Дублирай";
            this.btnTwin.UseVisualStyleBackColor = true;
            this.btnTwin.Click += new System.EventHandler(this.btnTwin_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.columnStatementNo,
            this.columnStatementDate,
            this.columnStatementEdit});
            this.dataGridView1.Location = new System.Drawing.Point(3, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(398, 669);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // columnStatementNo
            // 
            this.columnStatementNo.DataPropertyName = "No";
            this.columnStatementNo.Frozen = true;
            this.columnStatementNo.HeaderText = "Номер";
            this.columnStatementNo.MinimumWidth = 6;
            this.columnStatementNo.Name = "columnStatementNo";
            this.columnStatementNo.ReadOnly = true;
            this.columnStatementNo.Width = 70;
            // 
            // columnStatementDate
            // 
            this.columnStatementDate.DataPropertyName = "Date";
            this.columnStatementDate.Frozen = true;
            this.columnStatementDate.HeaderText = "Дата";
            this.columnStatementDate.MinimumWidth = 6;
            this.columnStatementDate.Name = "columnStatementDate";
            this.columnStatementDate.ReadOnly = true;
            this.columnStatementDate.Width = 125;
            // 
            // columnStatementEdit
            // 
            this.columnStatementEdit.Frozen = true;
            this.columnStatementEdit.HeaderText = "";
            this.columnStatementEdit.MinimumWidth = 6;
            this.columnStatementEdit.Name = "columnStatementEdit";
            this.columnStatementEdit.ReadOnly = true;
            this.columnStatementEdit.Text = "->";
            this.columnStatementEdit.UseColumnTextForButtonValue = true;
            this.columnStatementEdit.Width = 50;
            // 
            // btnPrint1
            // 
            this.btnPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint1.Location = new System.Drawing.Point(1058, 716);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(139, 34);
            this.btnPrint1.TabIndex = 7;
            this.btnPrint1.Text = "Печат";
            this.btnPrint1.UseVisualStyleBackColor = true;
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grd2Id,
            this.columnServiceName,
            this.columnServiceCategory,
            this.columnServiceWeight,
            this.columnServiceContent,
            this.columnServiceContentName,
            this.columnServiceType,
            this.columnServiceStickers,
            this.delete,
            this.grd2EditColumn});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView2.Location = new System.Drawing.Point(-1, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1198, 669);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // grd2Id
            // 
            this.grd2Id.DataPropertyName = "Id";
            this.grd2Id.HeaderText = "Id";
            this.grd2Id.MinimumWidth = 6;
            this.grd2Id.Name = "grd2Id";
            this.grd2Id.Visible = false;
            this.grd2Id.Width = 125;
            // 
            // columnServiceName
            // 
            this.columnServiceName.DataPropertyName = "Name";
            this.columnServiceName.HeaderText = "Идентификационна маркировка на всеки пожарогасител (марка, модел, сериен номер и " +
    "др.)";
            this.columnServiceName.MinimumWidth = 6;
            this.columnServiceName.Name = "columnServiceName";
            this.columnServiceName.ReadOnly = true;
            this.columnServiceName.Width = 125;
            // 
            // columnServiceCategory
            // 
            this.columnServiceCategory.DataPropertyName = "Category";
            this.columnServiceCategory.HeaderText = "Kатегория съгласно т. 4.3.2.2 от БДС ISO 11602-2:2002";
            this.columnServiceCategory.MinimumWidth = 6;
            this.columnServiceCategory.Name = "columnServiceCategory";
            this.columnServiceCategory.ReadOnly = true;
            this.columnServiceCategory.Width = 125;
            // 
            // columnServiceWeight
            // 
            this.columnServiceWeight.DataPropertyName = "Weight";
            this.columnServiceWeight.HeaderText = "Маса на заредения пожарогасител,  kg";
            this.columnServiceWeight.MinimumWidth = 6;
            this.columnServiceWeight.Name = "columnServiceWeight";
            this.columnServiceWeight.ReadOnly = true;
            this.columnServiceWeight.Width = 125;
            // 
            // columnServiceContent
            // 
            this.columnServiceContent.DataPropertyName = "Category2";
            this.columnServiceContent.HeaderText = "Пожаро-гасително вещество (вода, прах, СО2 или др.)";
            this.columnServiceContent.MinimumWidth = 6;
            this.columnServiceContent.Name = "columnServiceContent";
            this.columnServiceContent.ReadOnly = true;
            this.columnServiceContent.Width = 125;
            // 
            // columnServiceContentName
            // 
            this.columnServiceContentName.DataPropertyName = "FoamName";
            this.columnServiceContentName.HeaderText = "Търговско наименование на пожарогасителното в-во (при презареждане с прах или пен" +
    "ообразувател)";
            this.columnServiceContentName.MinimumWidth = 6;
            this.columnServiceContentName.Name = "columnServiceContentName";
            this.columnServiceContentName.ReadOnly = true;
            this.columnServiceContentName.Width = 125;
            // 
            // columnServiceType
            // 
            this.columnServiceType.DataPropertyName = "ServiceType";
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnServiceType.DefaultCellStyle = dataGridViewCellStyle22;
            this.columnServiceType.HeaderText = "Вид на извършеното обслужване (техническо обслужване, презареждане, хидростатично" +
    " изпитване на устойчивост на налягане)";
            this.columnServiceType.MinimumWidth = 6;
            this.columnServiceType.Name = "columnServiceType";
            this.columnServiceType.ReadOnly = true;
            this.columnServiceType.Width = 175;
            // 
            // columnServiceStickers
            // 
            this.columnServiceStickers.DataPropertyName = "Sticker";
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnServiceStickers.DefaultCellStyle = dataGridViewCellStyle23;
            this.columnServiceStickers.HeaderText = "Номер на стикер";
            this.columnServiceStickers.MinimumWidth = 6;
            this.columnServiceStickers.Name = "columnServiceStickers";
            this.columnServiceStickers.ReadOnly = true;
            this.columnServiceStickers.Width = 125;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "X";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 125;
            // 
            // grd2EditColumn
            // 
            this.grd2EditColumn.HeaderText = "";
            this.grd2EditColumn.MinimumWidth = 6;
            this.grd2EditColumn.Name = "grd2EditColumn";
            this.grd2EditColumn.ReadOnly = true;
            this.grd2EditColumn.Text = "Редактирай";
            this.grd2EditColumn.UseColumnTextForButtonValue = true;
            this.grd2EditColumn.Width = 125;
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddService.Location = new System.Drawing.Point(3, 716);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(139, 34);
            this.btnAddService.TabIndex = 5;
            this.btnAddService.Text = "Добави";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Технически обслужвания";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(845, 7);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(687, 22);
            this.txtAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(783, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Адрес";
            // 
            // btnUpdateCompany
            // 
            this.btnUpdateCompany.Location = new System.Drawing.Point(1546, 7);
            this.btnUpdateCompany.Name = "btnUpdateCompany";
            this.btnUpdateCompany.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCompany.TabIndex = 8;
            this.btnUpdateCompany.Text = "Запази";
            this.btnUpdateCompany.UseVisualStyleBackColor = true;
            this.btnUpdateCompany.Click += new System.EventHandler(this.btnUpdateCompany_Click);
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1640, 817);
            this.Controls.Add(this.btnUpdateCompany);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "CompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Контрагент";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddStament;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatementNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatementDate;
        private System.Windows.Forms.DataGridViewButtonColumn columnStatementEdit;
        private System.Windows.Forms.Button btnPrint1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn grd2Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceContentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnServiceStickers;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.DataGridViewButtonColumn grd2EditColumn;
        private System.Windows.Forms.Button btnTwin;
    }
}