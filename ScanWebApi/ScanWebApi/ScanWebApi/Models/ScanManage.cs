using ScanWebApi.DBDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScanWebApi.Models
{
    public class ScanManage
    {
        /// <summary>
        /// 扫描的方法
        /// </summary>
        /// <param name="lpMsg">扫描的内容</param>
        public static string ScanMethod(string lpMsg)
        {
            //lpRichTextBox.AppendText(lpMsg);
            // MessageBox.Show(lpMsg, "结果");
            if (lpMsg != null && lpMsg != "")
            {
                try
                {
                    string type = "";
                    if (lpMsg.StartsWith("TS") || lpMsg.StartsWith("ts"))
                    {
                        type = "刀柄";
                    }
                    else
                    {
                        type = "刀具";
                    }
                    using (JDJS_Modules_Tool_Demands_DBEntities model = new JDJS_Modules_Tool_Demands_DBEntities())
                    {
                        var table = model.ScanResultTable;
                        if (table.Count() < 1)
                        {

                            ScanResultTable sc = new ScanResultTable()
                            {
                                ScanResult = lpMsg,
                                Type = type

                            };
                            using (System.Data.Entity.DbContextTransaction mytran = model.Database.BeginTransaction())
                            {
                                try
                                {
                                    model.ScanResultTable.Add(sc);
                                    model.SaveChanges();
                                    mytran.Commit();
                                }
                                catch (Exception ex)
                                {
                                    mytran.Rollback();
                                }
                            }
                        }
                        else
                        {
                            using (System.Data.Entity.DbContextTransaction mytran = model.Database.BeginTransaction())
                            {
                                try
                                {
                                    foreach (var item in table)
                                    {
                                        item.ScanResult = lpMsg;
                                        item.Type = type;
                                    }
                                    model.SaveChanges();
                                    mytran.Commit();
                                }
                                catch (Exception ex)
                                {
                                    mytran.Rollback();
                                }
                            }
                        }
                    }

                    lpMsg = "";
                    return "ok";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    lpMsg = "";
                }
            }
            else
            {
                return "ok";
            }

        }

        /// <summary>
        /// 获取扫描之后的数据
        /// </summary>
        /// <returns></returns>
        public static DataSourceClass GetData()
        {
            DataSourceClass data = new DataSourceClass();
            DataSource source = new DataSource();
            try
            {
                using (JDJS_Modules_Tool_Demands_DBEntities model = new JDJS_Modules_Tool_Demands_DBEntities())
                {
                    var scan = model.ScanResultTable.FirstOrDefault();
                    if (scan != null)
                    {
                        if (scan.Type == "刀柄")
                        {
                            data.scanType = "扫描刀柄编号：";
                            data.scanResult = "扫描刀柄编号：" + scan.ScanResult;
                            source = model.DataSource.Where(r => r.HiltNum == scan.ScanResult).FirstOrDefault();
                        }
                        else if (scan.Type == "刀具")
                        {
                            data.scanType = "扫描刀具ID：";
                            data.scanResult = "扫描刀具ID：" + scan.ScanResult;
                            source = model.DataSource.Where(r => r.ToolId == scan.ScanResult).FirstOrDefault();
                        }
                        if (source != null)
                        {
                            data.ID = source.ID;
                            data.HiltNum = source.HiltNum == null ? "" : source.HiltNum;
                            data.HiltSpecification = source.HiltSpecification == null ? "" : source.HiltSpecification;
                            data.ToolCurrLife = source.ToolCurrLife == null ? "" : source.ToolCurrLife;
                            data.ToolId = source.ToolId == null ? "" : source.ToolId;
                            data.ToolJump = source.ToolJump == null ? "" : source.ToolJump;
                            data.ToolLength = source.ToolLength == null ? "" : source.ToolLength;
                            data.ToolMaxLife = source.ToolMaxLife == null ? "" : source.ToolMaxLife;
                            data.ToolName = source.ToolName == null ? "" : source.ToolName;
                            data.ToolRealR = source.ToolRealR == null ? "" : source.ToolRealR;
                            data.ToolSpecification = source.ToolSpecification == null ? "" : source.ToolSpecification;
                            data.ToolTheoryR = source.ToolTheoryR == null ? "" : source.ToolTheoryR;

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }
    }
    public class DataSourceClass
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID;
        /// <summary>
        /// 扫描类型
        /// </summary>
        public string scanType;
        /// <summary>
        /// 扫描结果
        /// </summary>
        public string scanResult;
        /// <summary>
        /// 刀柄编号
        /// </summary>
        public string HiltNum;
        /// <summary>
        /// 刀柄规格
        /// </summary>
        public string HiltSpecification;
        /// <summary>
        /// 刀具规格
        /// </summary>
        public string ToolSpecification;
        /// <summary>
        /// 刀具ID
        /// </summary>
        public string ToolId;
        /// <summary>
        /// 刀具名称
        /// </summary>
        public string ToolName;
        /// <summary>
        /// 装夹长度
        /// </summary>
        public string ToolLength;
        /// <summary>
        /// 当前寿命
        /// </summary>
        public string ToolCurrLife;
        /// <summary>
        /// 最大寿命
        /// </summary>
        public string ToolMaxLife;
        /// <summary>
        /// 刀具理论半径
        /// </summary>
        public string ToolTheoryR;
        /// <summary>
        /// 刀具实际半径
        /// </summary>
        public string ToolRealR;
        /// <summary>
        /// 刀跳
        /// </summary>
        public string ToolJump;

    }

}