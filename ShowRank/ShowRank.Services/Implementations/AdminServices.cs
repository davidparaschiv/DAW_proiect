using ShowRank.Domain.EF;
using ShowRank.Domain.EF.IRepositories;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Implementations
{
    public class AdminServices : BaseServices, IAdminServices
    {
        public IAdminRepository AdminRepository { get; }

        public AdminServices(ShowRankDbContext context, IAdminRepository adminRepository) : base(context)
        {
            AdminRepository = adminRepository;
        }
    }
}
