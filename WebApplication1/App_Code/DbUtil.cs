using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

    public class DbUtil
    {
        private static string cnstr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\2019-2020作业汇总\.net高级程序设计\实验\素材7\素材\db\xixi.mdb";

        public DbUtil()
        {

        }
        public static OleDbConnection getConnection()
        {
            OleDbConnection cn = new OleDbConnection(cnstr);
            return cn;
        }

    }

  
