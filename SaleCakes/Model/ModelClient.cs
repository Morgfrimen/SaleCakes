using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelClient
    {
        private readonly Guid _id;
        private readonly string _clientName;
        private readonly string _clientSurname;
        private readonly string _clientPatronymic;
        private readonly string _clientPhone;
        private readonly string _clientEmail;
        private readonly Guid _clientOrders;

        public ModelClient(Guid id, string clientName, string clientSurname, string clientPatronymic, string clientPhone, string clientEmail, Guid clientOrders)
        {
            _id = id;
            _clientName = clientName;
            _clientSurname = clientSurname;
            _clientPatronymic = clientPatronymic;
            _clientPhone = clientPhone;
            _clientEmail = clientEmail;
            _clientOrders = clientOrders;
        }

        public Guid Id { get { return _id; } }
        public string ClientName { get { return _clientName; } }
        public string ClientSurname { get { return _clientSurname; } }
        public string ClientPatronymic { get { return _clientPatronymic; } }
        public string ClientPhone { get { return _clientPhone; } }
        public string ClientEmail { get { return _clientEmail; } }
        public Guid ClientOrders { get { return _clientOrders; } }
    }
}
