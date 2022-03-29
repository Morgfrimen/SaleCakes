using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelAuthorizationUser
    {
        private readonly Guid _id;
        private readonly Guid _appUsers;
        private readonly string _userLogin;
        private readonly string _userPassword;
        private readonly DateTime _createdAt;

        public ModelAuthorizationUser(Guid id, Guid appUsers, string userLogin, string userPassword, DateTime createdAt)
        {
            _id = id;
            _appUsers = appUsers;
            _userLogin = userLogin;
            _userPassword = userPassword;
            _createdAt = createdAt;
        }

        public Guid Id { get { return _id; } }
        public Guid AppUsers { get { return _appUsers; } }
        public string UserLogin { get { return _userLogin; } }
        public string UserPassword { get { return _userPassword; } }
        public DateTime CreatedAt { get { return _createdAt; } }
    }
}
