using System;
using LBC.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LBC
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            InitApp();
            MainPage = new SplashView();
        }

        private void InitApp()
        {
            ViewModels.Base.ViewModelLocator.RegisterViewModels();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
