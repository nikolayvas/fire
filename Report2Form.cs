using FireWork.Helpers;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FireWork
{
    public partial class Report2Form : Form
    {
        public Report2Form()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            ExceptionWrapper.Wrap(() =>
            {
                var protocolNo = int.Parse(txtNo.Text);
                var diaryRows = DBAccess.GetReportData(protocolNo);
                var doubleArray = diaryRows.Concat(diaryRows);

                DocsGenerator.GenerateDiary(doubleArray.ToArray(), $"{Application.StartupPath}\\diary.dot");
            });
        }

        private void Report2Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
