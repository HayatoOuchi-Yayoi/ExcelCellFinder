using ExcelCellFinder.Core.Options;
using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result;
using ExcelCellFinder.Core.Result.Interface;
using Microsoft.Extensions.Logging;

namespace ExcelCellFinder.Core.Logic.FindCell.Bulk
{
    /// <summary>
    /// ファイルリスト指定セル検索ロジック
    /// </summary>
    internal class FindCellWithFileListLogic : IFindCellLogic
    {
        private readonly IFindCellOptions _originalOption;

        private readonly ILogger _logger;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="options">検索オプション</param>
        /// <param name="logger">ロガーインスタンス</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal FindCellWithFileListLogic(IFindCellOptions options, ILogger logger)
        {
            if (options.Mode != TargetMode.FileList)
            {
                throw new InvalidOperationException("Mode must be FileList");
            }

            if (options.TargetFileInfos == null)
            {
                throw new ArgumentException("TargetFileInfos must not be null.");
            }

            _originalOption = options;
            _logger = logger;
        }

        /// <summary>
        /// セル検索処理
        /// </summary>
        /// <returns>検索結果</returns>
        public IResult FindCell()
        {
            if (_originalOption.TargetFileInfos == null)
            {
                throw new ArgumentNullException(nameof(_originalOption.TargetFileInfos));
            }

            var files = _originalOption.TargetFileInfos
                .Where(x => x.Extension == ".xlsx" || x.Extension == ".xlsm");

            IResult wholeResult = new FindCellResult(_originalOption, false);

            var optionForFindCellInFile = OptionFactory.GetOption();
            optionForFindCellInFile.Mode = TargetMode.File;
            optionForFindCellInFile.TargetCellTypes = _originalOption.TargetCellTypes;

            foreach (var file in files)
            {
                optionForFindCellInFile.TargetFileInfo = file;
                var logic = FindCellLogicFactory.GetLogic(optionForFindCellInFile, _logger);
                var findResult = logic.FindCell();

                wholeResult = wholeResult.Merge(findResult);
            }

            return wholeResult;
        }
    }
}
