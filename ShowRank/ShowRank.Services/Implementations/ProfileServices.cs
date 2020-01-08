using ShowRank.Domain.EF;
using ShowRank.Domain.EF.IRepositories;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Implementations
{
    public class ProfileServices : BaseServices, IProfileServices
    {
        public IProfileRepository ProfileRepository { get; }

        public ProfileServices(ShowRankDbContext context, IProfileRepository profileRepository) : base(context)
        {
            ProfileRepository = profileRepository;
        }
    }
}
