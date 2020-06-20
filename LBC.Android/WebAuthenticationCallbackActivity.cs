using Android.App;
using Android.Content;
using Android.Content.PM;

namespace LBC.Droid
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = CALLBACK_SCHEME)]
    public class WebAuthenticationCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "xamarinessentials";

        protected override void OnResume()
        {
            base.OnResume();

            Xamarin.Essentials.Platform.OnResume();
        }
    }
}
