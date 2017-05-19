using System.Text;
using System.Collections.Generic;
using Jose;
using Microsoft.AspNetCore.Mvc;

namespace JwtTest.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {

        public JsonResult Get()
        {
            var payload = new Dictionary<string, object>()
            {
                {"iss", "http://www.jerriepelser.com"},
                {"aud", "blog-readers"},
                {"sub", "123456"},
                {"exp", 1499863217},
                {"roles", new string []{"Suppervisor"}}
            };
            var secretKey = Encoding.UTF8.GetBytes("minhasupersenhasecreta");
            string token = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
            return Json(new {Token = token});
        }
    }
}