using Data.Dto;
using SaleCakes.Model;

namespace SaleCakes.Automapers;

internal static class Automaper
{
    internal static EmployeeDto GetEmployeeDto(ModelEmployee model)
    {
        return new EmployeeDto(model.Id,
            model.AutorizedDataId,
            model.EmployeeName,
            model.EmployeeSurname,
            model.EmployeePatronymic,
            model.EmployeePhone,
            model.EmployeeEmail);
    }

    internal static ModelEmployee GetEmployeeModel(EmployeeDto dto)
    {
        return new ModelEmployee(dto.Id,
            dto.AutorizedUserId,
            dto.FirstName,
            dto.LastName,
            dto.Patronymic,
            dto.Phone,
            dto.Email);
    }
}