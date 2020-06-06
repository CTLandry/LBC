using System;
namespace LBC.Services.Authentication.Common
{
    public enum AuthStatus
    {
        Success,
        Failed,
        Error,
        Expired,
        Pending
    }
}
