using System;
using System.Threading.Tasks;
using LBC.Services.User.Session;
using LBC.ViewModels.Base;

namespace LBC.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private ISession _session;

        public SplashViewModel(ISession session)
        {
            _session = session;
            Task.Run(async () => await Init());
        }

        private async Task Init()
        {
            if(await _session.SessionIsValid())
            {
                App.Current.MainPage = new AppShell();
            }
            else
            {
                //Run Splash Animation
                //Drop user at Auth Page
            }
        }

       
    }
}
