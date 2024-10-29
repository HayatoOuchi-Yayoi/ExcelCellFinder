using ExcelCellFinder.Core.Logic.SaveResult;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    public class SaveResultLogicFactory()
    {
        public static ISaveResultLogic GetLogic()
        {
            return new SaveResultLogic();
        }
    }
}
