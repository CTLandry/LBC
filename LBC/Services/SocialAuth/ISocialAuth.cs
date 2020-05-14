using System;
using System.Threading.Tasks;
using LBC.Services.Base;
using LBC.Services.SocialAuth.Results;

namespace LBC.Services.SocialAuth
{
    public interface ISocialAuth
    {
        Task<SocialAuthResult<TResult, TMessage>> Authenticate<TResult, TMessage>(string scheme);
    }
}
