namespace ExcelCellFinder.Core.Result.Interface
{
    public interface IFoundCell
    {
        string SheetName { get; protected set; }
        int RowNumber { get; protected set; }
        int ColumnNumber { get; protected set; }
        string Column { get; protected set; }
        string ErrorMessage { get; protected set; }

        string ToString();

        string GetCellName();
    }
}
