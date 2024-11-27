namespace ExcelCellFinder.Core.Exceptions
{
    /// <summary>
    /// 処理不能なセルが発生した場合の例外クラス
    /// </summary>
    /// <param name="message"></param>
    internal class NotOperatableCellException(string message) : Exception(message)
    {
    }
}
