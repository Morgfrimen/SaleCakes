namespace Data.Dto;

public record OrderClientDto
{
    public OrderClientDto(DateTime orderCreateAt, string orderAdress, Guid cakeId, Guid conditerId, Guid employeeId, decimal orderSeller)
    {
        OrderCreateAt = orderCreateAt;
        OrderAdress = orderAdress;
        CakeId = cakeId;
        ConditerId = conditerId;
        EmployeeId = employeeId;
        OrderSeller = orderSeller;
    }

    public OrderClientDto(Guid id, DateTime orderCreateAt, string orderAdress, Guid cakeId, Guid conditer, Guid employee, decimal orderSeller) 
        : this(orderCreateAt, orderAdress, cakeId, conditer, employee, orderSeller)
    {
        Id = id;
    }

    public Guid Id { get; }
    public DateTime OrderCreateAt { get; }
    public string OrderAdress { get; }
    public Guid CakeId { get; }
    public Guid ConditerId { get; }
    public Guid EmployeeId { get; }
    public Decimal OrderSeller { get; }
}