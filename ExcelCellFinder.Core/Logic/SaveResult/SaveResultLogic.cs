using ClosedXML.Excel;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Logic.SaveResult
{
    internal class SaveResultLogic : ISaveResultLogic
    {
        private static readonly int START_ROW = 2;
        private static readonly string TEMPLATE_WORKBOOK_PATH = "result_template.xlsm";

        public void SaveResult(IResult result, FileInfo saveTo)
        {
            if (saveTo.Exists)
            {
                saveTo.Delete();
            }

            var fs = new FileStream(TEMPLATE_WORKBOOK_PATH, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var workbook = new XLWorkbook(fs);

            var resultSheet = workbook.Worksheets.First();

            var writtenRows = WriteFoundCells(resultSheet, result);

            workbook.SaveAs(saveTo.FullName);
        }

        private static int WriteFoundCells(IXLWorksheet resultSheet, IResult foundResult)
        {
            var workRow = START_ROW;

            // 結果リスト
            foreach (var processedFile in foundResult.ProcessedFiles)
            {
                foreach (var foundCell in processedFile.FoundCells)
                {
                    resultSheet.Cell(workRow, 1).Value = processedFile.FileInfo.Name;
                    resultSheet.Cell(workRow, 2).Value = foundCell.SheetName;
                    resultSheet.Cell(workRow, 3).Value = foundCell.GetCellName();
                    resultSheet.Cell(workRow, 4).Value = "セルを開く";
                    resultSheet.Cell(workRow, 5).Value = foundCell.ErrorMessage;

                    // 全角括弧など特殊文字を含むシート名に対応するため
                    // リンクに設定するシート名はシングルクォートで囲む
                    var sheetNameWithQuote = $"'{foundCell.SheetName}'";

                    // セルへのリンクを設定する
                    var hyperlink = resultSheet.Cell(workRow, 4).CreateHyperlink();
                    hyperlink.ExternalAddress = new Uri($"file://{processedFile.FileInfo.FullName}#{sheetNameWithQuote}!{foundCell.GetCellName()}");
                    resultSheet.Cell(workRow, 4).SetHyperlink(hyperlink);

                    workRow++;
                }
            }

            return workRow;
        }
    }
}
