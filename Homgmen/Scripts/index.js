/*****************************************
* 创建数据对象类                         *
*****************************************/
var resultTable = new Object();

$().ready(function () {
    //为提交数据按钮设置响应函数
    $("#Upload").click(datawork);
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
    displayjd(8);
    //获取单据数目
    $.ajax({
        url: 'DHMGroup/Site/ReadyData',
        success: function (data) {
            var xx = "今日应提交" + data + "条数据！！！";
            resultTable.TodayRowNumber = data;
            displayzt(xx);
            displayjd(16);
            syncdata();
        }
    });
}

/******************************************
* 数据同步函数                            *
******************************************/
function syncdata() {
    displayzt("开始同步数据......");
    displayjd(24);
    //同步数据库
    $.ajax({
        url: '/Home/SyncData',
        success: function (data) {
            var xx = "已经同步" + data + "条数据！！！";
            displayzt(xx);
            displayjd(32);
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
    displayjd(40);
    $.ajax({
        url: '/Home/UploadData',
        success: function (data) {
            var xx = "已经向大红门集团上报" + data + "条数据！！！";
            displayzt(xx);
            displayjd(48);
            getdsjine();
        }
    });
}

/******************************************
* 获取当日代收金额函数                    *
******************************************/
function getdsjine() {
    displayzt("开始获取当日代收金额......");
    displayjd(56);
    $.ajax({
        url: '/Home/GetDSJine',
        success: function (data) {
            var xx = "今日代收金额为人民币" + data + "元整!!!";
            displayzt(xx);
            displayjd(64);
            UploadDhData();
        }
    });
}

/******************************************
* 获取并上报当日到货单据                  *
******************************************/
function UploadDhData() {
    displayzt("开始向大红门集团上报当日到货单据......");
    displayjd(76);
    $.ajax({
        url: '/Home/UploadDH',
        success: function (data) {
            var xx = "今日到货单据为" + data + "条，已上报大红门集团！！！";
            displayzt(xx);
            displayjd(84);
            UploadFK();
        }
    });
}

/******************************************
* 获取并上报当日汇款函数                  *
******************************************/
function UploadFK() {
    displayzt("开始向大红门集团上报单日汇款数据......");
    displayjd(92);
    $.ajax({
        url: '/Home/UploadFK',
        success: function (data) {
            var xx = "今日付款单据数量为" + data + "条，已上报大红门集团";
            displayzt(xx);
            displayjd(100);
        }
    });
}

