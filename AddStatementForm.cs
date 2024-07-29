using FireWork.Dto;
using System;
using System.Windows.Forms;

namespace FireWork
{
    public partial class AddStatementForm : Form
    {
        private int CompanyId {  get; set; }

        public AddStatementForm(int companyId)
        {
            CompanyId = companyId;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = new StatementDto()
                {
                    No = int.Parse(textBox1.Text),
                };

                DBAccess.AddNewStatement(CompanyId, dto);

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
