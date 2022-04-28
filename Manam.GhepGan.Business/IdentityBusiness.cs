using Manam.GhepGan.Business.Interfaces;
using Manam.GhepGan.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool Login(string username, string password)
        {
            var account = _dbContext.Accounts.SingleOrDefault(s => s.Username == request.Data.Username);
        }
    }
}
