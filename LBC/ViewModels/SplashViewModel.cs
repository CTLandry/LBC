using System;
using System.Threading.Tasks;
using System.Windows.Input;
using LBC.Services.Authentication.Common;
using LBC.Services.Authentication.SocialAuth;
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

        public DelegateCommand<string> AuthenticateCommand { get; private set; }

        public SplashViewModel(ISession session,
                               ISocialAuth authentication)
        {
            _session = session;
            _authentication = authentication;
            AuthenticateCommand =  new DelegateCommand<string>(async (type) => await Authenticate(type));
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            //check for non expired session if so use it else drop here for auth

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
                _session.User = authResult.User;

                //cache the session

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
