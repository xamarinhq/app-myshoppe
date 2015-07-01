using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
	public partial class StoresPage : ContentPage
	{
		private StoresViewModel viewModel;
		public StoresPage ()
		{
			InitializeComponent ();

			Xamarin.Insights.Track ("Stores");

			BindingContext = viewModel = new StoresViewModel (this);

			StoreList.ItemSelected += (sender, e) => 
			{
				if(StoreList.SelectedItem == null)
					return;


				Navigation.PushAsync(new StorePage(e.SelectedItem as Store));


				StoreList.SelectedItem = null;
			};

			if(Device.OS == TargetPlatform.WinPhone)
			{
				StoreList.IsGroupingEnabled = false;
				StoreList.ItemsSource = viewModel.Stores;
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

