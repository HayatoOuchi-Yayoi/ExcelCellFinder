using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    /// <summary>
    /// セル検索ロジックインタフェース
    /// </summary>
    public interface IFindCellLogic
    {
        /// <summary>
        /// セルを検索する
        /// </summary>
        /// <returns>検索結果</returns>
        public IResult FindCell();
    }
}
