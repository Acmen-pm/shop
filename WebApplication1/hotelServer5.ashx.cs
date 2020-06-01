using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace WebApplication1
{
    /// <summary>
    /// hotelServer5 的摘要说明
    /// </summary>
    public class hotelServer5 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string feng = context.Request["taste"];
            var conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\2019-2020作业汇总\.net高级程序设计\实验\素材7\素材\db\HotelDb.mdb");
            conn.Open();
            string sqls = "select [餐谱编号],[名称] from [餐谱] where [风味]='" + feng + "'";
            var reader = new OleDbCommand(sqls, conn).ExecuteReader();

            var map = new Dictionary<int, string>();
            var str = "{";
            while (reader.Read())
            {
                str += reader["餐谱编号"] + ":'" + reader["名称"] + "',";
            }
            str += "}";  //查询【法式】成功后组合的json串为：{3：古典烧烤牛仔排，7：鲜虾杂菜沙津，9：苹果蛋奶酥班戟}

            context.Response.Clear();
            context.Response.Write(str);
            context.Response.Flush();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}