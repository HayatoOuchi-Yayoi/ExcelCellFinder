using ExcelCellFinder.Core.Options.Interface;

namespace ExcelCellFinder.Core.Options
{
    public class OptionFactory
    {
        public static IFindCellOptions GetOption()
        {
            return new FindCellOptions();
        }
    }
}
