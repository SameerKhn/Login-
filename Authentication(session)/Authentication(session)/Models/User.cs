using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication_session_.Models
{
    public class User
    {
        //User Model
        public int id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

    }
}