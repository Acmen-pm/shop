<%@ WebHandler Language="C#" Class="LoginSev" %>
using System;
using System.Web;


public class LoginSev : IHttpHandler {

    private UserDao userDao =  new UserDao();
    public void ProcessRequest (HttpContext context) {
          context.Response.ContentType = "test/plain";
          string na = context.Request.QueryString["name"];
          string ps = context.Request.QueryString["password"];
          string jieguo;
          userDao.denglu(na, ps, out jieguo);
          context.Response.Write(jieguo);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}