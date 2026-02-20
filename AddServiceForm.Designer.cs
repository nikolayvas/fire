namespace FireWork
{
    partial class AddServiceForm
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkStick1 = new System.Windows.Forms.CheckBox();
            this.chkStick2 = new System.Windows.Forms.CheckBox();
            this.chkStick3 = new System.Windows.Forms.CheckBox();
            this.txtStick3 = new System.Windows.Forms.TextBox();
            this.txtStick2 = new System.Windows.Forms.TextBox();
            this.txtStick1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTradeName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Идентификатор";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Маса";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(233, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 22);
            this.txtName.TabIndex = 5;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(233, 101);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(237, 22);
            this.txtWeight.TabIndex = 8;
            this.txtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtWeight_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Вид обслужвания";
            // 
            // chkStick1
            // 
            this.chkStick1.AutoSize = true;
            this.chkStick1.Location = new System.Drawing.Point(18, 178);
            this.chkStick1.Name = "chkStick1";
            this.chkStick1.Size = new System.Drawing.Size(189, 20);
            this.chkStick1.TabIndex = 10;
            this.chkStick1.Text = "Техническо обслужване";
            this.chkStick1.UseVisualStyleBackColor = true;
            this.chkStick1.CheckedChanged += new System.EventHandler(this.chkStick1_CheckedChanged);
            // 
            // chkStick2
            // 
            this.chkStick2.AutoSize = true;
            this.chkStick2.Location = new System.Drawing.Point(17, 206);
            this.chkStick2.Name = "chkStick2";
            this.chkStick2.Size = new System.Drawing.Size(128, 20);
            this.chkStick2.TabIndex = 11;
            this.chkStick2.Text = "Презареждане";
            this.chkStick2.UseVisualStyleBackColor = true;
            this.chkStick2.CheckedChanged += new System.EventHandler(this.chkStick2_CheckedChanged);
            // 
            // chkStick3
            // 
            this.chkStick3.AutoSize = true;
            this.chkStick3.Location = new System.Drawing.Point(18, 234);
            this.chkStick3.Name = "chkStick3";
            this.chkStick3.Size = new System.Drawing.Size(204, 20);
            this.chkStick3.TabIndex = 12;
            this.chkStick3.Text = "Хидростатично изпитание";
            this.chkStick3.UseVisualStyleBackColor = true;
            this.chkStick3.CheckedChanged += new System.EventHandler(this.chkStick3_CheckedChanged);
            // 
            // txtStick3
            // 
            this.txtStick3.Location = new System.Drawing.Point(233, 232);
            this.txtStick3.Name = "txtStick3";
            this.txtStick3.Size = new System.Drawing.Size(237, 22);
            this.txtStick3.TabIndex = 13;
            this.txtStick3.Visible = false;
            // 
            // txtStick2
            // 
            this.txtStick2.Location = new System.Drawing.Point(233, 204);
            this.txtStick2.Name = "txtStick2";
            this.txtStick2.Size = new System.Drawing.Size(237, 22);
            this.txtStick2.TabIndex = 14;
            this.txtStick2.Visible = false;
            // 
            // txtStick1
            // 
            this.txtStick1.Location = new System.Drawing.Point(233, 176);
            this.txtStick1.Name = "txtStick1";
            this.txtStick1.Size = new System.Drawing.Size(237, 22);
            this.txtStick1.TabIndex = 15;
            this.txtStick1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Добави";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Търговско наименование";
            // 
            // txtTradeName
            // 
            this.txtTradeName.Location = new System.Drawing.Point(233, 70);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(237, 22);
            this.txtTradeName.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Стикер";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Категория 1 ( ВОДА )",
            "Категория 2 ( ПРАХ )",
            "Категория 4 ( ПРАХ )",
            "Категория 5 ( CO2 )"});
            this.cmbCategory.Location = new System.Drawing.Point(233, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(237, 24);
            this.cmbCategory.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Категория";
            // 
            // AddServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 339);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTradeName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtStick1);
            this.Controls.Add(this.txtStick2);
            this.Controls.Add(this.txtStick3);
            this.Controls.Add(this.chkStick3);
            this.Controls.Add(this.chkStick2);
            this.Controls.Add(this.chkStick1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Техническо обслужване";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddServiceForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkStick1;
        private System.Windows.Forms.CheckBox chkStick2;
        private System.Windows.Forms.CheckBox chkStick3;
        private System.Windows.Forms.TextBox txtStick3;
        private System.Windows.Forms.TextBox txtStick2;
        private System.Windows.Forms.TextBox txtStick1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTradeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label1;
    }
}