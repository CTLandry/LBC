﻿using System;
using LBC.Configuration.Settings;
using Newtonsoft.Json;

namespace LBC.Configuration.Configs
{
    public class Config : IConfiguration
    {
        [JsonProperty("authapisettings")]
        public AuthAPISettings AuthApiSettings { get; }
        [JsonProperty("appcentersettings")]
        public AppCenterSettings AppCenterSettings { get; }

    }
}