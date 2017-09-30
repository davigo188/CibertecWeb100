using Cibertec.Models;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
