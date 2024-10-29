using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExcelCellFinder.Core.Options;
using ExcelCellFinder.Core.Options.Interface;
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
    public partial class SetupConditionPageViewModel : PageViewModelBase
    {
        public SetupConditionPageViewModel()
        {
            PageTitle = "条件設定";
            _findFolderPath = "";
        }

        private static readonly string BUTTON_CONTENT_CSV = "CSVファイルを選択";
        private static readonly string BUTTON_CONTENT_DIRECTORY = "フォルダを選択";

        [ObservableProperty]
        private string _findFolderPath;

        [ObservableProperty]
        private bool _isRecursively = true;

        [ObservableProperty]
        private string _excludeDirectoryRegex = "";

        private bool _isUseFileListCsv = true;
        public bool IsUseFileListCsv
        {
            get { return _isUseFileListCsv; }
            set
            {
                SetProperty(ref _isUseFileListCsv, value);
                IsProcessDirectory = !value;

                OpenSelectPathButtonContent = value ? BUTTON_CONTENT_CSV : BUTTON_CONTENT_DIRECTORY;
            }
        }

        [ObservableProperty]
        private bool _isProcessDirectory;

        [ObservableProperty]
        private string _openSelectPathButtonContent = BUTTON_CONTENT_CSV;

        [RelayCommand]
        private void SelectPath()
        {
            var dialog = new CommonOpenFileDialog(IsUseFileListCsv ? "ファイルを選択" : "フォルダを選択")
            {
                IsFolderPicker = IsUseFileListCsv == false
            };

            if (IsUseFileListCsv)
            {
                dialog.Filters.Add(new CommonFileDialogFilter("CSVファイル", "*.csv"));
            }

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FindFolderPath = dialog.FileName;
            }
        }

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

            if (IsUseFileListCsv)
            {
                option.TargetFileInfos = CollectFileListServiceFactory.GetService().CollectFileList(new FileInfo(FindFolderPath));
                option.Mode = TargetMode.FileList;
            }
            else
            {
                option.TargetDirectoryInfo = new System.IO.DirectoryInfo(FindFolderPath);
                option.Mode = TargetMode.Directory;
                option.IsRecursively = IsRecursively;
                option.ExcludeDirectoryRegex = string.IsNullOrEmpty(ExcludeDirectoryRegex) ? null : new Regex(ExcludeDirectoryRegex);
            }

            option.TargetCellTypes = new[] { TargetCellType.RedColor, TargetCellType.StrikeLine };

            return option;
        }
    }
}
