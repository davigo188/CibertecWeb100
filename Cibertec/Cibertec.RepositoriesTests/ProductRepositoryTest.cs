using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.EntityFrameworkTests
{
    public class ProductRepositoryTest
    {
        private readonly DbContext _context;

        public ProductRepositoryTest()
        {
            _context = new NorthwindDBContext();
        }

        //[Fact(DisplayName = "[ProductRepository]Get All")]
        //public void Product_Repository_GetAll()
        //{
        //    var repo = new RepositoryEF<Product>(_context);
        //    var result = repo.GetList();
        //    Assert.True(result.Count() > 0);
        //}

    }
}
