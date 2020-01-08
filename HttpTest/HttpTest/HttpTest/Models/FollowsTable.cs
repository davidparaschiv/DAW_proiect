using HttpTest.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Models
{
    public class FollowsTable : BaseEntity
    {
        public string IdOfTheOneWhoFollows { get; set; }
        public string IdOfWhoIsBeingFollowed { get; set; }
    }
}
