using FireWork.Dto;
using FireWork.Helpers;
using System;
using System.Windows.Forms;

namespace FireWork
{
    public partial class AddStatementForm : Form
    {
        private int CompanyId {  get; set; }

        public int TwinStatement { get; }

        public AddStatementForm(int companyId, int statementNo)
        {
            CompanyId = companyId;

            InitializeComponent();

            txtNo.Text = statementNo.ToString();
        }

        public AddStatementForm(int companyId, int statementNo, int twinStatement)
        {
            CompanyId = companyId;
            TwinStatement = twinStatement;
            InitializeComponent();

            txtNo.Text = statementNo.ToString();
            btnAdd.Text = "Дублирай";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = new StatementDto()
            {
                No = int.Parse(txtNo.Text),
                Date = dateTimePicker1.Value
            };

            ExceptionWrapper.Wrap(() =>
            {
                if(TwinStatement == 0)
                {
                    DBAccess.AddNewStatement(CompanyId, dto);
                }
                else
                {
                    DBAccess.TwinStatement(CompanyId, TwinStatement, dto);
                }

                DialogResult = DialogResult.OK;
            });
        }

        private void AddStatementForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {
            int no;
            if (!int.TryParse(txtNo.Text, out no))
            {
                this.errorProvider1.SetError(txtNo, "Въведи номер");
            }
            else
            {
                this.errorProvider1.SetError(txtNo, "");
            }
        }
    }
}
