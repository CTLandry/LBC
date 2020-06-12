﻿using System;
using LBC.Configuration.Configs;
using LBC.Infrastructure.Logging;
using LBC.Services.Authentication.Common;
using LBC.Services.Authentication.SocialAuth;
using LBC.Services.User.Session;
using LBC.ViewModels;
using LBC.Views;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LBC
{
    public partial class App : PrismApplication
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //var result = await NavigationService.("NavigationPage/SplashView");
            App.Current.MainPage = new SplashView();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Navigation Views
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SplashView, SplashViewModel>();

            //Services
            containerRegistry.RegisterSingleton<IConfiguration, Config>();
            containerRegistry.RegisterSingleton<ILogger, Logger>();
            containerRegistry.RegisterSingleton<ISession, Session>();
            containerRegistry.RegisterSingleton<IAuthenticate, SocialAuthenticationService>();

        }
    }
}
