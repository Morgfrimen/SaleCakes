using System;

namespace SaleCakes.Model;

public class ClientModel
{
    public ClientModel(Guid id, string clientName, string clientSurname, string clientPatronymic, string clientPhone, string clientEmail, Guid clientOrders)
    {
        Id = id;
        ClientName = clientName;
        ClientSurname = clientSurname;
        ClientPatronymic = clientPatronymic;
        ClientPhone = clientPhone;
        ClientEmail = clientEmail;
        ClientOrders = clientOrders;
    }

    public ClientModel()
    {
    }

    public Guid Id { get; set; }
    public string ClientName { get; set; }
    public string ClientSurname { get; set; }
    public string ClientPatronymic { get; set; }
    public string ClientPhone { get; set; }
    public string ClientEmail { get; set; }
    public Guid ClientOrders { get; set; }
}