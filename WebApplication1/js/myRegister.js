function register() {
    var na = $("#rg_name").val();//获取文本框输入的值
    var pw = $("#rg_psw").val();
    var ad = $("#rg_address").val();
    var sex = $("#rg_sex").val();
    var mob = $("#rg_mobile").val();
    if (na == "" || pw == "" || mob == "" || sex == "" || ad == "" )
        alert("请填写完整信息");
    else {
        $.ajax({
            method: "get",
            url: "serverFile/registerSev.ashx",
            data: { "uname": na, "upassword": pw, "umobile": mob, "usex": sex, "uaddress": ad},
            error: function (request) { alert("DB连接错误！"); },
            success: function (s) {
                alert(s);
                if (s == "当前用户注册成功") {
                    window.location.href = "LoginPage.html";
                }
                else {
                    alert("用户注册失败");
                }
            }
        });
    }
}