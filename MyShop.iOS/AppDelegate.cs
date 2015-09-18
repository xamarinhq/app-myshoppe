using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;

namespace MyShop.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{

			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(43, 132, 211); //bar background
			UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
				{
					Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
					TextColor = UIColor.White
				});
			global::Xamarin.Forms.Forms.Init ();

			Xamarin.FormsMaps.Init();

            
			Xamarin.Insights.Initialize("c3d88c6f124fdabdf8880b65845094bb7bad90ac");
			Xamarin.Insights.ForceDataTransmission = true;
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			SQLitePCL.CurrentPlatform.Init();
			ImageCircleRenderer.Init();


			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

