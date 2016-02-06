
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;
using System;
using Xamarin.Forms;

//Comment back in to use azure
using MyShop;
using Plugin.Connectivity;

[assembly: Dependency(typeof(AzureDataStore))]
namespace MyShop
{
	public class AzureDataStore : IDataStore
	{
		public MobileServiceClient MobileService { get; set; }

		IMobileServiceSyncTable<Store> storeTable;
		IMobileServiceSyncTable<Feedback> feedbackTable;
		bool initialized = false;

		public AzureDataStore()
		{
			// This is a sample read-only azure site for demo
			// Follow the readme.md in the GitHub repo on how to setup your own.
			MobileService =  new MobileServiceClient(
			"https://myshoppedemo2-code.azurewebsites.net",
			"https://default-web-eastus2da4ee2d042c24c8694b0170b0b122415.azurewebsites.net",
			"dmRICRMyoFCAwjjxmKvIgiuqFgQXOh63");
		}

		public async Task Init()
		{
			initialized = true;
			const string path = "syncstore.db";
			var store = new MobileServiceSQLiteStore(path);
			store.DefineTable<Store>();
			store.DefineTable<Feedback> ();
			await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

			storeTable = MobileService.GetSyncTable<Store>();
			feedbackTable = MobileService.GetSyncTable<Feedback> ();
		}


		public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
		{
			if (!initialized)
				await Init();


			await feedbackTable.InsertAsync(feedback);
			await SyncFeedbacksAsync ();
			return feedback;
		}

		public async Task<IEnumerable<Feedback>> GetFeedbackAsync ()
		{

			if (!initialized)
				await Init();

			await feedbackTable.PullAsync("allFeedbacks", feedbackTable.CreateQuery());

			return await feedbackTable.ToEnumerableAsync();
		}

		public async Task<bool> RemoveFeedbackAsync (Feedback feedback)
		{
			if (!initialized)
				await Init();

			await feedbackTable.DeleteAsync (feedback);
			await SyncFeedbacksAsync ();
			return true;
		}

		public async Task<Store> AddStoreAsync (Store store)
		{
			if (!initialized)
				await Init();

			await storeTable.InsertAsync (store);
			await SyncStoresAsync ();
			await MobileService.SyncContext.PushAsync();
			return store;
		}
		public async Task<bool> RemoveStoreAsync (Store store)
		{
			if (!initialized)
				await Init();

			await storeTable.DeleteAsync (store);
			await SyncStoresAsync ();
			await MobileService.SyncContext.PushAsync();
			return true;
		}
		public async Task<Store> UpdateStoreAsync (Store store)
		{
			if (!initialized)
				await Init();

			await storeTable.UpdateAsync (store);
			await SyncStoresAsync ();
			await MobileService.SyncContext.PushAsync();
			return store;
		}			

		public async Task<IEnumerable<Store>> GetStoresAsync()
		{
			if (!initialized)
				await Init();

			await SyncStoresAsync();
			return await storeTable.ToEnumerableAsync();
		}

		public async Task SyncStoresAsync()
		{
			try
			{
				if(!CrossConnectivity.Current.IsConnected || !Settings.NeedsSync)
					return;
				
				await storeTable.PullAsync("allStores", storeTable.CreateQuery());
				Settings.LastSync = DateTime.Now;
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Sync Failed:" + ex.Message);
			}
		}

		public async Task SyncFeedbacksAsync ()
		{
			try
			{
				Settings.NeedSyncFeedback = true;
				if(!CrossConnectivity.Current.IsConnected)
					return;


				await MobileService.SyncContext.PushAsync();
				Settings.NeedSyncFeedback = false;
			}
			catch(Exception ex)
			{
				Debug.WriteLine("Sync Failed:" + ex.Message);
			}
		}

		static readonly AzureDataStore instance = new AzureDataStore();
		/// <summary>
		/// Gets the instance of the Azure Web Service
		/// </summary>
		public static AzureDataStore Instance
		{
			get
			{
				return instance;
			}
		}

	}
}