using FireWork.Dto;
using Library.Forms;
using System;
using System.Linq;
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

        public void LoadData(string filter = "")
        {
            var data = DBAccess.LoadCompanies();

            if(!string.IsNullOrEmpty(filter))
            {
                data = data.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
            }

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

                if (e.ColumnIndex == 5)
                {
                    var confirmResult = MessageBox.Show("Сигурен ли си, че искаш да изтриеш компанията и всички данни за нея?",
                                         "Изтриване !",
                                         MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        DBAccess.RemoveCompany(int.Parse(selectedRow.Cells[0].Value.ToString()));
                        LoadData();
                    }
                }
                else
                {
                    CompanyForm companyForm = new CompanyForm(
                        this,
                        int.Parse(selectedRow.Cells[0].Value.ToString()),
                        selectedRow.Cells[1].Value.ToString(),
                        selectedRow.Cells[2].Value.ToString());

                    companyForm.ShowDialog();
                }
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Report2Form reportForm = new Report2Form();
            reportForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.LoadData(((TextBox)sender).Text);
        }
    }
}
