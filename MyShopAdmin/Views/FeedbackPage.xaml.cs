using Xamarin.Forms;
using MyShop;
using MyShop.Helpers;

using Xamarin.Essentials;

namespace MyShopAdmin.Views
{
    public partial class FeedbackPage : ContentPage
	{
		public FeedbackPage (Feedback feedback)
		{
			InitializeComponent ();

			this.BindingContext = feedback;

			ButtonCall.Clicked += (sender, e) => {
                try {
                    PhoneDialer.Open(feedback.PhoneNumber.CleanPhone());
                }
                catch (FeatureNotSupportedException fne)
                {
                    System.Diagnostics.Debug.WriteLine(fne.ToString());
                }
            };
		}
	}
}

