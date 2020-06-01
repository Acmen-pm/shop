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
            if (p == rd["Upassword"].ToString() && n == rd["Uname"].ToString())
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
    public bool zhuce(string n, string p, string m, string s, string a, out string result)
    {
        bool flag = false;
        OleDbConnection cn = DbUtil.getConnection();

        cn.Open();
        string sqls = "insert into [user] (Uname,Upassword,Uemail,Usex,Uaddress,lei) values('" + n + "','" + p + "','" + m + "','" + s + "','" + a + "','l');";
        OleDbCommand cmd = new OleDbCommand(sqls, cn);


        int i;
        i = cmd.ExecuteNonQuery();
        if (i != 0)
        {
            result = "当前用户注册成功";
            flag = true;
        }
        else
        {
            result = "用户注册失败";
            flag = false;
        }
        return flag;
      

    }
}
