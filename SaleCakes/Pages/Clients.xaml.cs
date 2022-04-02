using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.Pages;

/// <summary>
///     Логика взаимодействия для Clients.xaml
/// </summary>
public partial class Clients : Page
{
    public Clients()
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