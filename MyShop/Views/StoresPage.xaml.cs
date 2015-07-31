using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyShop
{
	public partial class StoresPage : ContentPage
	{
        StoresViewModel viewModel;
        public Action<Store> ItemSelected { get; set; }
        public StoresPage ()
		{
			InitializeComponent ();

			Xamarin.Insights.Track ("Stores");

			BindingContext = viewModel = new StoresViewModel (this);

			StoreList.ItemSelected += async (sender, e) => 
			{
				if(StoreList.SelectedItem == null)
					return;

                var store = e.SelectedItem as Store;
                if (ItemSelected == null)
                {
                    await Navigation.PushAsync(new StorePage(store));
                    StoreList.SelectedItem = null;
                }
                else
                {
                    ItemSelected.Invoke(store);
                }
            };

			if(Device.OS == TargetPlatform.WinPhone || (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone))
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

