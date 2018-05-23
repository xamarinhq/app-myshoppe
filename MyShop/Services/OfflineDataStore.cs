using MyShop.Services;
using Newtonsoft.Json;
using Plugin.EmbeddedResource;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Essentials;

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

        public async Task AddFeedbackAsync(Feedback feedback) =>
            await Email.ComposeAsync("My Shop Feedback", feedback.ToString(), "james.montemagno@xamarin.com");

        public Task<Store> AddStoreAsync(Store store) => Task.FromResult(store);

        public async Task<IEnumerable<Feedback>> GetFeedbackAsync() =>
             await Task.Run(() => { return new List<Feedback>(); });
        
        public Task Init() => Task.Run(() => { });
        
        public Task<bool> RemoveFeedbackAsync(Feedback feedback) => Task.FromResult(true);

        public Task<bool> RemoveStoreAsync(Store store) => Task.FromResult(true);

        public Task SyncFeedbacksAsync() =>  Task.Run(() => { });
        
        public Task SyncStoresAsync() => Task.Run(() => { });
        
        public Task<Store> UpdateStoreAsync(Store store) => Task.FromResult(store);
    }
}
