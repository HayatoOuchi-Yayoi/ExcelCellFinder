namespace ExcelCellFinder.Core.Result.Interface
{
    public interface IResultFile
    {
        FileInfo FileInfo { get; protected set; }

        IList<IFoundCell> FoundCells { get; protected set; }
    }
}
