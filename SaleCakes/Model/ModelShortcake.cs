using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelShortcake
    {
        public ModelShortcake(Guid id, string name, string price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Price { get; }
    }
}
