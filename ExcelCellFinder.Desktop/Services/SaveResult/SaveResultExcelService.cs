using ExcelCellFinder.Core.Logic.FindCell;
using ExcelCellFinder.Core.Result.Interface;
using System.IO;

namespace ExcelCellFinder.Desktop.Services.SaveResult
{
    /// <summary>
    /// セル検索結果保存サービス
    /// </summary>
    internal class SaveResultExcelService : ISaveResultService
    {
        public string? SaveFilePath { get; set; }

        /// <summary>
        /// セル検索結果を保存する
        /// </summary>
        /// <param name="saveData">保存データ</param>
        public void SaveResult(IResult saveData)
        {
            if (string.IsNullOrEmpty(SaveFilePath))
            {
                throw new InvalidOperationException("SaveFilePath is not set");
            }

            var logic = SaveResultLogicFactory.GetLogic();
            logic.SaveResult(saveData, new FileInfo(SaveFilePath));
        }
    }
}
