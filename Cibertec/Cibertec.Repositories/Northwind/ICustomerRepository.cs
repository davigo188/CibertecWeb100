using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer SearchByNames(string firstName, string lastName);

        IEnumerable<Customer> PagedList(int startRow, int endRow);
        int Count();

    }
}
