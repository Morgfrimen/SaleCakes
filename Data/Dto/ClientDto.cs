namespace Data.Legacy.Dto;

public record ClientDto
{
    public ClientDto(Guid id, string clientName, string clientSurname, string clientPatronymic, string phone, string email, IEnumerable<OrderClientDto> ordersId)
        : this(clientName, clientSurname, clientPatronymic, phone, email, ordersId)
    {
        Id = id;
    }

    public ClientDto(string clientName, string clientSurname, string clientPatronymic, string phone, string email, IEnumerable<OrderClientDto> ordersId)
    {
        ClientName = clientName;
        ClientSurname = clientSurname;
        ClientPatronymic = clientPatronymic;
        Phone = phone;
        Email = email;
        OrdersId = ordersId;
    }

    public Guid Id { get; }
    public string ClientName { get; }
    public string ClientSurname { get; }
    public string ClientPatronymic { get; }
    public string Phone { get; }
    public string Email { get; }
    public IEnumerable<OrderClientDto> OrdersId { get; }
}