namespace Data.Dto;

public record OrderClient
{
    public OrderClient(DateTime orderCreateAt, string orderAdress, Guid cakeId, Guid conditer, Guid employee, decimal orderSeller)
    {
        OrderCreateAt = orderCreateAt;
        OrderAdress = orderAdress;
        CakeId = cakeId;
        Conditer = conditer;
        Employee = employee;
        OrderSeller = orderSeller;
    }

    public OrderClient(Guid id, DateTime orderCreateAt, string orderAdress, Guid cakeId, Guid conditer, Guid employee, decimal orderSeller) 
        : this(orderCreateAt, orderAdress, cakeId, conditer, employee, orderSeller)
    {
        Id = id;
    }

    public Guid Id { get; }
    public DateTime OrderCreateAt { get; }
    public string OrderAdress { get; }
    public Guid CakeId { get; }
    public Guid Conditer { get; }
    public Guid Employee { get; }
    public Decimal OrderSeller { get; }
}