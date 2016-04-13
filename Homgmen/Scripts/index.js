/******************************************
* 页面载入后的初始化函数                  *
******************************************/
$().ready(function () {
    //为提交数据按钮设置响应函数
    $('#DHMGroupSideMenu_Index').addClass('active');
    $("#Upload").click(datawork);
});

/******************************************
* 显示状态文本                            *
******************************************/
function displayzt(xs) {
    $("#zhuangtai").text(xs);
}

/******************************************
* 更改状态进度条                          *
******************************************/
function displayjd(fen) {
    var bfb = fen + "%";
    $(".progress-bar").css("width", bfb);
    $(".progress-bar").text(bfb);
}

/******************************************
* 数据准备函数                            *
******************************************/
function datawork() {
    $("#Upload").attr("disabled",true);
    displayzt("开始准备数据");
    displayjd(1);
    //获取单据数目
    $.ajax({
        url: 'DHMGroup/Site/ReadyData',
        success: function (data) {
            var xx = "今日应提交" + data + "条数据！！！";
            displayzt(xx);
            displayjd(20);
            //从iPad数据库同步到上传数据库
            syncdata();
        }
    });
}

/******************************************
* 数据同步函数                            *
******************************************/
function syncdata() {
    displayzt("开始同步数据......");
    displayjd(21);
    //同步数据库
    $.ajax({
        url: 'DHMGroup/Site/SyncData',
        success: function (data) {
            var xx = "已经同步" + data + "条数据！！！";
            displayzt(xx);
            displayjd(40);
            //上传今日数据函数
            uploaddata()
        }
    });
}

/******************************************
* 数据上传函数                            *
******************************************/
function uploaddata() {
    displayzt("开始向大红门集团上传数据......");
    displayjd(41);
    $.ajax({
        url: 'DHMGroup/Site/UploadData',
        success: function (data) {
            var xx = "已经向大红门集团上报" + data + "条数据！！！";
            displayzt(xx);
            displayjd(60);
            UploadDhData();
        }
    });
}

/******************************************
* 获取并上报当日到货单据                  *
******************************************/
function UploadDhData() {
    displayzt("开始向大红门集团上报当日到货单据......");
    displayjd(61);
    $.ajax({
        url: 'DHMGroup/Site/UploadDH',
        success: function (data) {
            var xx = "今日到货单据为" + data + "条，已上报大红门集团！！！";
            displayzt(xx);
            displayjd(80);
            UploadFK();
        }
    });
}

/******************************************
* 获取并上报当日汇款函数                  *
******************************************/
function UploadFK() {
    displayzt("开始向大红门集团上报单日汇款数据......");
    displayjd(81);
    $.ajax({
        url: 'DHMGroup/Site/UploadFK',
        success: function (data) {
            var xx = "今日付款单据数量为" + data + "条，已上报大红门集团";
            displayzt(xx);
            displayjd(100);
            window.location.href = "DHMGroup";
        }
    });
}

