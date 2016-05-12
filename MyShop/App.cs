using System;

using Xamarin.Forms;

namespace MyShop
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new HomePage())
			{
				BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#2B84D3")
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

