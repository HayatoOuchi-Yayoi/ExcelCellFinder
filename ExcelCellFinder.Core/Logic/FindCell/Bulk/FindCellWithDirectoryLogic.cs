using ExcelCellFinder.Core.Options;
using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Core.Result.Interface;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace ExcelCellFinder.Core.Logic.FindCell.Bulk
{
    /// <summary>
    /// フォルダ指定セル検索ロジック
    /// </summary>
    internal class FindCellWithDirectoryLogic : IFindCellLogic
    {
        private readonly string _path;
        private readonly bool _isRecursively;
        private readonly Regex? _excludeDirectoryRegex;

        private readonly IFindCellOptions _originalOption;

        private readonly ILogger _logger;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="options">検索オプション</param>
        /// <param name="logger">ロガーインスタンス</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        internal FindCellWithDirectoryLogic(IFindCellOptions options, ILogger logger)
        {
            if (options.Mode != TargetMode.Directory)
            {
                throw new InvalidOperationException("Mode must be Directory");
            }

            if (options.TargetDirectoryInfo == null)
            {
                throw new ArgumentException("TargetDirectoryInfo must not be null.");
            }

            _path = options.TargetDirectoryInfo.FullName;
            _isRecursively = options.IsRecursively;
            _excludeDirectoryRegex = options.ExcludeDirectoryRegex;
            _originalOption = options;

            _logger = logger;
        }

        /// <summary>
        /// セル検索処理
        /// </summary>
        /// <returns>検索結果</returns>
        public IResult FindCell()
        {
            var processDirectory = new DirectoryInfo(_path);
            var searchOption = _isRecursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

            var files = processDirectory.GetFiles("*", searchOption).AsEnumerable();

            if (_excludeDirectoryRegex != null)
            {
                files = files.Where(
                    file => _excludeDirectoryRegex.IsMatch(file.DirectoryName ?? "") == false);
            }

            var option = OptionFactory.GetOption();
            option.Mode = TargetMode.FileList;
            option.TargetFileInfos = files;
            option.TargetCellTypes = _originalOption.TargetCellTypes;

            var logic = FindCellLogicFactory.GetLogic(option, _logger);

            return logic.FindCell();

        }
    }
}
