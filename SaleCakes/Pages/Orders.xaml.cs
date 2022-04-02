using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.Pages;

/// <summary>
///     Логика взаимодействия для Orders.xaml
/// </summary>
public partial class Orders : Page
{
    public Orders()
    {
        InitializeComponent();
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new MainMenu());
    }

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }
}