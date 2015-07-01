using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.AppService;
using MyShopAppService.DataObjects;
using MyShopAppService.Models;

namespace MyShopAppService.Controllers
{
    public class StoreController : TableController<Store>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MyShopAppContext context = new MyShopAppContext();
            DomainManager = new EntityDomainManager<Store>(context, Request, Services);
        }

        // GET tables/Store
        public IQueryable<Store> GetAllStore()
        {
            return Query(); 
        }

        // GET tables/Store/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Store> GetStore(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Store/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Store> PatchStore(string id, Delta<Store> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Store
        public async Task<IHttpActionResult> PostStore(Store item)
        {
            Store current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Store/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteStore(string id)
        {
             return DeleteAsync(id);
        }

    }
}