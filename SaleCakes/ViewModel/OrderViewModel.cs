using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel;

public class OrderViewModel : BaseViewModel
{
    private ObservableCollection<OrderClientModel> _orders = new ObservableCollection<OrderClientModel>()
    {
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(),
            Guid.NewGuid(), Guid.NewGuid(), "500") { OrderCakeTitle = "Панчо", Price = 300},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(),
            Guid.NewGuid(), "500") { OrderCakeTitle = "Напалеон", Price = 600 },
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "500") { OrderCakeTitle = "Ягодный" , Price = 3200},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
            "500") { OrderCakeTitle = "Творожный" , Price = 670},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "500")
            { OrderCakeTitle = "Блинный" , Price = 200},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(),
            Guid.NewGuid(), "500") { OrderCakeTitle = "Шоколадный", Price = 3400 },
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "500")
        {
            OrderCakeTitle = "Панчо", Price = 870
        },
    };

    public event Action HiddenColumnsEvent;
    private OrderClientModel _orderNew;

    public Visibility PriceVisible
    {
        get
        {
            return _priceVisible;
        }
        set
        {
            _priceVisible = value;
            var boolean = (App.Current as App).RoleUser is "Продавец";
            _priceVisible = boolean ? Visibility.Visible : Visibility.Hidden;

            if (!boolean)
            {
                HiddenColumnsEvent?.Invoke();
            }

            OnPropertyChanged(nameof(PriceVisible));
        }
    }

    public OrderViewModel()
    {
        _orderNew = new OrderClientModel();
        ContainerCommand = new Container() { NewClientModel = _orderNew, ViewModel = this };
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

    public ICommand AddOrder { get; } = new RelayCommand((obj) =>
    {
        var container = obj as Container;
        container.NewClientModel.OrderCreatedAt = DateTime.Now;
        container.ViewModel.Orders.Add(container.NewClientModel);
        container.ViewModel.OrderNew = new OrderClientModel();
        container.ViewModel.UpdateAllProperty();
        container.ViewModel.ContainerCommand = new Container() { NewClientModel = container.ViewModel.OrderNew, ViewModel = container.ViewModel };
    });

    private Container _containerCommand;
    private Visibility _priceVisible;

    public Container ContainerCommand
    {
        get => _containerCommand;
        set
        {
            _containerCommand = value;
            OnPropertyChanged(nameof(ContainerCommand));
        }
    }

    public class Container
    {
        public OrderViewModel ViewModel { get; set; }
        public OrderClientModel NewClientModel { get; set; }
    }

    public override void UpdateAllProperty()
    {
        OnPropertyChanged(nameof(OrderNew));
        OnPropertyChanged(nameof(Orders));
    }
}