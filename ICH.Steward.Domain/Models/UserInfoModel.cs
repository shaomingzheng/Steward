using System;
using System.Collections.Generic;
using System.Text;

namespace ICH.Steward.Domain.Models
{
    public class UserInfoModel
    {
        public string openid { get; set; }

        public string nickname { get; set; }

        public string cellphone { get; set; }

        public int sex { get; set; }

        public string email { get; set; }
        public string figureurl { get; set; }
    }
}
