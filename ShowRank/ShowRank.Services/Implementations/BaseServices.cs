using ShowRank.Domain.EF;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShowRank.Services.Implementations
{
    public class BaseServices : IBaseServices
    {
        private readonly ShowRankDbContext _context;

        public BaseServices(ShowRankDbContext context)
        {
            _context = context;
        }

        public async Task CommitChanges()
        {
            await _context.SaveChangesAsync(true);
        }
    }
}
