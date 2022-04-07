using System;

namespace SaleCakes.Model;

public class EmployeeModel
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

    public EmployeeModel()
    {
    }

    public Guid Id { get; set; }
    public Guid AutorizedDataId { get; set; }
    public string EmployeeName { get; set; }
    public string EmployeeSurname { get; set; }
    public string EmployeePatronymic { get; set; }
    public string EmployeePhone { get; set; }
    public string EmployeeEmail { get; set; }
}