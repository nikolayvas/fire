namespace FireWork
{
    partial class Report2Form
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
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.txtFromNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtToNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerateReport.Location = new System.Drawing.Point(12, 72);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(171, 34);
            this.btnGenerateReport.TabIndex = 5;
            this.btnGenerateReport.Text = "Генерирай репорт";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // txtFromNo
            // 
            this.txtFromNo.Location = new System.Drawing.Point(172, 19);
            this.txtFromNo.Name = "txtFromNo";
            this.txtFromNo.Size = new System.Drawing.Size(100, 22);
            this.txtFromNo.TabIndex = 4;
            this.txtFromNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "От протокол с номер:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "до номер:";
            // 
            // txtToNo
            // 
            this.txtToNo.Location = new System.Drawing.Point(392, 19);
            this.txtToNo.Name = "txtToNo";
            this.txtToNo.Size = new System.Drawing.Size(100, 22);
            this.txtToNo.TabIndex = 7;
            this.txtToNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtToNo_Validating);
            // 
            // Report2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 118);
            this.Controls.Add(this.txtToNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.txtFromNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Report2Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дневник за презареждане";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Report2Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.TextBox txtFromNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToNo;
    }
}