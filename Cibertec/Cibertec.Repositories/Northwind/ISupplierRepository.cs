using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Supplier SearchByNames(string firstName, string lastName);

        IEnumerable<Supplier> PagedList(int startRow, int endRow);
        int Count();
    }
}
