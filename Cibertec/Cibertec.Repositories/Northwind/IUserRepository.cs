using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
