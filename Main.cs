using FireWork.Dto;
using Library.Forms;
using System;
using System.Windows.Forms;

namespace FireWork
{
    public partial class Main : Form
    {
        public Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler);

            InitializeComponent();
            this.Text = "Противопожарно обслужване";

            LoadData();
            LoadProtocolNo();
        }

        public void LoadData()
        {
            var data = DBAccess.LoadCompanies();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = new SortableBindingList<CompanyDto>(data);
        }


        public void LoadProtocolNo()
        {
            this.txtProtocolNo.Text = DBAccess.LastStatementNo().ToString();
        }

        private void ErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            MessageBox.Show(ex.ToString(),
                   "Error Information",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            AddCompanyForm addForm = new AddCompanyForm();
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var selectedRow = senderGrid.Rows[e.RowIndex];

                CompanyForm companyForm = new CompanyForm(
                    this,
                    int.Parse(selectedRow.Cells[0].Value.ToString()), 
                    selectedRow.Cells[1].Value.ToString(),
                    selectedRow.Cells[2].Value.ToString());

                companyForm.ShowDialog();
            }
        }


        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Report2Form reportForm = new Report2Form();
            reportForm.ShowDialog();
        }
    }
}
