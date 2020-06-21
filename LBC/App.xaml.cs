using System.Threading;
using LBC.Configuration.Configs;
using LBC.Infrastructure.Logging;
using LBC.Services.Authentication.Common;
using LBC.Services.Authentication.SocialAuth;
using LBC.Services.Caching;
using LBC.Services.User.Session;
using LBC.ViewModels;
using LBC.Views;
using MonkeyCache;
using MonkeyCache.FileStore;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Unity;
using Xamarin.Forms;


namespace LBC
{
    public partial class App : PrismApplication
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            App.Current.MainPage = new SplashView();
        }

        

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Navigation Views
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SplashView, SplashViewModel>();

            //Services
            var config = ConfigLoader.LoadConfiguration();
            containerRegistry.RegisterInstance<IConfiguration>(config);
            containerRegistry.RegisterSingleton<ILogger, Logger>();
            containerRegistry.RegisterSingleton<ICache, CachingService>();
            containerRegistry.RegisterSingleton<ISession, Session>();
            containerRegistry.RegisterSingleton<ISocialAuth, SocialAuthenticationService>();

        }
    }
}
