using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для ClientsPage.xaml
/// </summary>
public partial class ClientsPage : Page
{
    public ClientsPage()
    {
        InitializeComponent();
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService?.GoBack();
    }

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }
}