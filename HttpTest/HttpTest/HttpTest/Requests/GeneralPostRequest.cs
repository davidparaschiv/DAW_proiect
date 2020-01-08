using HttpTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTest.Requests
{
    public class GeneralPostRequest
    {
        public string IdOfProfile { get; set; }
        public string NameOfTheShow { get; set; }
        public string Opinion { get; set; }
        public int RatingValue { get; set; }
        public string ShowType { get; set; }
        public DateTime Date { get; set; }
    }
}
