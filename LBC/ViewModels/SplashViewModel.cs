using System;
using System.Threading.Tasks;
using System.Windows.Input;
using LBC.Services.Authentication.Common;
using LBC.Services.Authentication.SocialAuth;
using LBC.Services.Caching;
using LBC.Services.User.Session;
using LBC.ViewModels.Base;
using Prism.Commands;
using Xamarin.Forms;

namespace LBC.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private ISession _session;
        private ISocialAuth _authentication;
        private ICache _caching;

        public DelegateCommand<string> AuthenticateCommand { get; private set; }

        public SplashViewModel(ISession session,
                               ISocialAuth authentication,
                               ICache cache)
        {
            _session = session;
            _authentication = authentication;
            _caching = cache;
            AuthenticateCommand =  new DelegateCommand<string>(async (type) => await Authenticate(type));
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            await _session.LoadSession(_caching);
            if(await _session.SessionIsValid())
            {
                App.Current.MainPage = new AppShell();
            }

        }

        async Task Authenticate(string type)
        {
            var authResult = await _authentication.Authenticate(new AuthParameters(type));
            if(authResult.Status == AuthStatus.Success)
            {
                _session.AccessToken = authResult.AccessToken;
                _session.RefreshToken = authResult.RefreshToken;
                _session.TokenExpires = new DateTimeOffset(DateTime.Now.AddDays(365));
                _session.User = authResult.User;

                var session = new Session();
                session.AccessToken = _session.AccessToken;
                session.RefreshToken = _session.RefreshToken;
                session.TokenExpires = _session.TokenExpires;
                session.User = _session.User;

                await _caching.CacheData<Session>(CacheDataKey.Session, session, 365);

                App.Current.MainPage = new AppShell();
            }
            else if(authResult.Status == AuthStatus.Failed)
            {
                //need to add some popup or way to convey failed
            }
            else if(authResult.Status == AuthStatus.Error)
            {
                //should still convey error the catch all blue whale page
                //wont be available until the shell is created
            }
        }

        
    }
}
