using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MyShop;
using Lotz.Xam.Messaging;
using MyShop.Helpers;

namespace MyShopAdmin.Views
{
	public partial class FeedbackPage : ContentPage
	{
		public FeedbackPage (Feedback feedback)
		{
			InitializeComponent ();

			this.BindingContext = feedback;

			ButtonCall.Clicked += (sender, e) => {
			var phoneCallTask = MessagingPlugin.PhoneDialer;
			if (phoneCallTask.CanMakePhoneCall)
                phoneCallTask.MakePhoneCall(feedback.PhoneNumber.CleanPhone());
			};
		}
	}
}

