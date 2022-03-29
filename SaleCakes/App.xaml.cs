using System.Configuration;
using System.Windows;

namespace SaleCakes;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string DefaultConnectionString = "Server=.\\SQLEXPRESS;Database=SaleCakes;Trusted_Connection=true;";

    protected override void OnStartup(StartupEventArgs e)
    {
        DispatcherUnhandledException += GlobalErrorsEvent;

        CheckConfig();
    }

    private static void CheckConfig()
    {
        var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var settings = configFile.AppSettings.Settings;

        if (settings[SaleCakes.Properties.Resources.Config_Key_ConnectionString] == null)
        {
            settings.Add(SaleCakes.Properties.Resources.Config_Key_ConnectionString, DefaultConnectionString);
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }

    private static void GlobalErrorsEvent(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show(SaleCakes.Properties.Resources.Message_Global_Error, SaleCakes.Properties.Resources.Title_MessageBox_Error,
            MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
    }
}