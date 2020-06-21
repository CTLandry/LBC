using System;
using Newtonsoft.Json;

namespace LBC.Configuration.Settings
{
    public class AppCenterSettings
    {
        [JsonProperty("isenabled")]
        public bool isEnabled { get; set; }

        [JsonProperty("androidid")]
        public string androidId { get; set; }

        [JsonProperty("iosid")]
        public string iosId { get; set; }
    }
}
