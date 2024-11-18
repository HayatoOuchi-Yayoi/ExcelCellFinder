using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Result
{
    internal class ResultFile : IResultFile
    {
        internal ResultFile(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            FoundCells = [];
        }

        public FileInfo FileInfo { get; set; }
        public IList<IFoundCell> FoundCells { get; set; }
    }
}
