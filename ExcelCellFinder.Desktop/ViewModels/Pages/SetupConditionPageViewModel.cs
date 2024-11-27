using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExcelCellFinder.Core.Options;
using ExcelCellFinder.Core.Options.Interface;
using ExcelCellFinder.Desktop.Models;
using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.Services.CollectFileList;
using ExcelCellFinder.Desktop.Services.FindCell;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace ExcelCellFinder.Desktop.ViewModels.Pages
{
    /// <summary>
    /// 検索条件設定画面のViewModel
    /// </summary>
    public partial class SetupConditionPageViewModel : PageViewModelBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SetupConditionPageViewModel()
        {
            PageTitle = "条件設定";
            FindFolderPath = "";
            SelectedTargetFileSelectionType = TargetFileSelectionType.フォルダを指定;
        }

        private static readonly string BUTTON_CONTENT_CSV = "CSVファイルを選択";
        private static readonly string BUTTON_CONTENT_DIRECTORY = "フォルダを選択";
        private static readonly string BUTTON_CONTENT_SPECIFIC_FILE = "ファイルを選択";

        /// <summary>
        /// 検索対象パス
        /// </summary>
        [ObservableProperty]
        private string _findFolderPath;

        /// <summary>
        /// サブフォルダ検索フラグ
        /// </summary>
        [ObservableProperty]
        private bool _isRecursively = true;

        /// <summary>
        /// 除外対象フォルダ正規表現
        /// </summary>
        [ObservableProperty]
        private string _excludeDirectoryRegex = "";

        /// <summary>
        /// CSVファイルで指定フラグ
        /// </summary>
        [ObservableProperty]
        private bool _isUseFileListCsv;

        /// <summary>
        /// フォルダを指定フラグ
        /// </summary>
        [ObservableProperty]
        private bool _isProcessDirectory;

        /// <summary>
        /// ファイルを指定フラグ
        /// </summary>
        [ObservableProperty]
        private bool _isSpecificFile;

        /// <summary>
        /// ファイル選択ボタンの表示内容
        /// </summary>
        [ObservableProperty]
        private string _openSelectPathButtonContent = BUTTON_CONTENT_CSV;

        /// <summary>
        /// 検索対象ファイル選択方法プルダウン選択肢
        /// </summary>
        public static IEnumerable<TargetFileSelectionType> TargetFileSelectionTypes => Enum.GetValues<TargetFileSelectionType>();

        /// <summary>
        /// 検索対象ファイル選択方法プルダウン選択値
        /// </summary>
        public TargetFileSelectionType SelectedTargetFileSelectionType
        {
            get { return _selectedTargetFileSelectionType; }
            set
            {
                SetProperty(ref _selectedTargetFileSelectionType, value);

                switch (value)
                {
                    case TargetFileSelectionType.CSVファイルで指定:
                        IsUseFileListCsv = true;
                        IsProcessDirectory = false;
                        OpenSelectPathButtonContent = BUTTON_CONTENT_CSV;
                        break;
                    case TargetFileSelectionType.フォルダを指定:
                        IsUseFileListCsv = false;
                        IsProcessDirectory = true;
                        OpenSelectPathButtonContent = BUTTON_CONTENT_DIRECTORY;
                        break;
                    case TargetFileSelectionType.ファイルを指定:
                        IsUseFileListCsv = false;
                        IsProcessDirectory = false;
                        OpenSelectPathButtonContent = BUTTON_CONTENT_SPECIFIC_FILE;
                        break;
                }
            }
        }
        private TargetFileSelectionType _selectedTargetFileSelectionType = TargetFileSelectionType.CSVファイルで指定;

        /// <summary>
        /// 検索対象パスを設定する
        /// </summary>
        [RelayCommand]
        private void SelectPath()
        {
            CommonOpenFileDialog dialog;

            switch (SelectedTargetFileSelectionType)
            {
                case TargetFileSelectionType.CSVファイルで指定:
                    dialog = new CommonOpenFileDialog("CSVファイルを選択")
                    {
                        Filters = { new CommonFileDialogFilter("CSVファイル", "*.csv") }
                    };
                    break;
                case TargetFileSelectionType.フォルダを指定:
                    dialog = new CommonOpenFileDialog("フォルダを選択")
                    {
                        IsFolderPicker = true
                    };
                    break;
                case TargetFileSelectionType.ファイルを指定:
                    dialog = new CommonOpenFileDialog("ファイルを選択")
                    {
                        Filters =
                        {
                            new CommonFileDialogFilter("EXCELファイル", "*.xlsx,*.xlsm")
                        }
                    };
                    break;
                default:
                    return;
            }

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FindFolderPath = dialog.FileName;
            }
        }

        /// <summary>
        /// セル検索処理を実行する
        /// </summary>
        [RelayCommand]
        private void ExecuteSearch()
        {
            if (string.IsNullOrEmpty(FindFolderPath))
            {
                return;
            }

            try
            {
                var service = FindCellServiceFactory.GetService();
                var result = service.FindCell(CreateOption());

                RoutingService.Instance.MoveTo(new FindResultPageViewModel(result, this));
            }
            catch (Exception e)
            {
                App.Logger.LogError(e, "検索処理中にエラーが発生しました");

                // MVVM的にはMessageBoxをViewModelで呼び出すのは避けるべきだが・・・
                MessageBox.Show(e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private IFindCellOptions CreateOption()
        {
            var option = OptionFactory.GetOption();

            switch (SelectedTargetFileSelectionType)
            {
                case TargetFileSelectionType.CSVファイルで指定:
                    option.TargetFileInfos = CollectFileListServiceFactory.GetService().CollectFileList(new FileInfo(FindFolderPath));
                    option.Mode = TargetMode.FileList;
                    break;

                case TargetFileSelectionType.フォルダを指定:
                    option.TargetDirectoryInfo = new System.IO.DirectoryInfo(FindFolderPath);
                    option.Mode = TargetMode.Directory;
                    option.IsRecursively = IsRecursively;
                    option.ExcludeDirectoryRegex = string.IsNullOrEmpty(ExcludeDirectoryRegex) ? null : new Regex(ExcludeDirectoryRegex);
                    break;

                case TargetFileSelectionType.ファイルを指定:
                    option.TargetFileInfo = new System.IO.FileInfo(FindFolderPath);
                    option.Mode = TargetMode.File;
                    break;
            }

            option.TargetCellTypes = new[] { TargetCellType.RedColor, TargetCellType.StrikeLine };

            return option;
        }
    }
}
