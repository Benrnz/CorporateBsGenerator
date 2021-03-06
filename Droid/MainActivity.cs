﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace CorporateBsGenerator.Droid
{
	[Activity(
        Label = App.AppName, 
        Icon = "@drawable/ic_launcher", 
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;
            
            base.OnCreate (bundle);

			Forms.Init (this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication (new App ());
		}
	}
}

