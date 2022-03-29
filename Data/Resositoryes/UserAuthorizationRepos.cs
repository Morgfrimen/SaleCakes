using System.Data.SqlClient;
using Data.Abstract;
using Data.Dto;

//TODO: CantelationToken?
namespace Data.Resositoryes;

public class UserAuthorizationRepos : IRepository<AuthorizationUserDto>
{
    private readonly string? _connectionString;

    public UserAuthorizationRepos(string? connectionStringString)
    {
        _connectionString = connectionStringString;
    }

    public async Task<AuthorizationUserDto?> GetByIdAsync(Guid id)
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

            var sqlExpression = $"Use SaleCakes; SELECT * FROM authorization_user where id = \'{id}\'";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var idDto = id;
                var userDto = reader.GetValue(1) is Guid ? (Guid)reader.GetValue(1) : default;
                var userLoginDto = reader.GetValue(2) as string;
                var userPasswordDto = reader.GetValue(3) as string;
                var createdAtDto = reader.GetValue(4) is DateTime ? (DateTime)reader.GetValue(4) : default;

                var authorizationUserDto = new AuthorizationUserDto(idDto, userDto, userLoginDto!, userPasswordDto!, createdAtDto);

                return authorizationUserDto;
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

    public async Task<IEnumerable<AuthorizationUserDto>?> GetAllAsync()
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

            var sqlExpression = "Use SaleCakes; SELECT * FROM authorization_user";
            var command = new SqlCommand(sqlExpression, connection);
            var reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                var listEmployees = new List<AuthorizationUserDto>();

                while (await reader.ReadAsync())
                {
                    var idDto = reader.GetValue(0) is Guid ? (Guid)reader.GetValue(0) : default;
                    var userDto = reader.GetValue(1) is Guid ? (Guid)reader.GetValue(1) : default;
                    var userLoginDto = reader.GetValue(2) as string;
                    var userPasswordDto = reader.GetValue(3) as string;
                    var createdAtDto = reader.GetValue(4) is DateTime ? (DateTime)reader.GetValue(4) : default;

                    var authorizationUserDto = new AuthorizationUserDto(idDto, userDto, userLoginDto!, userPasswordDto!, createdAtDto);
                    listEmployees.Add(authorizationUserDto);
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

    public async Task<bool> AddAsync(AuthorizationUserDto entity)
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

            var sqlExpression = $"Use SaleCakes; INSERT INTO authorization_user (user_guid,user_login,user_password,createdAt) VALUES (" +
                                $"\'{entity.AppUsers}\',\'{entity.UserLogin}\',\'{entity.UserPassword}\',\'{entity.CreatedAt}\')";
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

            var sqlExpression = $"Use SaleCakes; DELETE authorization_user WHERE id=\'{id}\'";

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

    public async Task<bool> UpdateAsync(AuthorizationUserDto entity)
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

            var sqlExpression = "Use SaleCakes; UPDATE authorization_user " +
                                $"SET user_login= \'{entity.UserLogin}\',user_password= \'{entity.UserPassword}\'" +
                                $",createdAt= \'{entity.CreatedAt}\' WHERE id=\'{entity.Id}\'";
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