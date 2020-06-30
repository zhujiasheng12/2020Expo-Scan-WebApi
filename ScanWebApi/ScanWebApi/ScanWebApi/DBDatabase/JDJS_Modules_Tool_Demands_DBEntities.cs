namespace ScanWebApi.DBDatabase
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class JDJS_Modules_Tool_Demands_DBEntities : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“JDJS_Modules_Tool_Demands_DBEntities”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“ScanWebApi.DBDatabase.JDJS_Modules_Tool_Demands_DBEntities”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“JDJS_Modules_Tool_Demands_DBEntities”
        //连接字符串。
        public JDJS_Modules_Tool_Demands_DBEntities()
            : base("name=JDJS_Modules_Tool_Demands_DBEntities")
        {
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

         public virtual DbSet<ScanResultTable> ScanResultTable { get; set; }
        public virtual DbSet<DataSource> DataSource { get; set; }
    }

    public class ScanResultTable
    {
        [Key]
        public int ID { get; set; }
        public string ScanResult { get; set; }
        public string Type { get; set; }
    }
    public class DataSource
    {
        [Key]
        public int ID { get; set; }
        public string HiltNum { get; set; }
        public string HiltSpecification { get; set; }
        public string ToolSpecification { get; set; }
        public string ToolId { get; set; }
        public string ToolName { get; set; }
        public string ToolLength { get; set; }
        public string ToolCurrLife { get; set; }
        public string ToolMaxLife { get; set; }
        public string ToolTheoryR { get; set; }
        public string ToolRealR { get; set; }
        public string ToolJump { get; set; }
    }
}