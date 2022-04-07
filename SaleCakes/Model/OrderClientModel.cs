using System;

namespace SaleCakes.Model;

public class OrderClientModel
{
    public OrderClientModel(Guid id, DateTime orderCreatedAt, string orderAdress, Guid orderCake, Guid orderCondites, Guid orderEmployee, string orderSeller)
    {
        Id = id;
        OrderCreatedAt = orderCreatedAt;
        OrderAdress = orderAdress;
        OrderCake = orderCake;
        OrderCondites = orderCondites;
        OrderEmployee = orderEmployee;
        OrderSeller = orderSeller;
    }

    public OrderClientModel()
    {
    }

    public Guid Id { get; set; }
    public DateTime OrderCreatedAt { get; set; }
    public string OrderAdress { get; set; }
    public Guid OrderCake { get; set; }
    public Guid OrderCondites { get; set; }
    public Guid OrderEmployee { get; set; }
    public string OrderSeller { get; set; }
    public string OrderCakeTitle { get; set; }
}