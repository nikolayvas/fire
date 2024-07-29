using FireWork.Dto;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace FireWork
{
    public static class StatementDocGenerator
    {
        public static void GenerateStatemet(CompanyDto company, StatementDto statement, ServiceUIDto[] services, string docPath)
        {
            Application wApp = new Application
            {
                Visible = true
            };
            Documents wDocs = wApp.Documents;
            Document wDoc = wDocs.Open(docPath, ReadOnly: true, Visible: true);

            SearchAndReplace(wDoc, "_no_", statement.No.ToString());
            SearchAndReplace(wDoc, "_date_", statement.Date.ToString("dd.MM.yyyy"));
            SearchAndReplace(wDoc, "_owner_", company.Name?.ToString());
            SearchAndReplace(wDoc, "_address_", company.Address?.ToString());

            var table = wDoc.Tables[1];

            var rowsStartIndex = 3;

            foreach(var service in services)
            {
                table.Rows.Add();
                table.Rows[rowsStartIndex].Cells[1].Range.Text = service.No.ToString();
                table.Rows[rowsStartIndex].Cells[2].Range.Text = service.Name;
                table.Rows[rowsStartIndex].Cells[3].Range.Text = service.Category;
                table.Rows[rowsStartIndex].Cells[4].Range.Text = service.Weight.ToString();
                table.Rows[rowsStartIndex].Cells[5].Range.Text = service.Category2;
                table.Rows[rowsStartIndex].Cells[6].Range.Text = service.FoamName;
                table.Rows[rowsStartIndex].Cells[7].Range.Text = service.ServiceType;
                table.Rows[rowsStartIndex].Cells[8].Range.Text = statement.Date.ToString("dd.MM.yyyy");
                table.Rows[rowsStartIndex].Cells[9].Range.Text = "инж.Андрей Занев";
                table.Rows[rowsStartIndex].Cells[10].Range.Text = "";
                table.Rows[rowsStartIndex].Cells[11].Range.Text = service.Sticker;
                rowsStartIndex++;
            }

            wDoc.Activate();
        }

        private static void SearchAndReplace(Document doc, string find, string replace)
        {
            Find findObject = doc.Content.Find;
            findObject.ClearFormatting();
            findObject.Text = find;
            findObject.MatchWholeWord = true;
            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = replace;

            object missing = Missing.Value;
            object replaceAll = WdReplace.wdReplaceOne;
            findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }
    }
}
