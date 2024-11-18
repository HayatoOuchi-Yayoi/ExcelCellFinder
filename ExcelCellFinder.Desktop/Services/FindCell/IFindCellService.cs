using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Desktop.Services.FindCell
{
    /// <summary>
    /// セル検索インターフェース
    /// </summary>
    public interface IFindCellService
    {
        /// <summary>
        /// セルを検索する
        /// </summary>
        /// <param name="options">検索オプション</param>
        /// <returns>検索結果</returns>
        public IResult FindCell(IFindCellOptions options);
    }
}
