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
			ButtonFindStore.Clicked += (sender, e) => 
			{
				Navigation.PushAsync(new StoresPage());
			};

			ButtonLeaveFeedback.Clicked += (sender, e) => 
			{
				Navigation.PushAsync(new FeedbackPage());
			};
		}
	}
}

