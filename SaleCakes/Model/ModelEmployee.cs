﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleCakes.Model
{
    internal class ModelEmployee
    {
        public ModelEmployee(Guid id, Guid autorizedData, string employeeName, string employeeSurname, string employeePatronymic, string employeePhone, string employeeEmail)
        {
            Id = id;
            AutorizedData = autorizedData;
            EmployeeName = employeeName;
            EmployeeSurname = employeeSurname;
            EmployeePatronymic = employeePatronymic;
            EmployeePhone = employeePhone;
            EmployeeEmail = employeeEmail;
        }

        public Guid Id { get; }
        public Guid AutorizedData { get; }
        public string EmployeeName { get; }
        public string EmployeeSurname { get; }
        public string EmployeePatronymic { get; }
        public string EmployeePhone { get; }
        public string EmployeeEmail { get; }
    }
}
