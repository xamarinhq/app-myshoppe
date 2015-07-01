using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MyShop
{
	public partial class StorePage : ContentPage
	{
		StoreViewModel viewModel;
		public StorePage (Store store)
		{
			InitializeComponent ();

			Xamarin.Insights.Track ("Store", new Dictionary<string, string>
				{
					{"name", store.Name}
				});
			BindingContext = viewModel = new StoreViewModel (store, this);
		
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			var position = new Position(viewModel.Store.Latitude,viewModel.Store.Longitude); // Latitude, Longitude
			var pin = new Pin {
				Type = PinType.Place,
				Position = position,
				Label = viewModel.Store.Name,
				Address = viewModel.Store.StreetAddress
			};
			MyMap.Pins.Add(pin);

			MyMap.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					position, Distance.FromMiles(.2)));
		}
	}
}

