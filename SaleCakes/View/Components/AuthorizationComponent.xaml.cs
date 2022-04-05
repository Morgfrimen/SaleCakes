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
    private RegistrationWindow _registrationWindow;
    private RegistrationViewModel _vm;

    public AuthorizationComponent()
    {
        _registrationWindow = (App.Current as App).ServiceProvider.GetService<RegistrationWindow>()!;
        _vm = _registrationWindow.DataContext as RegistrationViewModel;
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm)
        {
            return;
        }

        vm.VisibilityAutorized = Visibility.Collapsed;
        vm.VisibilityMenu = Visibility.Visible;
        vm.ResizeModeMainWindow = ResizeMode.CanResizeWithGrip;
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
}