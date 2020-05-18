using System;
using LBC.Configuration.Settings;

namespace LBC.Configuration.Configs
{
    public interface IConfiguration
    {
        AppCenterSettings AppCenterSettings { get; }
        AuthAPISettings AuthApiSettings { get; }
    }
}

