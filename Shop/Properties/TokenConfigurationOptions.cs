namespace Shop.Properties
{
    public class TokenConfigurationOptions
    {
        public const string TokenConfiguration = "TokenConfigurations";
        public string SecurityKey { get; set; }
        public int ExpireHours { get; set; }
    };
}
