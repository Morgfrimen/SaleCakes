using System.Windows;
using System.Windows.Controls;
using SaleCakes.View;

namespace SaleCakes.Pages;

/// <summary>
///     Логика взаимодействия для MainMenu.xaml
/// </summary>
public partial class MainMenu : Page
{
    public MainMenu()
    {
        InitializeComponent();
    }

    private void ButtonOrders_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Orders());
    }

    private void ButtonClients_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Clients());
    }

    private void ButtonDecor_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Decor());
    }

    private void ButtonEmployee_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Employee());
    }

    private void ButtonCakes_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Cakes());
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var EmployeeAddView = new EmployeeAddView();
        EmployeeAddView.Show();
    }
}