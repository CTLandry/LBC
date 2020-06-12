using System;
using Prism.Mvvm;
using LBC.ViewModels;
using LBC.Views;

namespace LBC.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static void RegisterViewModels()
        {
            ViewModelLocationProvider.Register<SplashView, SplashViewModel>();
        }
    }
}
