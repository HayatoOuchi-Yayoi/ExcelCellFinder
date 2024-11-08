﻿using ClosedXML.Excel;
using ExcelCellFinder.Core.Exceptions;
using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result;
using ExcelCellFinder.Core.Result.Interface;
using Microsoft.Extensions.Logging;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    internal class FindCellWithSingleFileLogic : IFindCellLogic
    {
        private IFindCellOptions _originalOptions;
        private string _path;

        public ILogger Logger { get; set; }

        internal FindCellWithSingleFileLogic(IFindCellOptions options, ILogger logger)
        {
            if (options.Mode != TargetMode.File)
            {
                throw new InvalidOperationException("Mode must be File");
            }

            if (options.TargetFileInfo == null)
            {
                throw new ArgumentNullException(nameof(options.TargetFileInfo));
            }

            this._originalOptions = options;
            this._path = options.TargetFileInfo.FullName;

            Logger = logger;
        }

        public IResult FindCell()
        {
            // Excelファイルを開く
            using var fs = new FileStream(this._path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var workbook = new XLWorkbook(fs))
            {
                Logger.LogInformation($"Open Excel File: {this._path}");

                workbook.CalculateMode = XLCalculateMode.Manual;

                var foundCells = new List<(IXLCell, Exception?)>();
                foreach (var sheet in workbook.Worksheets.Where(x => x.Visibility == XLWorksheetVisibility.Visible))
                {
                    Logger.LogInformation($"Open Excel Sheet: {sheet.Name}");

                    if (this._originalOptions.TargetCellTypes.Contains(TargetCellType.RedColor)
                        && this._originalOptions.TargetCellTypes.Contains(TargetCellType.StrikeLine))
                    {
                        foundCells.AddRange(GetCellsWithRedFontOrStrikethrough(sheet));
                    }
                }

                IResult result = new FindCellResult(_originalOptions, false);
                result.ProcessedFiles.Add(new ResultFile(new FileInfo(this._path))
                {
                    FoundCells = foundCells.Select(cell =>
                    {
                        if (cell.Item2 != null)
                        {
                            return new FoundCell(cell.Item1, cell.Item2);
                        }

                        return (IFoundCell)new FoundCell(cell.Item1);

                    }).ToList()
                });

                return result;
            }
        }
        public IEnumerable<(IXLCell, Exception?)> GetCellsWithRedFontOrStrikethrough(IXLWorksheet worksheet)
        {
            var cells = new List<(IXLCell, Exception?)>();
            var notOperatableCellAddresses = new List<IXLAddress>();

            Logger.LogInformation($"Used Cell Count: {worksheet.CellsUsed().Count()}");

            foreach (IXLCell cell in worksheet.CellsUsed())
            {
                if (cell.HasRichText == false) continue;

                try
                {
                    Logger.LogDebug(cell.Address.ToString());

                    if (IsOperatableCell(cell, notOperatableCellAddresses) == false)
                    {
                        notOperatableCellAddresses.Add(cell.Address);
                        throw new NotOperatableCellException("処理不可能または処理不可能なセルを参照しているセルです");
                    }

                    var richText = cell.GetRichText();
                    foreach (var rt in richText)
                    {
                        if (rt.FontColor == XLColor.Red || rt.Strikethrough)
                        {
                            cells.Add((cell, null));
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    cells.Add((cell, e));
                }
            }

            return cells;
        }

        private static bool IsOperatableCell(IXLCell cell, IEnumerable<IXLAddress> notOpertableCellAddresses)
        {
            // cell関数を含むセルは処理できない
            if (cell.HasFormula && cell.FormulaA1.Contains("cell", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            // 処理できないセルを参照しているセルも処理できない
            foreach (var address in notOpertableCellAddresses)
            {
                if (address.ToString() == null) continue;

                if (cell.HasFormula
                    && cell.FormulaA1.Contains(
                        address.ToString() ?? "",
                        StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
