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
            ExceptionWrapper.Wrap(() =>
            {
                if(TwinStatement == 0)
                {
                    var dto = new StatementDto()
                    {
                        No = int.Parse(txtNo.Text),
                    };

                    DBAccess.AddNewStatement(CompanyId, dto);
                }
                else
                {
                    DBAccess.TwinStatement(CompanyId, TwinStatement, DBAccess.LastStatementNo() + 1);
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
    }
}
