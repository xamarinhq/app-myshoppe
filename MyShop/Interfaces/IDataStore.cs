using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyShop
{
	public interface IDataStore
	{
		Task Init();
		Task<IEnumerable<Store>> GetStoresAsync();
		Task<Store> AddStoreAsync (Store store);
		Task<bool> RemoveStoreAsync(Store store);
		Task<Store> UpdateStoreAsync (Store store);
		Task<Feedback> AddFeedbackAsync(Feedback feedback);
		Task<IEnumerable<Feedback>> GetFeedbackAsync();
		Task<bool> RemoveFeedbackAsync(Feedback feedback);
		Task SyncStoresAsync();
		Task SyncFeedbacksAsync();
	}
}

