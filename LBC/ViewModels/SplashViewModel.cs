using System;
using System.Threading.Tasks;
using System.Windows.Input;
using LBC.Services.Authentication.Common;
using LBC.Services.User.Session;
using LBC.ViewModels.Base;
using Prism.Commands;
using Xamarin.Forms;

namespace LBC.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private ISession _session;
        private IAuthenticate _authentication;

        public DelegateCommand<string> AuthenticateCommand { get; private set; }

        public SplashViewModel(ISession session,
                               IAuthenticate authentication)
        {
            _session = session;
            _authentication = authentication;
            AuthenticateCommand =  new DelegateCommand<string>(async (type) => await Authenticate(type));
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            if(await _session.SessionIsValid())
            {
                App.Current.MainPage = new AppShell();
            }
        }

        async Task Authenticate(string type)
        {
            var authResult = await _authentication.Authenticate(new AuthParameters(type));
            if(authResult.authStatus == AuthStatus.Success)
            {
                //update the session
                //create the appshell page and drop them at a main page
            }
            else if(authResult.authStatus == AuthStatus.Failed)
            {
                //need to add some popup or way to convey failed
            }
            else if(authResult.authStatus == AuthStatus.Error)
            {
                //should still convey error the catch all blue whale page
                //wont be available until the shell is created
            }
        }

        
    }
}
