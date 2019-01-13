using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SimpleImageButton.Sample.Droid
{
    [Activity(Label = "SimpleImageButton.Sample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Make this call to load the effect
            SimpleImageButtonLib.SimpleImageButton.Initializator.Initializator.Init();

            LoadApplication(new App());
        }
    }
}