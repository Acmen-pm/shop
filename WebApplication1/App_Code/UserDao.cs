using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;


    public class UserDao
    {
       
        public bool denglu(string n, string p, out string result)
        {
           bool flag = false;
           OleDbConnection cn = DbUtil.getConnection();

           cn.Open();
           string sqls = "select * from [user] where Uname='" + n + "' and Upassword ='" + p + "'";
         //  string sqls = string.Format("select * from [user] where Uname = '{0}' and Upassword = '{1}'", n, p);

           OleDbCommand cmd = cn.CreateCommand();
           cmd.CommandText = sqls;

           OleDbDataReader rd = cmd.ExecuteReader();
        if (rd.Read())
        {
            if (p == rd["Upassword"].ToString())
            {
                flag = true;
                result = rd["ID"].ToString();
            }
            else
            {
                flag = false;
                result = "密码错误";
            }
        }
        else
            result = "用户名错误";
        return flag;

    }
}
