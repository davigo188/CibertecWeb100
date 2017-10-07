using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {

        }

        public User ValidateUser(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@email", email);
                parameters.Add("@password", password);

                return connection.QueryFirstOrDefault<User>("dbo.ValidateUser", 
                    parameters, 
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
