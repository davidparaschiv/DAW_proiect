using ShowRank.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShowRank.Domain.Models
{
    public class ToSeeListItem : BaseEntity
    {
        public string IdOfProfile { get; set; }

        public string IdOfPost { get; set; }
    }
}
