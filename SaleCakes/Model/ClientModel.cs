using System;

namespace SaleCakes.Model;

internal class ClientModel
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

    public Guid Id { get; }
    public string ClientName { get; }
    public string ClientSurname { get; }
    public string ClientPatronymic { get; }
    public string ClientPhone { get; }
    public string ClientEmail { get; }
    public Guid ClientOrders { get; }
}