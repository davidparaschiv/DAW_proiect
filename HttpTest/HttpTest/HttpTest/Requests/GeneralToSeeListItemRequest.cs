using HttpTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Requests
{
    public class GeneralToSeeListItemRequest
    {
        public string IdOfProfile { get; set; }
        public string IdOfPost { get; set; }
    }
}
