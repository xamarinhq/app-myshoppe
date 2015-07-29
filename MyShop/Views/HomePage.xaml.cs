using MyShop.Views.Tablet;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
			Xamarin.Insights.Track ("Home");
			BindingContext = new HomeViewModel (this);
			ButtonFindStore.Clicked += async (sender, e) => 
			{
                if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
                    await Navigation.PushAsync(new StoresTabletPage());
                else
				    await Navigation.PushAsync(new StoresPage());
			};

            if(Device.Idiom == TargetIdiom.Tablet)
            {
                HeroImage.Source = ImageSource.FromFile("herotablet.jpg");
            }

			ButtonLeaveFeedback.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync(new FeedbackPage());
			};
		}
	}
}

