using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExcelCellFinder.Core.Result.Interface;
using ExcelCellFinder.Desktop.Models;
using ExcelCellFinder.Desktop.Services;
using ExcelCellFinder.Desktop.Services.SaveResult;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace ExcelCellFinder.Desktop.ViewModels.Pages
{
    public partial class FindResultPageViewModel : PageViewModelBase
    {
        private readonly SetupConditionPageViewModel _originViewModel;

        private readonly IResult _findCellResult;

        [ObservableProperty]
        private ObservableCollection<FindResultGridItem> _findResultGridData;


        public FindResultPageViewModel(IResult findCellResult, SetupConditionPageViewModel origin)
        {
            PageTitle = "検索結果";
            _findCellResult = findCellResult;
            _originViewModel = origin;

            _findResultGridData = ConvertResultToGridData(findCellResult);
        }

        [RelayCommand]
        private void ReturnToSetupCondition()
        {
            RoutingService.Instance.MoveTo(_originViewModel);
        }

        [RelayCommand]
        private void SaveResult()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "マクロ有効Excelファイル|*.xlsm",
                DefaultExt = ".xlsm",
                FilterIndex = 1,
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                var saveFilePath = saveFileDialog.FileName;
                var service = SaveResultServiceFactory.GetService(saveFilePath);
                try
                {
                    service.SaveResult(this._findCellResult);
                }
                catch (Exception e)
                {
                    App.Logger.LogError(e, "結果ファイルの保存中にエラーが発生しました");

                    // MVVM的にはMessageBoxをViewModelで呼び出すのは避けるべきだが・・・
                    MessageBox.Show(e.Message, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private static ObservableCollection<FindResultGridItem> ConvertResultToGridData(IResult findCellResult)
        {
            var gridData = new ObservableCollection<FindResultGridItem>();

            foreach (var file in findCellResult.ProcessedFiles)
            {
                foreach (var cell in file.FoundCells)
                {
                    gridData.Add(new FindResultGridItem
                    {
                        ファイル = GetRelativePath(file.FileInfo, findCellResult.ExecutedOptions?.TargetDirectoryInfo),
                        シート名 = cell.SheetName,
                        セル = cell.GetCellName(),
                        エラーメッセージ = cell.ErrorMessage,
                    });
                }
            }

            return gridData;
        }

        private static string GetRelativePath(FileInfo fileInfo, DirectoryInfo? currentDirectory)
        {
            if (currentDirectory == null)
            {
                return fileInfo.FullName;
            }

            return fileInfo.FullName[(currentDirectory.FullName.Length + 1)..];
        }
    }
}
