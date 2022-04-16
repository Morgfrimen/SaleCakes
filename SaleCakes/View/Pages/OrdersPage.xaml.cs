using System;
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
    private int _selectedIndex;


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

    private void listOrdersView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        OrderViewModel orderViewModel = new OrderViewModel();
        _selectedIndex = listOrdersView.SelectedIndex;
        orderViewModel.ItemId = _selectedIndex;
        cakeNameTextBox.Text = orderViewModel.Orders[orderViewModel.ItemId].OrderCakeTitle.ToString();
        cakeAddressTextBox.Text = orderViewModel.Orders[orderViewModel.ItemId].OrderAdress.ToString();
        cakePriceTextBox.Text = orderViewModel.Orders[orderViewModel.ItemId].Price.ToString();
        cakeIdTextBox.Text = orderViewModel.Orders[orderViewModel.ItemId].Id.ToString();
    }

    //private void Button_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    //{
    //    OrderViewModel orderViewModel = new OrderViewModel();
    //    orderViewModel.DeleteOrders(sender, Convert.ToInt32(cakeIdTextBox.Text));
    //}


    private void Button_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        foreach (ListViewItem item in listOrdersView.SelectedItems)
        {
            listOrdersView.Items.Remove(item);
        }
    }
}