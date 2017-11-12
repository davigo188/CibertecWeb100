using Cibertec.Models;
using System.Collections.Generic;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderItemRepository :IRepository<OrderItem>
    {
        IEnumerable<OrderItem> PagedList(int startRow, int endRow);
        int Count();
    }
}
