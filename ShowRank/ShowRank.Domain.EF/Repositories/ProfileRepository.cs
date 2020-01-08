using ShowRank.Domain.EF.IRepositories;
using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShowRank.Domain.EF.Repositories
{
    public class ProfileRepository : AccountRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ShowRankDbContext context) : base(context) {}

        public async Task<List<Profile>> GetTopProfilesAsync()
        {
            var queryResult =
                from profile in _context.Profiles
                orderby profile.HelpsNumber descending
                select profile;

            return await queryResult.ToListAsync();
        }
    }
}
