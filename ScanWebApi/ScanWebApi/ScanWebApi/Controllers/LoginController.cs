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
    [AllowAnonymous]
    public class LoginController : BaseApiController
    {
        [HttpGet]
        public object Login(string uName, string uPassword)
        {
            
            if (!(uName== "jdserver" &&uPassword =="123456"))
            {
                return Json(new { ret = 0, data = "", msg = "用户名密码错误" });
            }
            FormsAuthenticationTicket token = new FormsAuthenticationTicket(0, uName, DateTime.Now, DateTime.Now.AddHours(12), true, $"{uName}&{uPassword}", FormsAuthentication.FormsCookiePath);
            //返回登录结果、用户信息、用户验证票据信息
            var _token = FormsAuthentication.Encrypt(token);
            //将身份信息保存在session中，验证当前请求是否是有效请求
            LoginID = uName;
            TokenValue = _token;
            HttpContext.Current.Session[LoginID] = _token;
            return Json(new { ret = 1, data = _token, msg = "登录成功！" });
        }
    }
}
