using AGLTest.Results;
using System;
using System.Configuration;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace AGLTest.Controllers
{
    public class CatsController : ApiController
    {
        private const string SERVICEURL = "ServiceUrl";
        private const string SERVICEURL_MISSING = "Service Url is missing !";
        // GET: api/Cats
        [System.Web.Http.HttpGet]
        public NewtonJsonResult GetAllCats()
        {
            string url = ConfigurationManager.AppSettings[SERVICEURL];
            var resultJson = new NewtonJsonResult() { Model = string.Empty, StatusCode = HttpStatusCode.OK, JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentType = "application/json" };
            if (!string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    var webClient = new WebClient();
                    var content = webClient.DownloadString(url);

                    resultJson.Model = content;
                }
                catch (Exception e)
                {
                    resultJson.StatusCode = HttpStatusCode.NotFound;
                    resultJson.Model = e.Message.ToString();
                }
            }
            else
            {
                resultJson.StatusCode = HttpStatusCode.BadRequest;
                resultJson.Model = SERVICEURL_MISSING;
            }
            return resultJson;
        }
    }
}
