function login() {
    var uname = $("#name").val();//获取文本框输入的值
    var upsw = $("#psw").val();
    if (uname == "" || upsw == "")
        alert("用户名密码为空，请补全");
    else {
        $.ajax({
            method: "get",
            url: "serverFile/LoginSev.ashx",//服务器文件名   //url: 服务端的文件信息;
            data: { "name": uname, "password": upsw},//json格式
            error: function (request) { alert("DB连接错误！"); },
            success: function (s) {
                if (s == "用户名错误")
                    alert("无此用户");
                else if (s == "密码错误")
                    alert("有此用户，但是密码输入错误");                   
                else {
                    alert(s + "用户登陆成功");
                }//else结束
            }//success结束
        });//ajax结束
    }//else结束
}//login结束
