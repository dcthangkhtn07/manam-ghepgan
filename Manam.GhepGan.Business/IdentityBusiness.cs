using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Manam.GhepGan.Business.Interfaces;
using Manam.GhepGan.DAL;
using Manam.GhepGan.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using BC = BCrypt.Net.BCrypt;

namespace Manam.GhepGan.Business
{
    public class IdentityBusiness : IIdentityBusiness
    {
        private readonly GhepGanDbContext _dbContext;

        public IdentityBusiness(GhepGanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AccountModel? GetUserLogin(string username, string password)
        {
            var account = _dbContext.Accounts.FirstOrDefault(s => s.Username == username);
            if (account != null && BC.Verify(password, account.Password))
            {
                var response = new AccountModel
                {
                    Username = username
                };

                return response;
            }
            return null;
        }
    }
}
