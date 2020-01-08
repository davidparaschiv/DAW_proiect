using ShowRank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Requests
{
    public class GeneralProfileRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Bio { get; set; }
    }
}
