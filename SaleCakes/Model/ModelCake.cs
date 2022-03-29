using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelCake
    {
        private readonly Guid _id;
        private readonly double _weight;
        private readonly int _tier;

        public ModelCake(Guid id, double weight, int tier)
        {
            _id = id;
            _weight = weight;
            _tier = tier;
        }

        public Guid Id { get { return _id; } }
        public double Weight { get { return _weight; } }
        public int Tier { get { return _tier; } }
    }
}
