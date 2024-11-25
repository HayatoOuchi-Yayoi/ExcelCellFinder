using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Result
{
    /// <summary>
    /// 検索実行ファイル情報クラス
    /// </summary>
    internal class ResultFile : IResultFile
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileInfo">ファイル情報</param>
        internal ResultFile(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            FoundCells = [];
        }

        public FileInfo FileInfo { get; set; }
        public IList<IFoundCell> FoundCells { get; set; }
    }
}
