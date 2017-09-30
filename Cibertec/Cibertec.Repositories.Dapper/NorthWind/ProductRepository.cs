using Cibertec.Models;
using Cibertec.Repositories.Northwind;

namespace Cibertec.Repositories.Dapper.NorthWind
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
