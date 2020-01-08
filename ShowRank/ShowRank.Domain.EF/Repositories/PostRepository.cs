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
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ShowRankDbContext context) : base(context) {}
       
        public async Task<List<Post>> GetFollowersPostsAsync(string profileId)
        {
            // Get all posts posted by the profiles which are followed by the profile with ID sent from request 
            var innerJoinQuery =
                from post in _context.Posts
                join followsTableEntry in _context.FollowsTable on post.IdOfProfile equals followsTableEntry.IdOfWhoIsBeingFollowed
                where followsTableEntry.IdOfTheOneWhoFollows == profileId
                orderby post.Date descending
                select new Post()
                {
                    Id = post.Id,
                    IdOfProfile = post.IdOfProfile,
                    NameOfTheShow = post.NameOfTheShow,
                    Opinion = post.Opinion,
                    RatingValue = post.RatingValue,
                    ShowType = post.ShowType,
                    Date = post.Date
                }
            ;

            return await innerJoinQuery.ToListAsync();
        }

        public async Task<List<Post>> GetMyPostsAsync(string profileId)
        {
            var queryResult =
                from post in _context.Posts
                where post.IdOfProfile == profileId
                orderby post.Date descending
                select post;

            return await queryResult.ToListAsync();
        }
    }
}
