using ScanWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScanWebApi.Controllers
{
    public class ScanMethodController : ApiController
    {

        /// <summary>
        /// 扫描调用的方法
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [HttpPost]
        public void PostScan([FromBody] string result)
        {
            try
            {
               ScanManage.ScanMethod(result);
            }
            catch (Exception ex)
            {
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
               
                var data = ScanManage.GetData();
                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { err = ex.Message });
            }
        }
    }
}
