using System.Windows;
using System.Windows.Controls;
using SaleCakes.ViewModel;

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
        var vm = DataContext as MainWindowViewModel;

        if (vm is null)
        {
            return;
        }

        vm.VisibilityAutorized = Visibility.Collapsed;
        vm.VisibilityMenu = Visibility.Visible;
    }
}