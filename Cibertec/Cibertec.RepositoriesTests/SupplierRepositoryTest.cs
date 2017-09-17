using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Cibertec.RepositoriesTests
{
    public class SupplierRepositoryTest
    {
        private readonly DbContext _context;

        public SupplierRepositoryTest()
        {
            _context = new NorthwindDBContext();
        }

        [Fact(DisplayName = "[SupplierRepository]Get All")]
        public void Supplier_Repository_GetAll()
        {
            var repo = new RepositoryEF<Supplier>(_context);
            var result = repo.GetList();
            Assert.True(result.Count() > 0);
        }

    }
}
