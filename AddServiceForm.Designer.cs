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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Идентификатор";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Маса";
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(230, 10);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(237, 22);
            this.txtNo.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(230, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(237, 22);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Пожарогасително вещество";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CO2",
            "ПРАХ",
            "ВОДА"});
            this.comboBox1.Location = new System.Drawing.Point(230, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 24);
            this.comboBox1.TabIndex = 7;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(230, 164);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(237, 22);
            this.txtWeight.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Вид обслужвания";
            // 
            // chkStick1
            // 
            this.chkStick1.AutoSize = true;
            this.chkStick1.Location = new System.Drawing.Point(17, 272);
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
            this.chkStick2.Location = new System.Drawing.Point(16, 300);
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
            this.chkStick3.Location = new System.Drawing.Point(16, 328);
            this.chkStick3.Name = "chkStick3";
            this.chkStick3.Size = new System.Drawing.Size(204, 20);
            this.chkStick3.TabIndex = 12;
            this.chkStick3.Text = "Хидростатично изпитание";
            this.chkStick3.UseVisualStyleBackColor = true;
            this.chkStick3.CheckedChanged += new System.EventHandler(this.chkStick3_CheckedChanged);
            // 
            // txtStick3
            // 
            this.txtStick3.Location = new System.Drawing.Point(231, 326);
            this.txtStick3.Name = "txtStick3";
            this.txtStick3.Size = new System.Drawing.Size(237, 22);
            this.txtStick3.TabIndex = 13;
            this.txtStick3.Visible = false;
            // 
            // txtStick2
            // 
            this.txtStick2.Location = new System.Drawing.Point(231, 298);
            this.txtStick2.Name = "txtStick2";
            this.txtStick2.Size = new System.Drawing.Size(237, 22);
            this.txtStick2.TabIndex = 14;
            this.txtStick2.Visible = false;
            // 
            // txtStick1
            // 
            this.txtStick1.Location = new System.Drawing.Point(231, 270);
            this.txtStick1.Name = "txtStick1";
            this.txtStick1.Size = new System.Drawing.Size(237, 22);
            this.txtStick1.TabIndex = 15;
            this.txtStick1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 376);
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
            this.label6.Location = new System.Drawing.Point(11, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Търговско наименование";
            // 
            // txtTradeName
            // 
            this.txtTradeName.Location = new System.Drawing.Point(230, 123);
            this.txtTradeName.Name = "txtTradeName";
            this.txtTradeName.Size = new System.Drawing.Size(237, 22);
            this.txtTradeName.TabIndex = 18;
            // 
            // AddServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 430);
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
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Техническо обслужване";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
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
    }
}