using ShowRank.Domain.EF.IRepositories;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.EF.Repositories
{
    public class ToSeeListItemRepository : BaseRepository<ToSeeListItem>, IToSeeListItemRepository
    {
        public ToSeeListItemRepository(ShowRankDbContext context) : base(context) {}
    }
}
