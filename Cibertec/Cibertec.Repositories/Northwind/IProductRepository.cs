using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> PagedList(int startRow, int endRow);
        int Count();

    }
}
