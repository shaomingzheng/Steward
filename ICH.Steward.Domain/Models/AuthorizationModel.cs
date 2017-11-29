namespace ICH.Steward.Domain.Models
{
    public class AuthorizationCodeModel
    {
        public string code { get; set; }

        public string state { get; set; }

        public string redirect_uri { get; set; }
    }
}
