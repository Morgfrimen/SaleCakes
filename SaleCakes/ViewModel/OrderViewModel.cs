using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SaleCakes.Command;
using SaleCakes.Model;

namespace SaleCakes.ViewModel;

public class OrderViewModel : BaseViewModel
{
    private ObservableCollection<OrderClientModel> _orders = new ObservableCollection<OrderClientModel>()
    {
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Панчо"},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Напалеон"},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Ягодный"},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Творожный"},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Блинный"},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Шоколадный"},
        new OrderClientModel(Guid.NewGuid(), DateTime.Now, "Мсоква,Речная 34",Guid.NewGuid(), Guid.NewGuid(),Guid.NewGuid(), "500"){OrderCakeTitle = "Панчо"},
    };

    private OrderClientModel _orderNew;

    public OrderViewModel()
    {
        _orderNew = new OrderClientModel();
        ContainerCommand = new Container() { NewClientModel = _orderNew, ViewModel = this };
    }

    public ObservableCollection<OrderClientModel> Orders
    {
        get => _orders;
        set { _orders = value; OnPropertyChanged(nameof(Orders)); }
    }

    public OrderClientModel OrderNew
    {
        get => _orderNew;
        set { _orderNew = value; OnPropertyChanged(nameof(OrderNew)); }
    }

    public ICommand AddOrder { get; } = new RelayCommand((obj) =>
    {
        var container = obj as Container;
        container.NewClientModel.OrderCreatedAt  = DateTime.Now;
        container.ViewModel.Orders.Add(container.NewClientModel);

        container.ViewModel.OrderNew = new OrderClientModel();
        container.ViewModel.UpdateAllProperty();
        container.ViewModel.ContainerCommand = new Container() { NewClientModel = container.ViewModel.OrderNew, ViewModel = container.ViewModel };
    });

    private Container _containerCommand;

    public Container ContainerCommand
    {
        get => _containerCommand;
        set { _containerCommand = value; OnPropertyChanged(nameof(ContainerCommand)); }
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