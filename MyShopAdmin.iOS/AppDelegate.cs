using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;

namespace MyShopAdmin.iOS
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
            FormsToolkit.iOS.Toolkit.Init();

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			ImageCircleRenderer.Init();


			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

