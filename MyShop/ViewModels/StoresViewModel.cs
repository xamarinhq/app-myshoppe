using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace MyShop
{
	public class StoresViewModel : BaseViewModel
	{
		readonly IDataStore dataStore;
		public ObservableCollection<Store> Stores { get; set;}
		public ObservableCollection<Grouping<string, Store>> StoresGrouped { get; set; }
		public bool ForceSync { get; set; }
		public StoresViewModel (Page page) : base (page)
		{
			Title = "Locations";
			dataStore = DependencyService.Get<IDataStore> ();
			Stores = new ObservableCollection<Store> ();
			StoresGrouped = new ObservableCollection<Grouping<string, Store>> ();
		}



		public async Task DeleteStore(Store store)
		{
			if (IsBusy)
				return;
			IsBusy = true;
			try {
				await dataStore.RemoveStoreAsync(store);
				Stores.Remove(store);
				Sort();
			} catch(Exception ex) {
				page.DisplayAlert ("Uh Oh :(", "Unable to remove store, please try again", "OK");
				Xamarin.Insights.Report (ex);
			}
			finally {
				IsBusy = false;
				
			}
		}

		private Command getStoresCommand;
		public Command GetStoresCommand
		{
			get {
				return getStoresCommand ??
					(getStoresCommand = new Command (async () => await ExecuteGetStoresCommand (), () => {return !IsBusy;}));
			}
		}

		private async Task ExecuteGetStoresCommand()
		{
			if (IsBusy)
				return;

			if (ForceSync)
				Settings.LastSync = DateTime.Now.AddDays (-30);

			IsBusy = true;
			GetStoresCommand.ChangeCanExecute ();
			try{
				Stores.Clear();

				var stores = await dataStore.GetStoresAsync ();
				foreach(var store in stores)
				{
					if(string.IsNullOrWhiteSpace(store.Image))
						store.Image = "http://refractored.com/images/wc_small.jpg";
					
					Stores.Add(store);
				}
				
				Sort();
			}
			catch(Exception ex) {
				page.DisplayAlert ("Uh Oh :(", "Unable to gather stores.", "OK");
				Xamarin.Insights.Report (ex);
			}
			finally {
				IsBusy = false;
				GetStoresCommand.ChangeCanExecute ();
			}

		}

		private void Sort()
		{

			StoresGrouped.Clear();
			var sorted = from store in Stores
				orderby store.Country, store.City 
				group store by store.Country into storeGroup
				select new Grouping<string, Store>(storeGroup.Key, storeGroup);

			foreach(var sort in sorted)
				StoresGrouped.Add(sort);
		}
	}

}

