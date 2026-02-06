using FireWork.Dto;
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace FireWork
{
    public static class DocsGenerator
    {
        static object missing = Missing.Value;

        public static void GenerateStatemet(CompanyDto company, StatementDto statement, ServiceUIDto[] services, string docPath)
        {
            Application wApp = new Application
            {
                Visible = false
            };
            Documents wDocs = wApp.Documents;
            Document wDoc = wDocs.Open(docPath, ReadOnly: true, Visible: true);

            SearchAndReplace(wDoc, "_no_", statement.No.ToString());
            SearchAndReplace(wDoc, "_date_", statement.Date.ToString("dd.MM.yyyy"));
            SearchAndReplace(wDoc, "_owner_", company.Name?.ToString());
            SearchAndReplace(wDoc, "_address_", company.Address?.ToString());

            var table = wDoc.Tables[1];

            var rowsStartIndex = 3;
            var serviceNumber = 0;

            foreach(var service in services)
            {
                table.Rows.Add();
                table.Rows[rowsStartIndex].Cells[1].Range.Text = (++serviceNumber).ToString();
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

            wApp.Visible = true;
            wDoc.Activate();
        }

        public static void GenerateDiary(DiaryDto[] rows, string docPath)
        {
            Application wApp = new Application
            {
                Visible = false
            };
            Documents wDocs = wApp.Documents;
            Document wDoc = wDocs.Open(docPath, ReadOnly: true, Visible: true);

            var table = wDoc.Tables[1];

            var rowsStartIndex = 3;
            var rowsCounter = 1;

            foreach (var service in rows)
            {
                table.Rows.Add();
                var rowRange = table.Rows[rowsStartIndex].Range;
                rowRange.ParagraphFormat.LineSpacingRule = WdLineSpacing.wdLineSpaceMultiple;
                rowRange.ParagraphFormat.LineSpacing = 13.5F;

                table.Rows[rowsStartIndex].Range.Font.Size = 11;

                table.Rows[rowsStartIndex].Cells[1].Range.Text = (rowsCounter).ToString();

                table.Rows[rowsStartIndex].Cells[2].Range.Text = service.Date;

                table.Rows[rowsStartIndex].Cells[3].Range.Text = service.UnitModel;

                table.Rows[rowsStartIndex].Cells[4].Range.Text = service.UnitModel;

                table.Rows[rowsStartIndex].Cells[5].Range.Text = "";

                table.Rows[rowsStartIndex].Cells[6].Range.Text = service.ServiceType;

                table.Rows[rowsStartIndex].Cells[7].Range.Text = service.Sticker;

                table.Rows[rowsStartIndex].Cells[8].Range.Text = service.TradeNameFoam;

                table.Rows[rowsStartIndex].Cells[9].Range.Text = service.DataNext;

                if(rowsCounter % 20 == 0)
                {
                    rowsStartIndex++;
                    table.Rows.Add();

                    table.Rows[1].Range.Copy();
                    table.Rows[rowsStartIndex].Range.Paste();

                    table.Rows[2].Range.Copy();

                    table.Rows.Add();
                    rowsStartIndex++;
                    table.Rows[rowsStartIndex].Range.Paste();
                }

                rowsCounter++;
                rowsStartIndex++;
            }

            wApp.Visible = true;
            wDoc.Activate();
        }

        private static void SearchAndReplace(Document doc, string find, string replace)
        {
            foreach (Range tmpRange in doc.StoryRanges)
            {
                // Set the text to find and replace
                tmpRange.Find.Text = find;
                tmpRange.Find.Replacement.Text = replace;

                // Set the Find.Wrap property to continue (so it doesn't
                // prompt the user or stop when it hits the end of
                // the section)
                tmpRange.Find.Wrap = WdFindWrap.wdFindContinue;

                // Declare an object to pass as a parameter that sets
                // the Replace parameter to the "wdReplaceAll" enum
                object replaceAll = WdReplace.wdReplaceAll;

                // Execute the Find and Replace -- notice that the
                // 11th parameter is the "replaceAll" enum object
                tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref replaceAll,
                    ref missing, ref missing, ref missing, ref missing);
            }
            /*

            Find findObject = doc.Content.Find;
            findObject.ClearFormatting();
            findObject.Text = find;
            findObject.MatchWholeWord = true;
            findObject.Replacement.ClearFormatting();
            findObject.Replacement.Text = replace;

            object replaceAll = WdReplace.wdReplaceOne;
            findObject.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
            */
        }
    }
}
