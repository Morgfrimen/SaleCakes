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
    private ComponentsCake _componentsCake;

    public OrdersPage(OrderViewModel orderViewModel,ComponentsCake componentsCake)
    {
        _orderViewModel = orderViewModel;
        _componentsCake = componentsCake;
        InitializeComponent();
        DataContext = _orderViewModel;
        _orderViewModel.HiddenColumnsEvent += _orderViewModel_HiddenColumnsEvent;
    }

    private void _orderViewModel_HiddenColumnsEvent()
    {
        var boolean = (App.Current as App).RoleUser is "Продавец";
        if(boolean is false)
            GridView2.Columns.Remove(GridView2.Columns.Last());
    }

    private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void Show_Component_OnClick(object sender, RoutedEventArgs e)
    {
        _componentsCake.Show();
        _componentsCake = new ComponentsCake();
    }
}