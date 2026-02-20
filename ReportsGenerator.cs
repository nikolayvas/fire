using ClosedXML.Excel;
using FireWork.Dto;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace FireWork
{
    public static class ReportsGenerator
    {
        static object missing = Missing.Value;

        public static void GenerateStatemet(CompanyDto company, StatementDto statement, ServiceUIDto[] services, string docPath)
        {
            Word.Application wApp = new Word.Application
            {
                Visible = false
            };
            Word.Documents wDocs = wApp.Documents;
            Word.Document wDoc = wDocs.Open(docPath, ReadOnly: true, Visible: true);

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
                table.Rows[rowsStartIndex].Cells[8].Range.Text = statement.Date.AddYears(1).AddDays(-1).ToString("dd.MM.yyyy");
                table.Rows[rowsStartIndex].Cells[9].Range.Text = "инж.Андрей Занев";
                table.Rows[rowsStartIndex].Cells[10].Range.Text = "";
                table.Rows[rowsStartIndex].Cells[11].Range.Text = service.Sticker;
                rowsStartIndex++;
            }

            wApp.Visible = true;
            wDoc.Activate();

            string filePath = $"{System.Windows.Forms.Application.StartupPath}\\Протоколи\\Протокол {statement.No} {company.Name}.docx";

            wDoc.SaveAs(
                FileName: filePath,
                FileFormat: Word.WdSaveFormat.wdFormatXMLDocument
            );
        }

        public static void ExcelReport(DiaryDto[] rows, string docPath)
        {
            string filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".xlsx";
            using (var workbook = new XLWorkbook(docPath))
            {
                // 2. Access a specific worksheet
                var worksheet = workbook.Worksheet(1);

                var rowsStartIndex = 3;
                var rowsCounter = 1;

                foreach (var service in rows)
                {
                    worksheet.Cell(rowsStartIndex, 1).Value = rowsCounter;
                    worksheet.Cell(rowsStartIndex, 2).Value = service.Date;
                    worksheet.Cell(rowsStartIndex, 3).Value = service.UnitWeightType;
                    worksheet.Cell(rowsStartIndex, 4).Value = service.UnitModel;
                    worksheet.Cell(rowsStartIndex, 5).Value = "";
                    worksheet.Cell(rowsStartIndex, 6).Value = service.ServiceType;
                    worksheet.Cell(rowsStartIndex, 7).Value = service.Sticker;
                    worksheet.Cell(rowsStartIndex, 8).Value = service.TradeNameFoam;
                    worksheet.Cell(rowsStartIndex, 9).Value = service.DataNext;

                    rowsCounter++;
                    rowsStartIndex++;
                }

                worksheet.Range(1, 1, rowsStartIndex, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // Apply to all internal grid lines (horizontal and vertical)
                worksheet.Range(1, 1, rowsStartIndex, 10).Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // 5. Save as a new file to keep the template intact
                workbook.SaveAs(filePath);
            }

            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(filePath);
            }
        }

        /*
        public static void GenerateDiary(DiaryDto[] rows, string docPath)
        {
            Word.Application wApp = new Word.Application
            {
                ScreenUpdating = false,
                Visible = false
            };

            Word.Documents wDocs = wApp.Documents;
            Word.Document wDoc = wDocs.Open(docPath, ReadOnly: true, Visible: false);

            var table = wDoc.Tables[1];

            var rowsStartIndex = 3;
            var rowsCounter = 1;

            table.Rows[1].HeadingFormat = -1;
            table.Rows[2].HeadingFormat = -1;

            foreach (var service in rows)
            {
                table.Rows.Add();

                table.Rows[rowsStartIndex].HeadingFormat = 0;
                table.Rows[rowsStartIndex].Range.Font.Size = 11;

                table.Rows[rowsStartIndex].Cells[1].Range.Text = (rowsCounter).ToString();

                table.Rows[rowsStartIndex].Cells[2].Range.Text = service.Date;

                table.Rows[rowsStartIndex].Cells[3].Range.Text = service.UnitWeightType;

                table.Rows[rowsStartIndex].Cells[4].Range.Text = service.UnitModel;

                table.Rows[rowsStartIndex].Cells[5].Range.Text = "";

                table.Rows[rowsStartIndex].Cells[6].Range.Text = service.ServiceType;

                table.Rows[rowsStartIndex].Cells[7].Range.Text = service.Sticker;

                table.Rows[rowsStartIndex].Cells[8].Range.Text = service.TradeNameFoam;

                table.Rows[rowsStartIndex].Cells[9].Range.Text = service.DataNext;

                rowsCounter++;
                rowsStartIndex++;
            }

            wApp.ScreenUpdating = true;
            wApp.Visible = true;
            wApp.Activate();
        }
        */

        private static void SearchAndReplace(Word.Document doc, string find, string replace)
        {
            foreach (Word.Range tmpRange in doc.StoryRanges)
            {
                // Set the text to find and replace
                tmpRange.Find.Text = find;
                tmpRange.Find.Replacement.Text = replace;

                // Set the Find.Wrap property to continue (so it doesn't
                // prompt the user or stop when it hits the end of
                // the section)
                tmpRange.Find.Wrap = Word.WdFindWrap.wdFindContinue;

                // Declare an object to pass as a parameter that sets
                // the Replace parameter to the "wdReplaceAll" enum
                object replaceAll = Word.WdReplace.wdReplaceAll;

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
