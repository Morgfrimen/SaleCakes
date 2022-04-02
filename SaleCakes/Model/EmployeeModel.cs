﻿using System;

namespace SaleCakes.Model;

internal class EmployeeModel
{
    public EmployeeModel(Guid id, Guid autorizedDataId, string employeeName, string employeeSurname, string employeePatronymic, string employeePhone, string employeeEmail)
    {
        Id = id;
        AutorizedDataId = autorizedDataId;
        EmployeeName = employeeName;
        EmployeeSurname = employeeSurname;
        EmployeePatronymic = employeePatronymic;
        EmployeePhone = employeePhone;
        EmployeeEmail = employeeEmail;
    }

    public Guid Id { get; }
    public Guid AutorizedDataId { get; }
    public string EmployeeName { get; }
    public string EmployeeSurname { get; }
    public string EmployeePatronymic { get; }
    public string EmployeePhone { get; }
    public string EmployeeEmail { get; }
}