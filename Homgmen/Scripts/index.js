$().ready(function () {
    //为提交数据按钮设置响应函数
    $("#tj").click(datawork);
});

function displayzt(xs) {
    $("#zhuangtai").text(xs);
}

function displayjd(fen) {
    var bfb = fen + "%";
    $(".progress-bar").css("width", bfb);
    $(".progress-bar").text(bfb);
}

/******************************************
* 数据准备函数                            *
******************************************/
function datawork() {
    displayzt("开始准备数据");
    displayjd(5);
    //获取单据数目
    $.ajax({
        url: '/Home/ReadyData',
        success: function (data) {
            var xx = "今日应提交" + data + "条数据！！！";
            displayzt(xx);
            displayjd(10);
            syncdata();
        }
    });
}

/******************************************
* 数据同步函数                            *
******************************************/
function syncdata() {
    displayzt("开始同步数据......");
    displayjd(15);
    //同步数据库
    $.ajax({
        url: '/Home/SyncData',
        success: function (data) {
            var xx = "已经同步" + data + "条数据！！！";
            displayzt(xx);
            displayjd(20);
        }
    });
}