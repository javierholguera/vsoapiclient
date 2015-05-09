namespace MarketInvoice.Api
{
    using System.Web.Http;
    using VsoApi.Backend.Infrastructure;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new BasicAuthenticationFilter());
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{action}/{id}", new {id = RouteParameter.Optional});
            config.EnsureInitialized();

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            // Javier's note: To enable this, we need Microsoft.AspNet.WebApi.Tracing.4.0.0 added to the project
            // config.EnableSystemDiagnosticsTracing(); 
        }
    }
}