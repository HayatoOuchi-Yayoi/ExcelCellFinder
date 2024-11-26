using System.IO;

namespace ExcelCellFinder.Desktop.Services.CollectFileList
{
    /// <summary>
    /// 検索対象ファイルリスト収集インターフェース
    /// </summary>
    internal interface ICollectFileListService
    {
        /// <summary>
        /// 検索対象ファイルリストを収集する
        /// </summary>
        /// <param name="csv">検索対象ファイルが記載されたCSVファイル</param>
        /// <returns>検索対象ファイルリスト</returns>
        public IEnumerable<FileInfo> CollectFileList(FileInfo csv);
    }
}
