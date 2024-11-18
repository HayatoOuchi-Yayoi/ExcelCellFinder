using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System.Windows;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ExcelCellFinder.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static ILogger Logger { get; private set; }

        static App()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddNLog();
            });

            Logger = loggerFactory.CreateLogger<App>();
        }

        public App()
        {
            Logger.LogInformation("Application started.");
        }
    }

}
