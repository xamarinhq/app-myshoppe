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
    public class FeedbackController : TableController<Feedback>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MyShopAppContext context = new MyShopAppContext();
            DomainManager = new EntityDomainManager<Feedback>(context, Request, Services);
        }

        // GET tables/Feedback
        public IQueryable<Feedback> GetAllFeedback()
        {
            return Query(); 
        }

        // GET tables/Feedback/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Feedback> GetFeedback(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Feedback/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Feedback> PatchFeedback(string id, Delta<Feedback> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Feedback
        public async Task<IHttpActionResult> PostFeedback(Feedback item)
        {
            Feedback current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Feedback/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteFeedback(string id)
        {
             return DeleteAsync(id);
        }

    }
}