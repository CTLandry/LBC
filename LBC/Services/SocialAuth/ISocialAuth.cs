using System;
using System.Threading.Tasks;

namespace LBC.Services.SocialAuth
{
    public interface ISocialAuth
    {
        Task<T> Authenticate<T>(string scheme);
    }
}
