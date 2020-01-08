using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Requests
{
    public class GeneralFollowsTableRequest
    {
        public string IdOfTheOneWhoFollows { get; set; }
        public string IdOfWhoIsBeingFollowed { get; set; }
    }
}
