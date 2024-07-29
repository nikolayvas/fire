using FireWork.Dto;
using System;
using System.Windows.Forms;

namespace FireWork
{
    public partial class AddServiceForm : Form
    {
        private int StatementId { get; set; }

        public AddServiceForm(int statementId)
        {
            InitializeComponent();
            StatementId = statementId;
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
                    No = int.Parse(txtNo.Text),
                    Name = txtName.Text,
                    Category = comboBox1.Text == "CO2" ? 5 : (comboBox1.Text == "ВОДА" ? 1 : 2),
                    FoamName = txtTradeName.Text,
                    Weight = decimal.Parse(txtWeight.Text),
                    Sticker1 = txtStick1.Visible ? txtStick1.Text : null,
                    Sticker2 = txtStick2.Visible ? txtStick2.Text : null,
                    Sticker3 = txtStick3.Visible ? txtStick3.Text : null,
                };  

                DBAccess.AddNewService(StatementId, dto);

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
    }
}
