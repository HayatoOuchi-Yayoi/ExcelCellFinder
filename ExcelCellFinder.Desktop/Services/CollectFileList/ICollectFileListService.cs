using System.IO;

namespace ExcelCellFinder.Desktop.Services.CollectFileList
{
    internal interface ICollectFileListService
    {
        public IEnumerable<FileInfo> CollectFileList(FileInfo csv);
    }
}
