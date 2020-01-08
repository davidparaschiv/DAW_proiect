using HttpTest.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Models
{
    public class Post : BaseEntity
    {
        public string IdOfProfile { get; set; }
        public string NameOfTheShow { get; set; }
        public string Opinion { get; set; }
        public int RatingValue { get; set; }
        public string ShowType { get; set; }
        public DateTime Date { get; set; }
    }
}
