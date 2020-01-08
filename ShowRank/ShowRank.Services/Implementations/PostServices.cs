using ShowRank.Domain.EF;
using ShowRank.Domain.EF.IRepositories;
using ShowRank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Services.Implementations
{
    public class PostServices : BaseServices, IPostServices
    {
        public IPostRepository PostRepository { get; }

        public PostServices(ShowRankDbContext context, IPostRepository postRepository) : base(context)
        {
            PostRepository = postRepository;
        }
    }
}
