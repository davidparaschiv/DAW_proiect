using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Requests
{
    public class ApplyUnfollowRequest
    {
        public string WhomToUnfollowId { get; set; }
    }
}
