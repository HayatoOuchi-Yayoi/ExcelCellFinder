using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result.Interface;

namespace ExcelCellFinder.Desktop.Services.FindCell
{
    public interface IFindCellService
    {
        public IResult FindCell(IFindCellOptions options);
    }
}
