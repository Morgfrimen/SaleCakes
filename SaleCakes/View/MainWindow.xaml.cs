using System.Windows;
using System.Windows.Input;
using SaleCakes.View.Pages;
using SaleCakes.ViewModel;

namespace SaleCakes.View;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly CakesPage _cakesPage;
    private readonly ClientsPage _clientsPage;
    private readonly DecorPage _decorPage;
    private readonly EmployeePage _employeePage;
    private readonly MainWindowViewModel _mainWindow;
    private readonly OrdersPage _ordersPage;

    public MainWindow(CakesPage cakesPage, EmployeePage employeePage, ClientsPage clientsPage, DecorPage decorPage, OrdersPage ordersPage, MainWindowViewModel mainWindow)
    {
        _cakesPage = cakesPage;
        _employeePage = employeePage;
        _clientsPage = clientsPage;
        _decorPage = decorPage;
        _ordersPage = ordersPage;
        _mainWindow = mainWindow;
        DataContext = _mainWindow;
        InitializeComponent();
    }

    private void NavigateToCakesPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) FrameMenuPage.NavigationService.GoBack();

        _ = FrameMenuPage.Navigate(_cakesPage);
    }

    private void NavigateToClientsPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) FrameMenuPage.NavigationService.GoBack();

        _ = FrameMenuPage.Navigate(_clientsPage);
    }

    private void NavigateToDecorsPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) FrameMenuPage.NavigationService.GoBack();

        _ = FrameMenuPage.Navigate(_decorPage);
    }

    private void NavigateToOrdersPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) FrameMenuPage.NavigationService.GoBack();

        _ = FrameMenuPage.Navigate(_ordersPage);
    }

    private void NavigateToEmployeesPageOnClick(object sender, RoutedEventArgs e)
    {
        while (FrameMenuPage.NavigationService.CanGoBack) FrameMenuPage.NavigationService.GoBack();

        _ = FrameMenuPage.Navigate(_employeePage);
    }

    private void Exit(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown(0);
    }

    private void MainWindow_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }
}