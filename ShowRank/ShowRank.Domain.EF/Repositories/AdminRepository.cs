using ShowRank.Domain.EF.IRepositories;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.EF.Repositories
{
    public class AdminRepository : AccountRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ShowRankDbContext context) : base(context) {}
    }
}
