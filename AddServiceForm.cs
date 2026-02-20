using FireWork.Dto;
using System;
using System.Windows.Forms;

namespace FireWork
{
    public partial class AddServiceForm : Form
    {
        private ServiceDto service;

        private int StatementId { get; set; }

        private readonly bool AddNew = true;

        public AddServiceForm(int statementId)
        {
            InitializeComponent();
            StatementId = statementId;
        }

        public AddServiceForm(int statementId, ServiceDto service, bool addNew = false)
        {
            StatementId = statementId;
            this.service = service;
            InitializeComponent();

            this.txtName.Text = service.Name;
            this.txtTradeName.Text = service.FoamName;
            this.txtWeight.Text = service.Weight.ToString();
            this.cmbCategory.SelectedIndex = service.Category < 3 ? service.Category - 1 : service.Category - 2;

            if(!string.IsNullOrEmpty(service.Sticker1))
            {
                this.chkStick1.Checked = true;
                this.txtStick1.Text = service.Sticker1;
            }

            if (!string.IsNullOrEmpty(service.Sticker2))
            {
                this.chkStick2.Checked = true;
                this.txtStick2.Text = service.Sticker2;
            }

            if (!string.IsNullOrEmpty(service.Sticker3))
            {
                this.chkStick3.Checked = true;
                this.txtStick3.Text = service.Sticker3;
            }

            this.button1.Text = "Запази";
            AddNew = addNew;
        }

        private void chkStick1_CheckedChanged(object sender, EventArgs e)
        {
            txtStick1.Visible = chkStick1.Checked;
        }

        private void chkStick2_CheckedChanged(object sender, EventArgs e)
        {
            txtStick2.Visible = chkStick2.Checked;
        }

        private void chkStick3_CheckedChanged(object sender, EventArgs e)
        {
            txtStick3.Visible = chkStick3.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new ServiceDto()
                {
                    Name = txtName.Text,
                    Category = this.cmbCategory.SelectedIndex < 2 ? this.cmbCategory.SelectedIndex + 1 : this.cmbCategory.SelectedIndex + 2,
                    FoamName = txtTradeName.Text,
                    Weight = txtWeight.Text == "" ? 0 : decimal.Parse(txtWeight.Text),
                    Sticker1 = txtStick1.Visible ? txtStick1.Text : null,
                    Sticker2 = txtStick2.Visible ? txtStick2.Text : null,
                    Sticker3 = txtStick3.Visible ? txtStick3.Text : null,
                };  

                if(AddNew)
                {
                    DBAccess.AddNewService(StatementId, dto);
                }
                else
                {
                    dto.Id = service.Id;
                    DBAccess.UpdateService(dto);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                    "Error Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void AddServiceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!decimal.TryParse(txtWeight.Text, out decimal weight))
            {
                this.errorProvider1.SetError(txtWeight, "Въведи число");
                e.Cancel = true;
            }
            else
            {
                this.errorProvider1.SetError(txtWeight, "");
            }
        }
    }
}
