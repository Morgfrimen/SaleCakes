namespace Data.Dto;

public record OrderClientDto
{
    public OrderClientDto(DateTime orderCreateAt, string orderAdress, CakeDto cakeId, EmployeeDto conditerId, EmployeeDto employeeId, decimal orderSeller)
    {
        OrderCreateAt = orderCreateAt;
        OrderAdress = orderAdress;
        CakeId = cakeId;
        ConditerId = conditerId;
        EmployeeId = employeeId;
        OrderSeller = orderSeller;
    }

    public OrderClientDto(Guid id, DateTime orderCreateAt, string orderAdress, CakeDto cakeId, EmployeeDto conditer, EmployeeDto employee, decimal orderSeller)
        : this(orderCreateAt, orderAdress, cakeId, conditer, employee, orderSeller)
    {
        Id = id;
    }

    public Guid Id { get; }
    public DateTime OrderCreateAt { get; }
    public string OrderAdress { get; }
    public CakeDto CakeId { get; }
    public EmployeeDto ConditerId { get; }
    public EmployeeDto EmployeeId { get; }
    public decimal OrderSeller { get; }
}