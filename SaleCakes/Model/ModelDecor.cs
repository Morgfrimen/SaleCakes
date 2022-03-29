using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelDecor
    {
        private readonly Guid _id;
        private readonly string _name;
        private readonly string _price;

        public ModelDecor(Guid id, string name, string price)
        {
            _id = id;
            _name = name;
            _price = price;
        }

        public Guid Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Price { get { return _price; } }
    }
}
