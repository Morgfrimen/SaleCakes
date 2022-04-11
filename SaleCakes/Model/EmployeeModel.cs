using System;

namespace SaleCakes.Model;

public class EmployeeModel
{
    private string _employeePosition;
    public EmployeeModel(Guid id, Guid autorizedDataId, string employeeName, string employeeSurname, string employeePatronymic, string employeePhone, string employeeEmail, string employeePosition)
    {
        Id = id;
        AutorizedDataId = autorizedDataId;
        EmployeeName = employeeName;
        EmployeeSurname = employeeSurname;
        EmployeePatronymic = employeePatronymic;
        EmployeePhone = employeePhone;
        EmployeeEmail = employeeEmail;
        _employeePosition = employeePosition;
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
    public string EmployeePosition {
        get => _employeePosition;
        set
        {
            if (value=="0")
            {
                _employeePosition = "Администратор";
            }
            else if (value == "1")
            {
                _employeePosition = "Продавец";
            }
        }
    }
}