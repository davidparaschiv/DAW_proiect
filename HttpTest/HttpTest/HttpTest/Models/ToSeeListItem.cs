using HttpTest.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Models
{
    public class ToSeeListItem : BaseEntity
    {
        public string IdOfProfile { get; set; }
        public string IdOfPost { get; set; }
    }
}
