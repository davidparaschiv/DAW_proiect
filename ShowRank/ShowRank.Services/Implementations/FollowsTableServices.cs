using ShowRank.Domain.EF;
using ShowRank.Domain.EF.IRepositories;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Implementations
{
    public class FollowsTableServices : BaseServices, IFollowsTableServices
    {
        public IFollowsTableRepository FollowsTableRepository { get; }

        public FollowsTableServices(ShowRankDbContext context, IFollowsTableRepository followsTableRepository) : base(context)
        {
            FollowsTableRepository = followsTableRepository;
        }
    }
}
