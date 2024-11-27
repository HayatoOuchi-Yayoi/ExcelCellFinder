using ExcelCellFinder.Core.Logic.FindCell.Bulk;
using ExcelCellFinder.Core.Options.Interface;
using Microsoft.Extensions.Logging;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    /// <summary>
    /// セル検索ロジックファクトリ
    /// </summary>
    public class FindCellLogicFactory()
    {
        /// <summary>
        /// セル検索ロジック取得
        /// </summary>
        /// <param name="options">検索オプション</param>
        /// <returns>オプションに応じたセル検索ロジックインスタンス</returns>
        public static IFindCellLogic GetLogic(IFindCellOptions options)
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddDebug());
            ILogger logger = factory.CreateLogger("ExcelCellFinder.Core.DefaultLogger");

            return GetLogic(options, logger);
        }

        /// <summary>
        /// セル検索ロジック取得
        /// </summary>
        /// <param name="options">検索オプション</param>
        /// <param name="logger">ロガーインスタンス</param>
        /// <returns>オプションに応じたセル検索ロジックインスタンス</returns>
        public static IFindCellLogic GetLogic(IFindCellOptions options, ILogger logger)
        {
            if (options.Mode == TargetMode.File)
            {
                return new FindCellWithSingleFileLogic(options, logger);
            }
            else if (options.Mode == TargetMode.Directory)
            {
                return new FindCellWithDirectoryLogic(options, logger);
            }
            else if (options.Mode == TargetMode.FileList)
            {
                return new FindCellWithFileListLogic(options, logger);
            }
            else if (options.Mode == TargetMode.FileList)
            {
                return new FindCellWithFileListLogic(options, logger);
            }
            else
            {
                throw new InvalidOperationException("Invalid Mode");
            }
        }
    }
}
