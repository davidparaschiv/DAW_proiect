using ShowRank.Domain.EF;
using ShowRank.Domain.EF.IRepositories;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Implementations
{
    public class ToSeeListItemServices : BaseServices, IToSeeListItemServices
    {
        public IToSeeListItemRepository ToSeeListItemRepository { get; }

        public ToSeeListItemServices(ShowRankDbContext context, IToSeeListItemRepository toSeeListItemRepository) : base(context)
        {
            ToSeeListItemRepository = toSeeListItemRepository;
        }
    }
}
