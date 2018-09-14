using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppDomain.Model.ExampleAggregate.Repositories;
using AppHTTPProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Extensions.Http;

namespace Samples.DomainGatewayApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register applciation services
            services.AddScoped(typeof(IMenuRepository), typeof(MenuApiRepository));

            //register http services
            services.AddHttpClient<MenuApiRepository>()
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());

            //services.AddLogging(loggingBuilder => loggingBuilder.AddToolfactoryLogging(this.Configuration.GetSection("Logging"), DataProviderPostgreSQL.ApplicationId.Name));


            // Add framework services.
            services.AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddApiExplorer()
                .AddJsonFormatters(o => o.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBluekiriDevelopMiddlewares();
            }
            else
            {
                app.UseBluekiriProductionMiddlewares();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Values}/{action=Index}/{id?}");
            });
        }


        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
        }

    }
}
