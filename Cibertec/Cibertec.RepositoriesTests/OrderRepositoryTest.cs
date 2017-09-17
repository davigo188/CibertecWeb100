using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Cibertec.RepositoriesTests
{
    public class OrderRepositoryTest
    {
        private readonly DbContext _context;

        public OrderRepositoryTest()
        {
            _context = new NorthwindDBContext();
        }

        [Fact(DisplayName = "[OrderRepository]Get All")]
        public void Order_Repository_GetAll()
        {
            var repo = new RepositoryEF<Order>(_context);
            var result = repo.GetList();
            Assert.True(result.Count() > 0);
        }
    }
}
