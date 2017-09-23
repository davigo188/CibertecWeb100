using Cibertec.Models;
using Cibertec.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Cibertec.Repositories.EntityFrameworkTests
{
    public class UserRepositoryTest
    {
        private readonly DbContext _context;

        public UserRepositoryTest()
        {
            _context = new NorthwindDBContext();
        }

        //[Fact(DisplayName = "[UserRepository]Get All")]
        //public void User_Repository_GetAll()
        //{
        //    var repo = new RepositoryEF<User>(_context);
        //    var result = repo.GetList();
        //    Assert.True(result.Count() > 0);
        //}
    }
}
