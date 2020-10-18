using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Finance.ServiceClasses;
using Finance.ViewModels;
using Finance.Views;

namespace Finance
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            ConfigManager.Read();

            if (string.IsNullOrEmpty(ConfigManager.Config.PathDatabase))
            {
                var baseSelectionWindow = new BaseSelectionWindow();

                ShutdownMode = ShutdownMode.OnExplicitShutdown;

                var result = baseSelectionWindow.ShowDialog();

                if (result != true)
                {
                    Current.Shutdown();
                    return;
                }

                if (baseSelectionWindow.DataContext is BaseSelectionWindowViewModel baseSelectionWindowViewModel)
                {
                    if(string.IsNullOrEmpty(baseSelectionWindowViewModel.FilePath))
                    {
                        Current.Shutdown();
                        return;
                    }
                    
                    ConfigManager.Config.PathDatabase = baseSelectionWindowViewModel.FilePath;
                    ConfigManager.Save();
                }
            }

            StartupUri = new Uri("Views/MainWindow.xaml", UriKind.Relative);
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }
    }
}
