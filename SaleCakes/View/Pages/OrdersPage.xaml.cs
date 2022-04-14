using System.Linq;
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
    private ComponentsCakeWindow _componentsCakeWindow;

    public OrdersPage(OrderViewModel orderViewModel, ComponentsCakeWindow componentsCakeWindow)
    {
        _orderViewModel = orderViewModel;
        _componentsCakeWindow = componentsCakeWindow;
        InitializeComponent();
        DataContext = _orderViewModel;
        _orderViewModel.HiddenColumnsEvent += _orderViewModel_HiddenColumnsEvent;
    }

    private void _orderViewModel_HiddenColumnsEvent()
    {
        var boolean = (Application.Current as App).RoleUser is "Продавец";

        if (boolean is false)
        {
            _ = GridView2.Columns.Remove(GridView2.Columns.Last());
        }
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void Show_Component_OnClick(object sender, RoutedEventArgs e)
    {
        _componentsCakeWindow.Show();
        _componentsCakeWindow = new ComponentsCakeWindow();
    }
}