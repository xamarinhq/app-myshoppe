using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MyShop;

namespace MyShopAdmin
{
	public partial class FeedbackListPage : ContentPage
	{
		FeedbackListViewModel viewModel;
		public FeedbackListPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new FeedbackListViewModel (this);
			FeedbackList.ItemSelected += async (sender, e) => 
			{
				if(FeedbackList.SelectedItem == null)
					return;


				await Navigation.PushAsync(new MyShopAdmin.Views.FeedbackPage(e.SelectedItem as Feedback));

				FeedbackList.SelectedItem = null;
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();


			if(viewModel.Feedbacks.Count == 0)	
				viewModel.GetFeedbackCommand.Execute (null);


		}

		public async void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);

			var result = await DisplayAlert ("Delete?", "Are you sure you want to remove this feedback?", "Yes", "No");
            if (result)
            {
                await viewModel.DeleteFeedback(mi.CommandParameter as Feedback);
            }
		}
	}
}

