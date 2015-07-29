using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MyShop;

namespace MyShopAdmin
{
	public partial class StoresPage : ContentPage
	{
		StoresViewModel viewModel;
		public StoresPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new StoresViewModel (this);
			viewModel.ForceSync = true;
			NewStore.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync(new StorePage(null));
			};

			StoreList.ItemSelected += async (sender, e) => 
			{
				if(StoreList.SelectedItem == null)
					return;


				await Navigation.PushAsync(new StorePage(e.SelectedItem as Store));


				StoreList.SelectedItem = null;
			};
		}

		public async void OnDelete (object sender, EventArgs e) {
			var mi = ((MenuItem)sender);

			var result = await DisplayAlert ("Delete?", "Are you sure you want to remove this store?", "Yes", "No");
            if (result)
            {
                await viewModel.DeleteStore(mi.CommandParameter as Store);
            }
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (viewModel.Stores.Count > 0 || viewModel.IsBusy)
				return;

			viewModel.GetStoresCommand.Execute (null);
		}

	}
}

