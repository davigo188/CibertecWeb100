using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer SearchByNames(string firstName, string lastName);



    }
}
