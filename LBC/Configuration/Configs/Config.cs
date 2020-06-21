using System;
using LBC.Configuration.Settings;
using Newtonsoft.Json;

namespace LBC.Configuration.Configs
{
    public class Config : IConfiguration
    {
        [JsonProperty("authapisettings")]
        public AuthAPISettings AuthApiSettings { get; set; }
        [JsonProperty("appcentersettings")]
        public AppCenterSettings AppCenterSettings { get; set; }
        [JsonProperty("cachesettings")]
        public CacheSettings CacheSettings { get; set; }
    }
}
