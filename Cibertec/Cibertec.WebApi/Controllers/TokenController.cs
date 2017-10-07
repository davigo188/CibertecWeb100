using Cibertec.Models;
using Cibertec.UnitOfWork;
using Cibertec.WebApi.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cibertec.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unit;

        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unit)
        {
            _tokenProvider = tokenProvider;
            _unit = unit;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody] User userLogin)
        {
            var user = GetUserByCredentials(userLogin.Email, userLogin.Password);
            if (user == null) throw new
        UnauthorizedAccessException("NO!");

            var lifeInHours = 8;

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(lifeInHours)),
                Expires_In = lifeInHours * 60
            };

            return token;
        }

        private User GetUserByCredentials (string email, string password)
        {
            return _unit.Users.ValidateUser(email, password);
        }
    }
}