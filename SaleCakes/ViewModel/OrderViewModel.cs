using System;
using System.Collections.ObjectModel;
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

    public ObservableCollection<OrderClientModel> Orders
    {
        get => _orders;
        set { _orders = value; OnPropertyChanged(nameof(Orders)); }
    }
}