﻿using HttpTest.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Models
{
    public class Profile : BaseAppUser
    {
        public int FollowersNumber { get; set; }
        public int FollowingNumber { get; set; }
        public int HelpsNumber { get; set; }
        public string Bio { get; set; }
    }
}
