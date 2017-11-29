using System;
namespace ICH.Steward.WebAPI.Middleware
{
    public class StewardException:SystemException
    {
        public string Code { get; set; }

        public new string Message { get; set; }
    }
}
