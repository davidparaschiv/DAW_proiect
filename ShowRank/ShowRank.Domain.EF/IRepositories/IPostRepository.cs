using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShowRank.Domain.EF.IRepositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        public Task<List<Post>> GetFollowersPostsAsync(string profileId);
        public Task<List<Post>> GetMyPostsAsync(string profileId);
    }
}
