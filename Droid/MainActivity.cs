using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace CorporateBsGenerator.Droid
{
	[Activity(
        Label = "Corporate BS Generator", 
        Icon = "@drawable/ic_launcher", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            App.Logger = new DroidDeviceLogger();

            base.OnCreate (bundle);

			Forms.Init (this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication (new App ());
		}
	}
}

