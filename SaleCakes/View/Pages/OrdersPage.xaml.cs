using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для OrdersPage.xaml
/// </summary>
public partial class OrdersPage : Page
{
    public OrdersPage()
    {
        InitializeComponent();
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void ButtonEdit_Click(object sender, RoutedEventArgs e)
    {
    }
}