using System.Windows;
using System.Windows.Controls;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для MainMenuPage.xaml
/// </summary>
public partial class MainMenuPage : Page
{
    private readonly CakesPage _cakesPagePage;

    public MainMenuPage(CakesPage cakesPagePage)
    {
        _cakesPagePage = cakesPagePage;
        InitializeComponent();
    }

    private void ButtonOrders_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new OrdersPage());
    }

    private void ButtonClients_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new ClientsPage());
    }

    private void ButtonDecor_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new DecorPage());
    }

    private void ButtonEmployee_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new EmployeePage());
    }

    private void ButtonCakes_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(_cakesPagePage);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var EmployeeAddView = new EmployeeAddView();
        EmployeeAddView.Show();
    }
}