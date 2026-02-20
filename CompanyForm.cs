using FireWork.Dto;
using Library.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FireWork
{
    public partial class CompanyForm : Form
    {
        private int CompanyId { get; set; }

        private int SelectedStatementId { get; set; }

        private Main MainForm { get; }

        private List<ServiceDto> services = new List<ServiceDto>();

        public CompanyForm(Main parent, int companyId, string name, string address)
        {
            MainForm = parent;
            InitializeComponent();
            this.txtName.Text = name;
            this.txtAddress.Text = address;
            CompanyId = companyId;
            this.btnAddService.Enabled = false;
            this.btnPrint1.Enabled = false;

            LoadStatementsData();
        }

        private void LoadStatementsData()
        {
            var data = DBAccess.LoadStatements(CompanyId);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = new SortableBindingList<StatementDto>(data);
        }

        private void LoadServicesData()
        {
            services = DBAccess.LoadServices(SelectedStatementId);

            var gridData = ConvertServices(services);

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = new SortableBindingList<ServiceUIDto>(gridData);

            this.btnClone.Visible = dataGridView2.Rows.Count > 0;
        }

        int rowIndex = -1;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if(senderGrid.CurrentRow == null)
            {
                return;
            }

            if (senderGrid.CurrentRow.Index != rowIndex)
            {
                rowIndex = senderGrid.CurrentRow.Index;
                var selectedRow = senderGrid.Rows[rowIndex];

                this.SelectedStatementId = int.Parse(selectedRow.Cells[0].Value.ToString());
                this.btnAddService.Enabled = true;
                this.btnPrint1.Enabled = true;
                this.btnTwin.Enabled = true;

                LoadServicesData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex < 0)
                return;

            if ((senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) &&
                e.RowIndex >= 0)
            {
                var selectedRow = senderGrid.Rows[e.RowIndex];
                var statementId = int.Parse(selectedRow.Cells[0].Value.ToString());

                if (e.ColumnIndex == senderGrid.ColumnCount - 1)
                {
                    var confirmResult = MessageBox.Show("Сигурен ли си?",
                                         "Изтриване на запис!",
                                         MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        DBAccess.RemoveStatement(statementId);
                        LoadStatementsData();
                    }
                }
            }
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
                    Category2 = x.Category == 1 ? "ВОДА" : (x.Category == 5 ? "CO2" : "ПРАХ"),
                    FoamName = x.FoamName,
                    Weight = x.Weight,
                    ServiceType = serviceType,
                    Sticker = sticker
                };
            }).ToArray();
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

                if(e.ColumnIndex == senderGrid.ColumnCount - 1 )
                {
                    var confirmResult = MessageBox.Show("Сигурен ли си?",
                                         "Изтриване на запис!",
                                         MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        DBAccess.RemoveService(serviceId);
                        LoadServicesData();
                    }
                }
                else
                {
                    var service = DBAccess.LoadService(serviceId);
                    AddServiceForm frm = new AddServiceForm(SelectedStatementId, service);
                    var dialogResult = frm.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        LoadServicesData();
                    }
                }
            }
        }

        private void btnAddStatement_Click(object sender, EventArgs e)
        {
            AddStatementForm addForm = new AddStatementForm(CompanyId, DBAccess.LastStatementNo() + 1);
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadStatementsData();
                MainForm.LoadProtocolNo();
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            AddServiceForm addForm = new AddServiceForm(SelectedStatementId);
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadServicesData();
            }
        }

        private void btnUpdateCompany_Click(object sender, EventArgs e)
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

        private void btnTwin_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var statementId = int.Parse(selectedRow.Cells[0].Value.ToString());

                AddStatementForm addForm = new AddStatementForm(CompanyId, DBAccess.LastStatementNo() + 1, statementId);
                addForm.ShowDialog();

                if (addForm.DialogResult == DialogResult.OK)
                {
                    LoadStatementsData();
                    MainForm.LoadProtocolNo();
                }
            }
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            var company = DBAccess.LoadCompany(CompanyId);
            var statement = DBAccess.LoadStatement(SelectedStatementId);
            var services = DBAccess.LoadServices(SelectedStatementId);

            ReportsGenerator.GenerateStatemet(company, statement, ConvertServices(services), $"{Application.StartupPath}\\Протокол.dot");
        }

        private void CompanyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView2.SelectedRows.Count > 0 
                ? dataGridView2.SelectedRows[0] 
                : dataGridView2.Rows[0];

            var serviceId = int.Parse(selectedRow.Cells[0].Value.ToString());

            var service = services.FirstOrDefault(x => x.Id == serviceId);

            AddServiceForm addForm = new AddServiceForm(SelectedStatementId, service, true);
            addForm.ShowDialog();

            if (addForm.DialogResult == DialogResult.OK)
            {
                LoadServicesData();
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex > 7)
            {
                return;
            }

            if (!string.IsNullOrEmpty(textBox1.Text) && e.Value != null)
            {
                if (e.Value.ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.Invalidate(); ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
