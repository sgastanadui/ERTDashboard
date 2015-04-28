//populateDropdown = function (data) {
//    var Username, IdUsername, Name, Rol;
//    Username = this.Username;
//    IdUsername = this.IdUsername;
//    Name = this.Name;
//    Rol = this.Rol;
//    $("#results").html("");
//    $("#results").append("<span>" + data.Name + "</span><br/><span>" + data.IdUsername + "</span><br/><span>" + data.Username + "</span><br/><span>" + data.Rol + "</span><br/>");
//};

(function () {
    "use strict";

    document.addEventListener('deviceready', onDeviceReady.bind(this), false);

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener('pause', onPause.bind(this), false);
        document.addEventListener('resume', onResume.bind(this), false);

        $("#btnLogin").click(function () {
            //var params = { a: $("#first").val(), b: $("#second").val() };
            //var params = "{ UserName: 'Santi', Password: 'DDDD' }";
            //var parametros = { "UserName": $("#txtUsername").val(), "Password": $("#txtPassword").val() };

            if ($("#txtUsername").val().trim() == "") {
                //navigator.notification.alert("Enter a Username", function () { });
                alert("Enter a Username");
                return false;
            }

            if ($("#txtPassword").val().trim() == "") {
                //navigator.notification.alert("Enter a Password", function () { });
                alert("Enter a Password");
                return false;
            }

            //wcfServiceUrl = "https://www.chancesrmis.com/wcfphonegap/AutenticationMobile.svc/";
            wcfServiceUrl = "http://23.253.204.98/wcfphonegap/AutenticationMobile.svc/";
            //wcfServiceUrl = "http://localhost:10786/AutenticationMobile.svc/";
            //wcfServiceUrl = "http://localhost:10786/UserAutentication.svc/";

            //var urlk1 = wcfServiceUrl + "Login?UserName=" + $("#txtUsername").val() + "&Password=" + $("#txtPassword").val() + "";
            var urlk1 = wcfServiceUrl + "AutenticationUser?IdUsername=" + $("#txtUsername").val() + "&Password=" + $("#txtPassword").val() + "&IdAplication=2";
            //var urlk1 = wcfServiceUrl + "Login?UserName=" + JSON.stringify($("#txtUsername").val()) + "&Password=" + JSON.stringify($("#txtPassword").val()) + "";

            $.ajax({
                cache: true,
                url: urlk1,
                crossDomain: true,
                //data: "{ UserName: " + JSON.stringify($("#txtUsername").val()) + ", Password: " + JSON.stringify($("#txtPassword").val()) + " }",
                data: "{ UserName: " + $("#txtUsername").val() + ", Password: " + $("#txtPassword").val() + ", IdAplication: 4 }",
                type: "GET",
                jsonpCallback: "UserApplication",
                //contentType: "application/javascript",
                contentType: "application/json; charset=utf-8",
                dataType: "jsonp",
                beforeSend: function () {
                    //$("#results").html("Procesando, espere por favor...");
                    //$('#results').html("<img src='images/ajax-loader.gif' />");
                    //$("#results").addClass("loading");
                    $("#imgAjaxLoader").show();
                },
                error: function (xhr, textStatus, err) {
                    var mensaje = "readyState: " + xhr.readyState + "\n";
                    mensaje = mensaje + "responseText: " + xhr.responseText + "\n";
                    mensaje = mensaje + "status: " + xhr.status + "\n";
                    mensaje = mensaje + "text status: " + textStatus + "\n";
                    mensaje = mensaje + "error: " + err + "\n";
                    alert(mensaje);
                    $('#results').html("");
                },
                success: function (obj) {
                    //$.each(menu, populateDropdown); // must call function as var
                    //populateDropdown(obj);
                    if (obj.AutenticationUserResult.error.Descripcion == '') {
                        //window.localStorage["username"] = obj.AutenticationUserResult.IdUsuario;
                        window.localStorage["IdCompany"] = obj.AutenticationUserResult.IdCompany;
                        //window.localStorage["IdGroupCompany"] = obj.AutenticationUserResult.IdGroupCompany;
                        window.localStorage["CompanyName"] = obj.AutenticationUserResult.CompanyName;
                        window.localStorage["IdContact"] = obj.AutenticationUserResult.IdContact;
                        window.localStorage["ContactName"] = obj.AutenticationUserResult.ContactName;
                        //window.localStorage["Email"] = obj.AutenticationUserResult.Email;
                        $('#results').html("");
                        //$.mobile.changePage("default.html");
                        //$.mobile.changePage("default.html?param1=" + encodeURIComponent(obj.AutenticationUserResult.IdCompany) + "&company="+ encodeURIComponent(obj.AutenticationUserResult.CompanyName) +"");
                        //$.mobile.changePage("default.html", { data: { 'param1': IdCompany } });

                        var argValue = obj.AutenticationUserResult.CompanyName;
                        //$.mobile.changePage("default.html", { data: { param1: argValue } });
                        //$.mobile.changePage("default.html");
                        window.location.href = 'default.html';
                    } else {
                        switch (obj.AutenticationUserResult.error.Descripcion) {
                            case '1':
                                $('#results').html("<span>Inactive Company. Please contact administrator.</span>");
                                break;
                            case '2':
                                $('#results').html("<span>Incorrect password.</span>");
                                break;
                            case '3':
                                $('#results').html("<span>Inactive User. Please contact administrator.</span>");
                                break;
                            case '4':
                                $('#results').html("<span>Username not found.</span>");
                                break;
                        }
                    }

                    //var userId = localStorage.getItem("userId");
                    //if (userId == null || userId == 0) { jQT.goTo("#login"); }

                },
                complete: function () {
                    $("#imgAjaxLoader").hide();
                }
            });

        });


    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };

    var wcfServiceUrl = "http://localhost:43070/Autentication.svc/";

    //function LoginUser() {
    //    //var Data1 = '{"UserName": "' + $("#txtUsername").val() + '"}';
    //    var Data1 = '{UserName: Santi}';
    //    //var Data2 = '{"Password": "' + $("#txtPassword").val() + '"}';
    //    var Data2 = '{Password: gretta}';

    //    var jsonString1 = JSON.stringify(Data1);
    //    var jsonString2 = JSON.stringify(Data2);
    //    var urlk1 = wcfServiceUrl + "Login/UserName=" + jsonString1 + '/Password=' + jsonString2;

    //    $.ajax({
    //        url: urlk1,
    //        type: "GET",
    //        contentType: "application/javascript",
    //        dataType: "jsonp",
    //        //jsonpCallback: "OrderResponse",
    //        error: function () {
    //            alert("Order failed!");
    //        },
    //        success: function (confirmation) {
    //            alert(confirmation.toString());
    //        }
    //    });
    //}

})();