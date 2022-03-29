using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelOrderClient
    {
        private  readonly Guid _id;
        private readonly DateTime _orderCreatedAt;
        private readonly string _orderAdress;
        private readonly Guid _orderCake;
        private readonly Guid _orderCondites;
        private readonly Guid _orderEmployee;
        private readonly string _orderSeller;

        public ModelOrderClient(Guid id, DateTime orderCreatedAt, string orderAdress, Guid orderCake, Guid orderCondites, Guid orderEmployee, string orderSeller)
        {
            _id = id;
            _orderCreatedAt = orderCreatedAt;
            _orderAdress = orderAdress;
            _orderCake = orderCake;
            _orderCondites = orderCondites;
            _orderEmployee = orderEmployee;
            _orderSeller = orderSeller;
        }

        public Guid Id { get { return _id; } }
        public DateTime OrderCreatedAt { get { return _orderCreatedAt; } }
        public string OrderAdress { get { return _orderAdress; } }
        public Guid OrderCake { get { return _orderCake; } }
        public Guid OrderCondites { get { return _orderCondites; } }
        public Guid OrderEmployee { get { return _orderEmployee; } }
        public string OrderSeller { get { return _orderSeller; } }
    }
}
