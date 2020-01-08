using ShowRank.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Models
{
    public class FollowsTable : BaseEntity
    {
        public string IdOfTheOneWhoFollows { get; set; }
        public string IdOfWhoIsBeingFollowed { get; set; }
    }
}
