<%@ WebHandler Language="C#" Class="LoginSev" %>

using System;
using System.Web;

public class LoginSev : IHttpHandler {

    private UserDao user =  new UserDao();
        
     
    public void ProcessRequest (HttpContext context) {
          
           
        context.Response.ContentType = "text/plain";
        string un = context.Request.QueryString["uname"];
        string up = context.Request.QueryString["upassword"];
        string um = context.Request.QueryString["umobile"];
        string us = context.Request.QueryString["usex"];
        string ua = context.Request.QueryString["uaddress"];

        string str;

        user.zhuce(un, up, um, us, ua, out str);

        context.Response.Write(str);

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}