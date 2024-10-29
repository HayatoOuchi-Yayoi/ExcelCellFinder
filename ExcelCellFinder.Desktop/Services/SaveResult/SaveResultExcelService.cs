using ExcelCellFinder.Core.Logic.FindCell;
using ExcelCellFinder.Core.Result.Interface;
using System.IO;

namespace ExcelCellFinder.Desktop.Services.SaveResult
{
    internal class SaveResultExcelService : ISaveResultService
    {
        public string? SaveFilePath { get; set; }

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
