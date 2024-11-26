using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace ExcelCellFinder.Desktop.Services.CollectFileList
{
    /// <summary>
    /// 検索対象ファイルリスト収集サービス
    /// </summary>
    internal class CollectFileListService : ICollectFileListService
    {
        /// 
        /// <summary>
        /// 検索対象ファイルリストを収集する
        /// </summary>
        /// <param name="csv">検索対象ファイルが記載されたCSVファイル</param>
        /// <returns>検索対象ファイルリスト</returns>
        public IEnumerable<FileInfo> CollectFileList(FileInfo csv)
        {
            using var parser = new TextFieldParser(csv.FullName)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = [","],
            };

            while (!parser.EndOfData)
            {
                var fields = parser.ReadFields();
                if (fields == null)
                {
                    continue;
                }

                foreach (var field in fields)
                {
                    if (File.Exists(field))
                    {
                        yield return new FileInfo(field);
                    }
                }
            }
        }
    }
}
