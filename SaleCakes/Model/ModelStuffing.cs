﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelStuffing
    {
        public ModelStuffing(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }
        public string Name { get; }
        public decimal Price { get; }
    }
}
