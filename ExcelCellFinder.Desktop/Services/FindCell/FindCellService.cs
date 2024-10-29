using ExcelCellFinder.Core.Logic.FindCell;
using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Desktop.Services.FindCell
{
    internal class FindCellService : IFindCellService
    {
        public IResult FindCell(IFindCellOptions options)
        {
            var logic = FindCellLogicFactory.GetLogic(options, App.Logger);

            return logic.FindCell();
        }
    }
}
