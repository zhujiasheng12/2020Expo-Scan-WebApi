﻿using Microsoft.Ajax.Utilities;
using ScanWebApi.App_Start;
using ScanWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ScanWebApi.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [TokenCheckFilter]
    //[AllowAnonymous]
    public class ScanMethodController : BaseApiController
    {

        /// <summary>
        /// 扫描调用的方法
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostScan([FromBody] string result)
        {
            try
            {
                result = HttpContext.Current.Request.Form["result"];
                return Json ( ScanManage.ScanMethod(result));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }


        /// <summary>
        /// 获取看板信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetData()
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var data = ScanManage.GetData();
                //string json = serializer.Serialize(data);
                //return json;
                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { err = ex.Message });
            }
        }
    }
}
