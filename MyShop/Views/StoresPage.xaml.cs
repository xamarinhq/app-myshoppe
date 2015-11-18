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

            viewModel.ItemSelected = ItemSelected;
			if(Device.OS == TargetPlatform.WinPhone || (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone))
			{
				//StoreList.IsGroupingEnabled = false;
				//StoreList.ItemsSource = viewModel.Stores;
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

