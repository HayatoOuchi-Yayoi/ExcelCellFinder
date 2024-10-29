using ExcelCellFinder.Core.Logic.FindCell.Bulk;
using ExcelCellFinder.Core.Options.Interface;
using Microsoft.Extensions.Logging;

namespace ExcelCellFinder.Core.Logic.FindCell
{
    public class FindCellLogicFactory()
    {
        public static IFindCellLogic GetLogic(IFindCellOptions options)
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddDebug());
            ILogger logger = factory.CreateLogger("ExcelCellFinder.Core.DefaultLogger");

            return GetLogic(options, logger);
        }

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
