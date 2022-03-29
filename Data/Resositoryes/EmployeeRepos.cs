﻿using System.Data.SqlClient;
using Data.Abstract;
using Data.Dto;

//TODO: CantelationToken?
namespace Data.Resositoryes;

public class EmployeeRepos : IRepository<EmployeeDto>
{
    private readonly string? _connectionString;

    public EmployeeRepos(string? connectionStringString)
    {
        _connectionString = connectionStringString;
    }

    public async Task<EmployeeDto?> GetByIdAsync(Guid id)
    {
        SqlConnection connection = default;

        if (_connectionString is null)
        {
            return null;
        }

        try
        {
            connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sqlExpression = $"SELECT * FROM SaleCakes.employee where id = \'{id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var idDto = id;
                var autorizedUserDto = reader.GetValue(1) is Guid ? (Guid)reader.GetValue(1) : default;
                var firstDto = reader.GetValue(2) as string;
                var lastDto = reader.GetValue(3) as string;
                var patronymicDto = reader.GetValue(4) as string;
                var phoneDto = reader.GetValue(5) as string;
                var emailDto = reader.GetValue(6) as string;

                var employeeDto = new EmployeeDto(idDto, autorizedUserDto, firstDto, lastDto, patronymicDto, phoneDto, emailDto);

                return employeeDto;
            }

            return null;
        }
        catch (Exception)
        {
            //TODO: Logger?
            return null;
        }
        finally
        {
            await connection.CloseAsync();
            await connection.DisposeAsync();
        }
    }

    public async Task<IEnumerable<EmployeeDto>?> GetAllAsync()
    {
        SqlConnection connection = default;

        if (_connectionString is null)
        {
            return null;
        }

        try
        {
            connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sqlExpression = "SELECT * FROM SaleCakes.employee";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var listEmployees = new List<EmployeeDto>();

                while (await reader.ReadAsync())
                {
                    var idDto = reader.GetValue(0) is Guid ? (Guid)reader.GetValue(0) : default;
                    var autorizedUserDto = reader.GetValue(1) is Guid ? (Guid)reader.GetValue(1) : default;
                    var firstDto = reader.GetValue(2) as string;
                    var lastDto = reader.GetValue(3) as string;
                    var patronymicDto = reader.GetValue(4) as string;
                    var phoneDto = reader.GetValue(5) as string;
                    var emailDto = reader.GetValue(6) as string;

                    var employeeDto = new EmployeeDto(idDto, autorizedUserDto, firstDto, lastDto, patronymicDto, phoneDto, emailDto);
                    listEmployees.Add(employeeDto);
                }

                return listEmployees;
            }

            return null;
        }
        catch (Exception)
        {
            //TODO: Logger?
            return null;
        }
        finally
        {
            await connection.CloseAsync();
            await connection.DisposeAsync();
        }
    }

    public async Task<bool> AddAsync(EmployeeDto entity)
    {
        SqlConnection? connection = default;

        if (_connectionString is null)
        {
            return false;
        }

        try
        {
            connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sqlExpression = $"INSERT SaleCakes.employee VALUES (\'{entity.AutorizedUserId}\'," +
                                $"\'{entity.FirstName}\',\'{entity.LastName}\',\'{entity.Patronymic}\'," +
                                $"\'{entity.Phone}\',\'{entity.Email}\')";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteNonQueryAsync();

            if (reader > 0)
            {
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            //TODO: Logger?
            return false;
        }
        finally
        {
            await connection.CloseAsync();
            await connection.DisposeAsync();
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        SqlConnection? connection = default;

        if (_connectionString is null)
        {
            return false;
        }

        try
        {
            connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sqlExpression = $"DELETE SaleCakes.employee WHETE id=\'{id}\'";

            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteNonQueryAsync();

            if (reader > 0)
            {
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            //TODO: Logger?
            return false;
        }
        finally
        {
            await connection.CloseAsync();
            await connection.DisposeAsync();
        }
    }

    public async Task<bool> UpdateAsync(EmployeeDto entity)
    {
        SqlConnection? connection = default;

        if (_connectionString is null)
        {
            return false;
        }

        try
        {
            connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var sqlExpression = "UPDATE SaleCakes.employee " +
                                $"SET employee_name= \'{entity.FirstName}\',employee_surname= \'{entity.LastName}\'" +
                                $",employee_patronymic= \'{entity.Patronymic}\',employee_phone=\'{entity.Phone}\'," +
                                $"employee_email=\'{entity.Email}\' " +
                                $" WHERE id=\'{entity.Id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteNonQueryAsync();

            if (reader > 0)
            {
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            //TODO: Logger?
            return false;
        }
        finally
        {
            await connection.CloseAsync();
            await connection.DisposeAsync();
        }
    }
}