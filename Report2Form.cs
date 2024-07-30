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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var protocolNo = int.Parse(textBox1.Text);
                var diaryRows = DBAccess.GetReportData(protocolNo);
                var doubleArray = diaryRows.Concat(diaryRows);

                DocsGenerator.GenerateDiary(doubleArray.ToArray(), $"{Application.StartupPath}\\diary.dot");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(),
                   "Error Information",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
            }
        }
    }
}
