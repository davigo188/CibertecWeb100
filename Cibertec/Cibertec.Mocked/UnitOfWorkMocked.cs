using Cibertec.Models;
using Cibertec.UnitOfWork;
using Moq;
using System.Collections.Generic;
using Cibertec.Repositories.Northwind;
using Ploeh.AutoFixture;
using System.Linq;

namespace Cibertec.Mocked
{
    public class UnitOfWorkMocked
    {
        private List<Customer> _customers;
        public UnitOfWorkMocked()
        {
            _customers = Customers();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Customers).Returns(CustomerRepositoryMocked());
            return mocked.Object;
        }

        private ICustomerRepository CustomerRepositoryMocked()
        {
            var customerMocked = new Mock<ICustomerRepository>();
            customerMocked.Setup(c => c.GetList()).Returns(_customers);
            customerMocked.Setup(c => c.Insert(It.IsAny<Customer>())).Callback<Customer>((c) => _customers.Add(c)).Returns<Customer>(c => c.Id);
            customerMocked.Setup(c => c.Update(It.IsAny<Customer>())).Callback<Customer>((c) => { _customers.RemoveAll(cus => cus.Id == c.Id); _customers.Add(c); }).Returns(true);
            customerMocked.Setup(c => c.Delete(It.IsAny<Customer>())).Callback<Customer>((c) => _customers.RemoveAll(cus => cus.Id == c.Id)).Returns(true);
            customerMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id) => _customers.FirstOrDefault(cus => cus.Id == id));
            return customerMocked.Object;
        }

        private List<Customer> Customers()
        {
            var fixture = new Fixture();
            var customers = fixture.CreateMany<Customer>(50).ToList();
            for (int i = 0; i < customers.Count(); i++)
            {
                customers[i].Id = i + 1;
            }
            return customers;
        }
    }
}
