using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TTC.Models.Index
{
    public class IndexPageModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ID { get; set; }
        public userEnumerations.ShirtSize ShirtSize { get; set; }
    }
    public class userEnumerations{
        public enum ShirtSize{
            xs = 1,
            s = 2,
            m = 3,
            l = 4,
            xl = 5,
            xxl = 6
        }
    }
}
