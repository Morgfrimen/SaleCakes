using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelEmployee
    {
        private readonly Guid _id;
        private readonly Guid _autorizedData;
        private readonly string _employeeName;
        private readonly string _employeeSurname;
        private readonly string _employeePatronymic;
        private readonly string _employeePhone;
        private readonly string _employeeEmail;

        public ModelEmployee(Guid id, Guid autorizedData, string employeeName, string employeeSurname, string employeePatronymic, string employeePhone, string employeeEmail)
        {
            _id = id;
            _autorizedData = autorizedData;
            _employeeName = employeeName;
            _employeeSurname = employeeSurname;
            _employeePatronymic = employeePatronymic;
            _employeePhone = employeePhone;
            _employeeEmail = employeeEmail;
        }

        public Guid Id { get { return _id; } }
        public Guid AutorizedData { get { return _autorizedData; } }
        public string EmployeeName { get { return _employeeName; } }
        public string EmployeeSurname { get { return _employeeSurname; } }
        public string EmployeePatronymic { get { return _employeePatronymic; } }
        public string EmployeePhone { get { return _employeePhone; } }
        public string EmployeeEmail { get { return _employeeEmail; } }
    }
}
