namespace VsoApi.Backend
{
    using System;
    using System.Web;
    using System.Web.Http;
    using MarketInvoice.Api;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}