using ExcelCellFinder.Core.Options.Interface;

namespace ExcelCellFinder.Core.Options
{
    /// <summary>
    /// セル検索オプションファクトリ
    /// </summary>
    public class OptionFactory
    {
        /// <summary>
        /// セル検索オプション取得
        /// </summary>
        /// <returns>セル検索オプションインスタンス</returns>
        public static IFindCellOptions GetOption()
        {
            return new FindCellOptions();
        }
    }
}
