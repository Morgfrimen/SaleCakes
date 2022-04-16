using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SaleCakes.Command;
using SaleCakes.Model;
using Xunit;

namespace SaleCakes.ViewModel;

public class OrderViewModel : BaseViewModel
{
    private Container _containerCommand;
    private OrderClientModel _orderNew;
    private OrderClientModel _orderItemId;
    private int _itemId;

    private ObservableCollection<OrderClientModel> _orders = new()
    {
        new OrderClientModel(Guid.NewGuid(),
            DateTime.Now,
            "Мсоква,Речная 34",
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "500") { OrderCakeTitle = "Панчо", Price = 300 },
        new OrderClientModel(Guid.NewGuid(),
            DateTime.Now,
            "Мсоква,Речная 34",
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "500") { OrderCakeTitle = "Напалеон", Price = 600 },
        new OrderClientModel(Guid.NewGuid(),
            DateTime.Now,
            "Мсоква,Речная 34",
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "500") { OrderCakeTitle = "Ягодный", Price = 3200 },
        new OrderClientModel(Guid.NewGuid(),
            DateTime.Now,
            "Мсоква,Речная 34",
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "500") { OrderCakeTitle = "Творожный", Price = 670 },
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "500")
            { OrderCakeTitle = "Блинный", Price = 200 },
        new OrderClientModel(Guid.NewGuid(),
            DateTime.Now,
            "Мсоква,Речная 34",
            Guid.NewGuid(),
            Guid.NewGuid(),
            Guid.NewGuid(),
            "500") { OrderCakeTitle = "Шоколадный", Price = 3400 },
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "500")
        {
            OrderCakeTitle = "Панчо", Price = 870
        }
    };

    private Visibility _priceVisible;

    public OrderViewModel()
    {
        _orderNew = new OrderClientModel();
        ContainerCommand = new Container { NewClientModel = _orderNew, ViewModel = this };
    }

    public Visibility PriceVisible
    {
        get => _priceVisible;
        set
        {
            _priceVisible = value;
            var boolean = (Application.Current as App).RoleUser is "Продавец";
            _priceVisible = boolean ? Visibility.Visible : Visibility.Hidden;

            if (!boolean)
            {
                HiddenColumnsEvent?.Invoke();
            }

            OnPropertyChanged(nameof(PriceVisible));
        }
    }

    public ObservableCollection<OrderClientModel> Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnPropertyChanged(nameof(Orders));
        }
    }

    public OrderClientModel OrderNew
    {
        get => _orderNew;
        set
        {
            _orderNew = value;
            OnPropertyChanged(nameof(OrderNew));
        }
    }

    public int ItemId { get; set; }

    public ICommand AddOrder { get; } = new RelayCommand(obj =>
    {
        var container = obj as Container;
        container.NewClientModel.OrderCreatedAt = DateTime.Now;
        container.ViewModel.Orders.Add(container.NewClientModel);
        container.ViewModel.OrderNew = new OrderClientModel();
        container.ViewModel.ContainerCommand = new Container { NewClientModel = container.ViewModel.OrderNew, ViewModel = container.ViewModel };
        container.ViewModel.UpdateAllProperty();
    });

    

    //public ICommand DeleteOrder { get; } = new RelayCommand(obj =>
    //{
    //    var container = obj as Container;
        
    //    var item = 0;
    //    if (item < container.ViewModel.Orders.Count)
    //    {
    //        container.ViewModel.Orders.RemoveAt(item);
    //    }
    //    container.ViewModel.UpdateAllProperty();
    //});

    //public void DeleteOrders(object obj, int itemId)
    //{
    //    var container = obj as Container;
    //    if (itemId < container.ViewModel.Orders.Count)
    //    {
    //        container.ViewModel.Orders.RemoveAt(itemId);
    //    }
    //    container.ViewModel.UpdateAllProperty();
    //}



    public Container ContainerCommand
    {
        get => _containerCommand;
        set
        {
            _containerCommand = value;
            OnPropertyChanged(nameof(ContainerCommand));
        }
    }

    public event Action HiddenColumnsEvent;

    public override void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(OrderNew));
        OnPropertyChanged(nameof(Orders));
    }

    public class Container
    {
        public OrderViewModel ViewModel { get; set; }
        public OrderClientModel NewClientModel { get; set; }
    }

}