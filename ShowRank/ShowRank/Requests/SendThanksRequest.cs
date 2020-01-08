using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Requests
{
    public class SendThanksRequest
    {
        public string ToId { get; set; }
        public string FromId { get; set; }
    }
}
