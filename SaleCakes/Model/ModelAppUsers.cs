using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelAppUsers
    {
        public ModelAppUsers(Guid id, string userRole)
        {
            Id = id;
            UserRole = userRole;
        }

        public Guid Id { get; }
        public string UserRole { get; }
    }
}
