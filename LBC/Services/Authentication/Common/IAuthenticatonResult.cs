using System;
using LBC.Models.User;

namespace LBC.Services.Authentication.Common
{
    public interface IAuthenticatonResult
    {
        AuthStatus Status { get; }
        string Message { get; }
        string AccessToken { get; }
        string RefreshToken { get; }
        DateTimeOffset? TokenExpires { get; }
        User_Model User { get; }

    }
}
