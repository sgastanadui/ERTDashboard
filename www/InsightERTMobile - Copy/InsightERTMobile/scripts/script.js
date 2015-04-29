var wcfServiceUrl;

(function () {
    wcfServiceUrl = "http://localhost:43070/Autentication.svc/";

    $(function () {
        $("#btnLogin").click(WCFJSON);
    });

    $(document).ready(function () {
        WCFJSON();
    });


    function WCFJSON() {
        var Data1 = '{"UserName": "' + $("#txtUsername").val() + '"}';
        var Data2 = '{"Password": "' + $("#txtPassword").val() + '"}';
        //var jsonString = JSON.stringify({ restaurantOrder: data });
        var jsonString1 = JSON.stringify(Data1);
        var jsonString2 = JSON.stringify(Data2);

        $.ajax({
            url: wcfServiceUrl + "Login?UserName=" + jsonString1 + '/Password=' + jsonString2,
            type: "GET",
            contentType: "application/javascript",
            dataType: "jsonp",
            //jsonpCallback: "OrderResponse",
            error: function () {
                alert("Order failed!");
            },
            success: function (confirmation) {
                alert(confirmation.toString());
            }
        });
    }

    // Function to call WCF  Service       
    function CallService() {
        $.ajax({
            type: Type, //GET or POST or PUT or DELETE verb
            url: Url, // Location of the service
            data: Data, //Data sent to server
            contentType: ContentType, // content type sent to server
            dataType: DataType, //Expected data format from server
            processdata: ProcessData, //True or False
            success: function (msg) {//On Successfull service call
                ServiceSucceeded(msg);
            },
            error: ServiceFailed// When Service call fails
        });
    }

    function ServiceFailed(result) {
        alert('Service call failed: ' + result.status + '' + result.statusText);
        Type = null;
        varUrl = null;
        Data = null;
        ContentType = null;
        DataType = null;
        ProcessData = null;
    }


})