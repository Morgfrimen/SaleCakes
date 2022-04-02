using System.Data.SqlClient;
using Data.Legacy.Abstract;
using Data.Legacy.Dto;

namespace Data.Legacy.Resositoryes;

public class TiersRepos : IRepository<TiersDto>
{
    private readonly string? _connectionString;

    public TiersRepos(string? connectionStringString)
    {
        _connectionString = connectionStringString;
    }


    public async Task<TiersDto?> GetByIdAsync(Guid id)
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

            var sqlExpression = $"Use SaleCakes; SELECT * FROM tiers where id = \'{id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    var idDto = id;
                    var stuffingId = reader.GetValue(1) is Guid ? (Guid)reader.GetValue(1) : default;
                    var decorId = reader.GetValue(2) is Guid ? (Guid)reader.GetValue(2) : default;
                    var shortcakeId = reader.GetValue(3) is Guid ? (Guid)reader.GetValue(3) : default;

                    var tiersDto = new TiersDto(idDto, stuffingId, decorId, shortcakeId);

                    return tiersDto;
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

    public async Task<IEnumerable<TiersDto>?> GetAllAsync()
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

            var sqlExpression = "Use SaleCakes; SELECT * FROM tiers";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var listEmployees = new List<TiersDto>();

                while (await reader.ReadAsync())
                {
                    var idDto = reader.GetValue(0) is Guid ? (Guid)reader.GetValue(0) : default;
                    var stuffingId = reader.GetValue(1) is Guid ? (Guid)reader.GetValue(1) : default;
                    var decorId = reader.GetValue(2) is Guid ? (Guid)reader.GetValue(2) : default;
                    var shortcakeId = reader.GetValue(3) is Guid ? (Guid)reader.GetValue(3) : default;

                    var tiersDto = new TiersDto(idDto, stuffingId, decorId, shortcakeId);
                    listEmployees.Add(tiersDto);
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

    public async Task<bool> AddAsync(TiersDto entity)
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

            var sqlExpression = "Use SaleCakes; INSERT INTO tiers (stuffing,decor,shortcake) " +
                                $"VALUES (\'{entity.StuffingId}\',\'{entity.DecorId}\',\'{entity.ShortcakeId}\')";
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

            var sqlExpression = $"Use SaleCakes; DELETE tiers WHERE id=\'{id}\'";

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

    public async Task<bool> UpdateAsync(TiersDto entity)
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

            var sqlExpression = "Use SaleCakes; UPDATE tiers " +
                                $"SET stuffing= \'{entity.StuffingId}\', decor= \'{entity.DecorId}\',shortcake= \'{entity.ShortcakeId}\' WHERE id=\'{entity.Id}\'";
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