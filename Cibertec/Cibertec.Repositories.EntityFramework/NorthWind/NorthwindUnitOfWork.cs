using Cibertec.UnitOfWork;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;

namespace Cibertec.Repositories.EntityFramework.NorthWind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(DbContext context)
        {
            Customers = new CustomerRepository(context);
        }

        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IOrderItemRepository OrderItems { get; private set; }

        public IProductRepository Products { get; private set; }

        public ISupplierRepository Suppliers { get; private set; }

        public IUserRepository Users { get; private set; }
    }
}
