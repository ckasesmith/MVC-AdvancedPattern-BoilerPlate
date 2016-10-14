using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            string culture = requestContext.HttpContext.Request.QueryString["culture"];
            if (culture == null)
            {
                var requestCookie = requestContext.HttpContext.Request.Cookies["culture"];
                if (requestCookie != null)
                    culture = requestCookie.Value;
            }
            if (!String.IsNullOrEmpty(culture))
            {
                SetCulture(culture, requestContext);
            }
            base.Initialize(requestContext);
        }


        private void SetCulture(string culture, RequestContext requestContext)
        {
            culture = culture ?? "en";
            ViewBag.Culture = culture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);

            HttpCookie myCookie = new HttpCookie("culture")
            {
                Value = culture,
                Expires = DateTime.Now.AddYears(1)
            };

            requestContext.HttpContext.Response.Cookies.Add(myCookie);
        }
    }
}