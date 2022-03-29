using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelAppUsers
    {
        private readonly Guid _id;
        private readonly string _userRole;

        public ModelAppUsers(Guid id, string userRole)
        {
            _id = id;
            _userRole = userRole;
        }

        public Guid Id { get { return _id; } }
        public string UserRole { get { return _userRole; } }
    }
}
