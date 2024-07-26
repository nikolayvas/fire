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
            this.Text = "Zanevi System";

            LoadData();
        }

        private void ErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;
            MessageBox.Show(ex.ToString(),
                   "Error Information",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
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

                CompanyForm companyForm = new CompanyForm();
                companyForm.CompanyId = int.Parse(selectedRow.Cells[0].Value.ToString());
                companyForm.ShowDialog();
            }
        }

        private void LoadData()
        {
            var data = DBAccess.LoadData();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = new SortableBindingList<CompanyDto>(data); ;
        }
    }
}
