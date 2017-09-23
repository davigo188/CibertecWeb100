using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.EntityFrameworkTests
{
    public class OrderItemRepositoryTest
    {
        private readonly DbContext _context;

        public OrderItemRepositoryTest()
        {
            _context = new NorthwindDBContext();
        }

        //[Fact(DisplayName = "[OrderItemRepository]Get All")]
        //public void OrderItem_Repository_GetAll()
        //{
        //    var repo = new RepositoryEF<OrderItem>(_context);
        //    var result = repo.GetList();
        //    Assert.True(result.Count() > 0);
        //}
    }
}
