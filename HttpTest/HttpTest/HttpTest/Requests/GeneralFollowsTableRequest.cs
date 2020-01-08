using HttpTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Requests
{
    public class GeneralFollowsTableRequest
    {
        public string IdOfTheOneWhoFollows { get; set; }
        public string IdOfWhoIsBeingFollowed { get; set; }
    }
}
