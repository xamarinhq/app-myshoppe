using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Android.Graphics.Drawables;

namespace MyShop.Droid
{
	[Activity (Label = "My Shoppe", Icon = "@drawable/ic_launcher", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			global::Xamarin.FormsMaps.Init (this, bundle);

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			Xamarin.Insights.Initialize("c3d88c6f124fdabdf8880b65845094bb7bad90ac", this);
			Xamarin.Insights.ForceDataTransmission = true;

			LoadApplication (new App ());
			ImageCircleRenderer.Init();

			ActionBar.SetIcon ( new ColorDrawable (Resources.GetColor (Android.Resource.Color.Transparent)));
		}
	}
}

