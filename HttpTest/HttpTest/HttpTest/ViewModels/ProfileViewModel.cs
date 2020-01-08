using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpTest.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            HelpsNumber = -1;
            FollowersNumber = -1;
            FollowingNumber = -1;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public int HelpsNumber { get; set; }
        public bool IsFollowedByLoggedInUser { get; set; }
        public bool IsLoggedInUser { get; set; }
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
        public int FollowersNumber { get; set; }
        public int FollowingNumber { get; set; }
    }
}
