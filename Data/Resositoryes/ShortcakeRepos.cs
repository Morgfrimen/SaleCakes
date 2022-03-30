using Data.Abstract;
using Data.Dto;
using System.Data.SqlClient;

namespace Data.Resositoryes;

public class ShortcakeRepos : IRepository<ShortcakeDto>
{
    private readonly string? _connectionString;

    public ShortcakeRepos(string? connectionStringString)
    {
        _connectionString = connectionStringString;
    }

    public async Task<ShortcakeDto?> GetByIdAsync(Guid id)
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

            var sqlExpression = $"Use SaleCakes; SELECT * FROM shortcake where id = \'{id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var idDto = id;
                var nameDto = reader.GetValue(1) as string;
                var priceDto = reader.GetValue(2) is decimal ? (decimal)reader.GetValue(2) : 0;

                var roleUserDto = new ShortcakeDto(idDto, nameDto,priceDto);

                return roleUserDto;
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

    public async Task<IEnumerable<ShortcakeDto>?> GetAllAsync()
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

            var sqlExpression = "Use SaleCakes; SELECT * FROM shortcake";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var listEmployees = new List<ShortcakeDto>();

                while (await reader.ReadAsync())
                {
                    var idDto = reader.GetValue(0) is Guid ? (Guid)reader.GetValue(0) : default;
                    var nameDto = reader.GetValue(1) as string;
                    var priceDto = reader.GetValue(2) is decimal ? (decimal)reader.GetValue(2) : 0;

                    var ShortcakeDto = new ShortcakeDto(idDto, nameDto , priceDto);
                    listEmployees.Add(ShortcakeDto);
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

    public async Task<bool> AddAsync(ShortcakeDto entity)
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

            var sqlExpression = $"Use SaleCakes; INSERT INTO shortcake (name,price) VALUES (\'{entity.Name}\',{entity.Price})";
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

            var sqlExpression = $"Use SaleCakes; DELETE shortcake WHERE id=\'{id}\'";

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

    public async Task<bool> UpdateAsync(ShortcakeDto entity)
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

            var sqlExpression = "Use SaleCakes; UPDATE shortcake " +
                                $"SET name= \'{entity.Name}\', price={entity.Price} WHERE id=\'{entity.Id}\'";
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