using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShowRank.Domain.EF.IRepositories
{
    public interface IProfileRepository : IAccountRepository<Profile>
    {
        public Task<List<Profile>> GetTopProfilesAsync();
    }
}
