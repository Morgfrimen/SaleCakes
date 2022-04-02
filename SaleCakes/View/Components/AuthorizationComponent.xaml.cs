using SaleCakes.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Components;

/// <summary>
///     Логика взаимодействия для AuthorizationComponent.xaml
/// </summary>
public partial class AuthorizationComponent : UserControl
{
    public AuthorizationComponent()
    {
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
    }
}