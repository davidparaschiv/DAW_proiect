using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Requests
{
    public class GeneralToSeeListItemRequest
    {
        public string IdOfProfile { get; set; }
        public string IdOfPost { get; set; }
    }
}
