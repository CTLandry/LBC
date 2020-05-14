using System.Threading.Tasks;
using LBC.Domain.SocialAuth.Results;

namespace LBC.Services.SocialAuth
{
    public interface ISocialAuth
    {
        Task<SocialAuthResult<TResult, TMessage>> Authenticate<TResult, TMessage>(string scheme);
    }
}
