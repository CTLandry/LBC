using System;
using Newtonsoft.Json;

namespace LBC.Configuration.Settings
{
    public class AuthAPISettings
    {

        [JsonProperty("baseurl")]
        public string BaseUrl { get; set; }

        [JsonProperty("timeout")]
        public int timeout { get; set; }

        [JsonProperty("maxbuffersize")]
        public int maxbuffersize { get; set; }

    }
}
