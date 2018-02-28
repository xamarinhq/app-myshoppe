using Plugin.Messaging;
using MyShop.Services;
using Newtonsoft.Json;
using PCLStorage;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(OfflineDataStore))]
namespace MyShop.Services
{
    public class OfflineDataStore : IDataStore
    {

        public async Task<IEnumerable<Store>> GetStoresAsync()
        {
            var json = ResourceLoader.GetEmbeddedResourceString(Assembly.Load(new AssemblyName("MyShop")), "stores.json");
            return await Task.Run(() => JsonConvert.DeserializeObject<List<Store>>(json));
        }

        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            var emailTask = CrossMessaging.Current.EmailMessenger;
            if (emailTask.CanSendEmail)
            {
                emailTask.SendEmail("james.montemagno@xamarin.com", "My Shop Feedback", feedback.ToString());
            }

            return await Task.Run(() => { return feedback; });
        }

        public Task<Store> AddStoreAsync(Store store)
        {
            return Task.FromResult(store);
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackAsync()
        {
            return await Task.Run(() => { return new List<Feedback>(); });
        }


        public Task Init()
        {
            return Task.Run(() => { });
        }

        public Task<bool> RemoveFeedbackAsync(Feedback feedback)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RemoveStoreAsync(Store store)
        {
            return Task.FromResult(true);
        }

        public Task SyncFeedbacksAsync()
        {
            return Task.Run(() => { });
        }

        public Task SyncStoresAsync()
        {
            return Task.Run(() => { });
        }

        public Task<Store> UpdateStoreAsync(Store store)
        {
            return Task.FromResult(store);
        }
    }
}
