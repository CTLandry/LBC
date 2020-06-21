using System;
using Newtonsoft.Json;

namespace LBC.Configuration.Settings
{
    public class AuthAPISettings
    {

        [JsonProperty("timeout")]
        public int timeout { get; set; }

        [JsonProperty("maxbuffersize")]
        public int maxbuffersize { get; set; }

        [JsonProperty("socialauthendpoint")]
        public string socialAuthEndPoint { get; set; }

    }
}
