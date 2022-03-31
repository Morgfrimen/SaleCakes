using Data.Abstract;
using Data.Dto;
using System.Data.SqlClient;

namespace Data.Resositoryes;

public class OrderClientRepos : IRepository<OrderClientDto>
{
    private readonly string? _connectionString;

    public OrderClientRepos(string? connectionStringString)
    {
        _connectionString = connectionStringString;
    }

    public async Task<OrderClientDto?> GetByIdAsync(Guid id)
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

            var sqlExpression = $"Use SaleCakes; SELECT * FROM order_client where id = \'{id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var dto = id;
                    var orderCreateAt = reader.GetValue(1) is DateTime ? (DateTime)reader.GetValue(1) : default;
                    var orderAdress = reader.GetValue(2) is string ? (string)reader.GetValue(2) : default;
                    var orderCake = reader.GetValue(3) is Guid ? (Guid)reader.GetValue(3) : default;
                    var orderConditess = reader.GetValue(4) is Guid ? (Guid)reader.GetValue(4) : default;
                    var orderEmoloyee = reader.GetValue(5) is Guid ? (Guid)reader.GetValue(5) : default;
                    var orderSeller = reader.GetValue(6) is decimal ? (decimal)reader.GetValue(6) : default;

                    var decorDto = new OrderClientDto(dto, orderCreateAt, orderAdress, orderCake, orderConditess, orderEmoloyee,orderSeller);

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

    public async Task<IEnumerable<OrderClientDto>?> GetAllAsync()
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

            var sqlExpression = "Use SaleCakes; SELECT * FROM order_client";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var listEmployees = new List<OrderClientDto>();

                while (await reader.ReadAsync())
                {
                    var dto = reader.GetValue(0) is Guid ? (Guid)reader.GetValue(0) : default;
                    var orderCreateAt = reader.GetValue(1) is DateTime ? (DateTime)reader.GetValue(1) : default;
                    var orderAdress = reader.GetValue(2) is string ? (string)reader.GetValue(2) : default;
                    var orderCake = reader.GetValue(3) is Guid ? (Guid)reader.GetValue(3) : default;
                    var orderConditess = reader.GetValue(4) is Guid ? (Guid)reader.GetValue(4) : default;
                    var orderEmoloyee = reader.GetValue(5) is Guid ? (Guid)reader.GetValue(5) : default;
                    var orderSeller = reader.GetValue(6) is decimal ? (decimal)reader.GetValue(6) : default;

                    var orderClientDto = new OrderClientDto(dto, orderCreateAt, orderAdress, orderCake, orderConditess, orderEmoloyee, orderSeller);
                    listEmployees.Add(orderClientDto);
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

    public async Task<bool> AddAsync(OrderClientDto entity)
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

            var sqlExpression = $"Use SaleCakes; INSERT INTO order_client (order_createdAt,order_adress,order_cake," +
                                $"order_condites,order_emoloyee,order_seller) VALUES ({entity.OrderCreateAt},\'{entity.OrderAdress}\'," +
                                $"\'{entity.CakeId}\',\'{entity.ConditerId}\',\'{entity.EmployeeId}\',{entity.OrderSeller})";
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

            var sqlExpression = $"Use SaleCakes; DELETE order_client WHERE id=\'{id}\'";

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

    public async Task<bool> UpdateAsync(OrderClientDto entity)
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

            var sqlExpression = "Use SaleCakes; UPDATE order_client " +
                                $"SET order_createdAt={entity.OrderCreateAt}, order_adress=\'{entity.OrderAdress}\'," +
                                $"order_cake=\'{entity.CakeId}\', order_condites=\'{entity.ConditerId}\',"+
                                $"order_emoloyee=\'{entity.EmployeeId}\', order_seller={entity.OrderAdress}," +
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