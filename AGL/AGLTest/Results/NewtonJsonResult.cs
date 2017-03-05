using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AGLTest.Results
{
    public class NewtonJsonResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Model { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public JsonRequestBehavior JsonRequestBehavior { get; set; }

        public NewtonJsonResult()
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Cannot perfom GET request.");
            }

            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Model != null)
            {
                response.Write(JsonConvert.SerializeObject(this.Model));
            }
        }
    }
}