using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace ExcelCellFinder.Desktop.Services.CollectFileList
{
    internal class CollectFileListService : ICollectFileListService
    {
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
