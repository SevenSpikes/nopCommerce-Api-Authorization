using System.Web.Mvc;
using NopCommerce.Api.AdapterLibrary;
using System.Web;
using System.Web.Script.Serialization;

namespace NopCommerce.Api.SampleApplication.Controllers
{
    public class ApiController : Controller
    {

        public ActionResult TryApi()
        {
            return View("~/Views/TryApi.cshtml");
        }

        [HttpGet]
        public JsonResult Get(string endpoint, string param1, string param2, string param3)
        {
            return ToJson(GetApiClient().Get(BuildApiUrl(endpoint, param1, param2, param3))); 
        }

        [HttpPost]
        public JsonResult Post(string endpoint, string param1, string param2, string param3, string body)
        {
            return ToJson(GetApiClient().Post(BuildApiUrl(endpoint, param1, param2, param3), body));
        }

        [HttpPut]
        public JsonResult Put(string endpoint, string param1, string param2, string param3, string body)
        {
            return ToJson(GetApiClient().Put(BuildApiUrl(endpoint, param1, param2, param3), body));
        }

        [HttpDelete]
        public JsonResult Delete(string endpoint, string param1, string param2, string param3)
        {
            return ToJson(GetApiClient().Delete(BuildApiUrl(endpoint, param1, param2, param3)));
        }

        private ApiClient GetApiClient()
        {
            // TODO: Here you should get the data from your database instead of the current Session.
            // Note: This should not be done in the action! This is only for illustration purposes.
            var accessToken = (Session["accessToken"] ?? TempData["accessToken"] ?? "").ToString();
            var serverUrl = (Session["serverUrl"] ?? TempData["serverUrl"] ?? "").ToString();
            
            return new ApiClient(accessToken, serverUrl);
        }

        private string BuildApiUrl(string endpoint, string param1, string param2, string param3)
        {
            string qs = HttpUtility.UrlDecode(Request.QueryString.ToString());
            return $"api/{endpoint}" +
                (string.IsNullOrEmpty(param1) ? "" : "/" + param1) +
                (string.IsNullOrEmpty(param2) ? "" : "/" + param2) +
                (string.IsNullOrEmpty(param3) ? "" : "/" + param3) +
                (string.IsNullOrEmpty(qs) ? "" : "?" + qs);
        }

        private JsonResult ToJson(object data)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            return Json(javaScriptSerializer.DeserializeObject(data.ToString()), JsonRequestBehavior.AllowGet);
        }
    }
}