using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.AppService.Config;
using MyShopAppService.DataObjects;
using MyShopAppService.Models;

namespace MyShopAppService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            AppServiceExtensionConfig.Initialize();
            
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            
            Database.SetInitializer(new MyShopAppInitializer());
        }
    }

    public class MyShopAppInitializer : ClearDatabaseSchemaIfModelChanges<MyShopAppContext>
    {
        protected override void Seed(MyShopAppContext context)
        {
					//seed data
           /* List<Store> todoItems = new List<Store>
            {
                new Store { Id = Guid.NewGuid().ToString()},
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<Store>().Add(todoItem);
            }*/

            base.Seed(context);
        }
    }
}

