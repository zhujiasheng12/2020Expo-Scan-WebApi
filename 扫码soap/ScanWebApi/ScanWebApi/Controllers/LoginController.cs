using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace ScanWebApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public object Login(string uName, string uPassword)
        {
            return Json(new { ret = 1, data = "111", msg = "登录成功！" });
        }
    }
}
