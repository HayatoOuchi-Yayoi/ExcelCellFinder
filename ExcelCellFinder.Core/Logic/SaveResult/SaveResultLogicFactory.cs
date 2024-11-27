using ExcelCellFinder.Core.Logic.SaveResult;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    /// <summary>
    /// 検索結果保存ロジックファクトリ
    /// </summary>
    public class SaveResultLogicFactory()
    {
        /// <summary>
        /// 検索結果保存ロジック取得
        /// </summary>
        /// <returns>検索結果保存ロジック</returns>
        public static ISaveResultLogic GetLogic()
        {
            return new SaveResultLogic();
        }
    }
}
