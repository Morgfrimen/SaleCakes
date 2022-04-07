using System.Windows;
using System.Windows.Controls;
using SaleCakes.ViewModel;

namespace SaleCakes.View.Pages;

/// <summary>
///     Логика взаимодействия для OrdersPage.xaml
/// </summary>
public partial class OrdersPage : Page
{
    private readonly OrderViewModel _orderViewModel;

    public OrdersPage(OrderViewModel orderViewModel)
    {
        _orderViewModel = orderViewModel;
        InitializeComponent();
        DataContext = _orderViewModel;
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
}