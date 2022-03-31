using Data.Abstract;
using Data.Dto;
using System.Data.SqlClient;

namespace Data.Resositoryes;

public class ClientRepos : IRepository<ClientDto>
{
    private readonly string? _connectionString;

    public ClientRepos(string? connectionStringString)
    {
        _connectionString = connectionStringString;
    }

    public async Task<ClientDto?> GetByIdAsync(Guid id)
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

            var sqlExpression = $"Use SaleCakes; SELECT * FROM client where id = \'{id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var dto = id;
                    var name = reader.GetValue(1) is string ? (string)reader.GetValue(1) : default;
                    var surname = reader.GetValue(2) is string ? (string)reader.GetValue(2) : default;
                    var patronymic = reader.GetValue(3) is string ? (string)reader.GetValue(3) : default;
                    var phone = reader.GetValue(4) is string ? (string)reader.GetValue(4) : default;
                    var email = reader.GetValue(5) is string ? (string)reader.GetValue(5) : default;
                    var orders = reader.GetValue(6) is Guid[]? (Guid[])reader.GetValue(6) : default;

                    var decorDto = new ClientDto(dto, name,surname,patronymic,phone,email, orders);

                    return decorDto;
                }
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

    public async Task<IEnumerable<ClientDto>?> GetAllAsync()
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

            var sqlExpression = "Use SaleCakes; SELECT * FROM client";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var listEmployees = new List<ClientDto>();

                while (await reader.ReadAsync())
                {
                    var dto = reader.GetValue(0) is Guid ? (Guid)reader.GetValue(0) : default; ;
                    var name = reader.GetValue(1) is string ? (string)reader.GetValue(1) : default;
                    var surname = reader.GetValue(2) is string ? (string)reader.GetValue(2) : default;
                    var patronymic = reader.GetValue(3) is string ? (string)reader.GetValue(3) : default;
                    var phone = reader.GetValue(4) is string ? (string)reader.GetValue(4) : default;
                    var email = reader.GetValue(5) is string ? (string)reader.GetValue(5) : default;
                    var orders = reader.GetValue(6) is Guid[]? (Guid[])reader.GetValue(6) : default;

                    var clientDto = new ClientDto(dto, name, surname, patronymic, phone, email, orders);
                    listEmployees.Add(clientDto);
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

    public async Task<bool> AddAsync(ClientDto entity)
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

            var sqlExpression = $"Use SaleCakes; INSERT INTO client (client_name,client_surname,client_patronymic,client_phone,client_email,client_orders) " +
                                $"VALUES ({entity.ClientName},\'{entity.ClientSurname}\',\'{entity.ClientPatronymic}\',\'{entity.Phone}\',\'{entity.Email}\',\'{entity.OrdersId}\')";
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

            var sqlExpression = $"Use SaleCakes; DELETE client WHERE id=\'{id}\'";

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

    public async Task<bool> UpdateAsync(ClientDto entity)
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

            var sqlExpression = "Use SaleCakes; UPDATE client " +
                                $"SET client_name={entity.ClientName}, client_surname=\'{entity.ClientSurname}\'" +
                                $"client_name={entity.ClientPatronymic}, client_surname=\'{entity.Phone}\'" +
                                $"client_name={entity.Phone}, client_surname=\'{entity.Email}\'" +
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