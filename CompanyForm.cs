using FireWork.Dto;
using Library.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FireWork
{
    public partial class CompanyForm : Form
    {
        private int CompanyId { get; set; }

        private int SelectedStatementId { get; set; }

        private Main MainForm { get; }

        public CompanyForm(Main parent, int companyId, string name, string address)
        {
            MainForm = parent;
            InitializeComponent();
            this.txtName.Text = name;
            this.txtAddress.Text = address;
            CompanyId = companyId;
            this.button2.Enabled = false;
            this.button3.Enabled = false;

            LoadStatementsData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStatementForm addForm = new AddStatementForm(CompanyId);
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadStatementsData();
                MainForm.LoadProtocolNo();
            }
        }

        private void LoadStatementsData()
        {
            var data = DBAccess.LoadStatements(CompanyId);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = new SortableBindingList<StatementDto>(data);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if ((e.ColumnIndex == -1 || senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) &&
                e.RowIndex >= 0)
            {
                var selectedRow = senderGrid.Rows[e.RowIndex];
                this.SelectedStatementId = int.Parse(selectedRow.Cells[0].Value.ToString());
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                LoadServicesData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddServiceForm addForm = new AddServiceForm(SelectedStatementId);
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadServicesData();
            }
        }

        private void LoadServicesData()
        {
            var data = DBAccess.LoadServices(SelectedStatementId);

            var gridData = ConvertServices(data);

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = new SortableBindingList<ServiceUIDto>(gridData);
        }

        private ServiceUIDto[] ConvertServices(List<ServiceDto> services)
        {
            return services.Select(x =>
            {
                string serviceType = string.Empty;
                string sticker = string.Empty;

                if (!string.IsNullOrEmpty(x.Sticker1))
                {
                    serviceType = "Техническо Обслужване";
                    sticker = x.Sticker1;
                }

                if (!string.IsNullOrEmpty(x.Sticker2))
                {
                    serviceType += (Environment.NewLine + "Презареждане");
                    sticker += (Environment.NewLine + x.Sticker2);
                }

                if (!string.IsNullOrEmpty(x.Sticker3))
                {
                    serviceType += (Environment.NewLine + "Хидростатично Изпитване");
                    sticker += (Environment.NewLine + x.Sticker3);
                }

                return new ServiceUIDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = "Категория " + x.Category,
                    Category2 = x.Category == 1 ? "ВОДА" : (x.Category == 2 ? "ПРАХ" : "CO2"),
                    FoamName = x.FoamName,
                    Weight = x.Weight,
                    ServiceType = serviceType,
                    Sticker = sticker
                };
            }).ToArray();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var company = DBAccess.LoadCompany(CompanyId);
            var statement = DBAccess.LoadStatement(SelectedStatementId);
            var services = DBAccess.LoadServices(SelectedStatementId);

            DocsGenerator.GenerateStatemet(company, statement, ConvertServices(services), $"{Application.StartupPath}\\template.dot");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex < 0)
                return;

            if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) &&
                e.RowIndex >= 0)
            {
                var selectedRow = senderGrid.Rows[e.RowIndex];
                var serviceId = int.Parse(selectedRow.Cells[0].Value.ToString());

                var confirmResult = MessageBox.Show("Сигурен ли си?",
                                     "Изтриване на запис!",
                                     MessageBoxButtons.YesNo);

                if(confirmResult == DialogResult.Yes)
                {
                    DBAccess.RemoveService(serviceId);
                    LoadServicesData();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompanyDto update = new CompanyDto()
            {
                Id = CompanyId,
                Name = this.txtName.Text,
                Address = this.txtAddress.Text
            };

            DBAccess.UpdateCompany(update);

            MainForm.LoadData();
        }
    }
}
