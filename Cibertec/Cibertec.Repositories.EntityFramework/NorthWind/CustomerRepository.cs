using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Cibertec.Repositories.EntityFramework.NorthWind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {

        }

        public int Count()
        {
            return 0;
        }

        public IEnumerable<Customer> PagedList(int startRow, int endRow)
        {
            return new List<Customer>();
        }

        public Customer SearchByNames(string firstName, string lastName)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
