namespace ICH.Steward.Domain
{
    public class AppSettings
    {
        public static string TokenEndpoint { get; set; }

        public static string ClientId { get; set; }

        public static string ClientSecret { get; set; }

        public static string UserInfoEndpoint { get; set; }

        public static bool UseRedis { get; set; }

        public static string RedisConnectionString { get; set; }

        public static string RedisInstanceName { get; set; }
    }
}
