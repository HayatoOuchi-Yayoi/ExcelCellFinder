using ExcelCellFinder.Core.Result.Interface;
using Microsoft.Extensions.Logging;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    public interface IFindCellLogic
    {
        public ILogger Logger { get; set; }

        public IResult FindCell();
    }
}
