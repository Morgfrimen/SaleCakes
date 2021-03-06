using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using SaleCakes.ViewModel;

namespace SaleCakes.View.Components;

/// <summary>
///     Логика взаимодействия для AuthorizationComponent.xaml
/// </summary>
public partial class AuthorizationComponent : UserControl
{
    private readonly RegistrationViewModel _vm;
    private RegistrationWindow _registrationWindow;

    public AuthorizationComponent()
    {
        _registrationWindow = (Application.Current as App).ServiceProvider.GetService<RegistrationWindow>()!;
        _vm = _registrationWindow.DataContext as RegistrationViewModel;
        DataContext = (Application.Current as App).ServiceProvider.GetService<MainWindowViewModel>();
        InitializeComponent();
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown(0);
    }

    private void Registration_OnClick(object sender, RoutedEventArgs e)
    {
        _registrationWindow = new RegistrationWindow(_vm);
        _registrationWindow.Show();
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext != null)
        {
            ((MainWindowViewModel)DataContext).AuthorizedViewModel.Password = ((PasswordBox)sender).Password;
        }
    }
}