using Cibertec.Models;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
