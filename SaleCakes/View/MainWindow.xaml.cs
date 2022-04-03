using System.Windows;
using System.Windows.Navigation;
using SaleCakes.View.Components;
using SaleCakes.View.Pages;

namespace SaleCakes.View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly CakesPage _cakesPage;
    private readonly EmployeePage _employeePage;
    private readonly ClientsPage _clientsPage;
    private readonly DecorPage _decorPage;
    private readonly OrdersPage _ordersPage;

    public MainWindow(CakesPage cakesPage, EmployeePage employeePage, ClientsPage clientsPage, DecorPage decorPage, OrdersPage ordersPage)
    {
        _cakesPage = cakesPage;
        _employeePage = employeePage;
        _clientsPage = clientsPage;
        _decorPage = decorPage;
        _ordersPage = ordersPage;
        InitializeComponent();
    }

    private void NavigateToCakesPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) 
            FrameMenuPage.NavigationService.GoBack();
        _ = FrameMenuPage.Navigate(_cakesPage);

    }

    private void NavigateToClientsPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack)
            FrameMenuPage.NavigationService.GoBack();
        _ = FrameMenuPage.Navigate(_clientsPage);

    }

    private void NavigateToDecorsPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack)
            FrameMenuPage.NavigationService.GoBack();
        _ = FrameMenuPage.Navigate(_decorPage);

    }

    private void NavigateToOrdersPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack)
            FrameMenuPage.NavigationService.GoBack();
        _ = FrameMenuPage.Navigate(_ordersPage);

    }

    private void NavigateToEmployeesPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack)
            FrameMenuPage.NavigationService.GoBack();
        _ = FrameMenuPage.Navigate(_employeePage);

    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        App.Current.Shutdown(0);
    }
}