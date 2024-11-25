using System.Text.RegularExpressions;

namespace ExcelCellFinder.Core.Options.Interface
{
    /// <summary>
    /// セル検索オプションインタフェース
    /// </summary>
    public interface IFindCellOptions
    {
        /// <summary>
        /// 検索対象ファイル情報
        /// </summary>
        public FileInfo? TargetFileInfo { get; set; }
        /// <summary>
        /// 検索対象フォルダ情報
        /// </summary>
        public DirectoryInfo? TargetDirectoryInfo { get; set; }
        /// <summary>
        /// 検索対象ファイル情報リスト
        /// </summary>
        public IEnumerable<FileInfo>? TargetFileInfos { get; set; }
        /// <summary>
        /// 検索方法
        /// </summary>
        public TargetMode Mode { get; set; }
        /// <summary>
        /// 再帰検索フラグ
        /// </summary>
        public bool IsRecursively { get; set; }
        /// <summary>
        /// 除外フォルダ正規表現
        /// </summary>
        public Regex? ExcludeDirectoryRegex { get; set; }
        /// <summary>
        /// 検索対象セルタイプ
        /// </summary>
        public IEnumerable<TargetCellType> TargetCellTypes { get; set; }

        /// <summary>
        /// オプションバリデーション処理
        /// </summary>
        /// <returns></returns>
        public bool IsValidOption();
    }

    /// <summary>
    /// 検索対象セルタイプ
    /// </summary>
    public enum TargetCellType
    {
        RedColor,
        StrikeLine
    }

    /// <summary>
    /// 検索方法
    /// </summary>
    public enum TargetMode
    {
        File,
        Directory,
        FileList
    }
}
