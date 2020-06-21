using System;
using LBC.Configuration.Settings;

namespace LBC.Configuration.Configs
{
    public interface IConfiguration
    {
        AppCenterSettings AppCenterSettings { get; set; }
        AuthAPISettings AuthApiSettings { get; set; }
        CacheSettings CacheSettings { get; set; }
    }
}

