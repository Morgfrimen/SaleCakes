using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelOrderClient
    {
        public ModelOrderClient(Guid id, DateTime orderCreatedAt, string orderAdress, Guid orderCake, Guid orderCondites, Guid orderEmployee, string orderSeller)
        {
            Id = id;
            OrderCreatedAt = orderCreatedAt;
            OrderAdress = orderAdress;
            OrderCake = orderCake;
            OrderCondites = orderCondites;
            OrderEmployee = orderEmployee;
            OrderSeller = orderSeller;
        }

        public Guid Id { get; }
        public DateTime OrderCreatedAt { get; }
        public string OrderAdress { get; }
        public Guid OrderCake { get; }
        public Guid OrderCondites { get; }
        public Guid OrderEmployee { get; }
        public string OrderSeller { get; }
    }
}
