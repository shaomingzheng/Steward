using System;
using System.Collections.Generic;
using System.Text;

namespace ICH.Steward.Domain.Models
{
    public class LoginModel
    {
        public string openid { get; set; }

        public string access_token { get; set; }
    }
}
