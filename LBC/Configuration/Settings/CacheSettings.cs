using System;
using Newtonsoft.Json;

namespace LBC.Configuration.Settings
{
    public class CacheSettings
    {
        [JsonProperty("barrelid")]
        public string barrelid { get; set; }
    }
}
