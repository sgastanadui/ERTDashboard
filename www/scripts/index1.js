var app = {
    // Application Constructor
    initialize: function () {
        this.bindEvents();
    },
    // Bind Event Listeners
    //
    // Bind any events that are required on startup. Common events are:
    // 'load', 'deviceready', 'offline', and 'online'.
    bindEvents: function () {
        document.addEventListener('deviceready', this.onDeviceReady, false);
    },
    // deviceready Event Handler
    //
    // The scope of 'this' is the event. In order to call the 'receivedEvent'
    // function, we must explicitly call 'app.receivedEvent(...);'
    onDeviceReady: function () {
        // app.receivedEvent('deviceready');
        //alert('gfffh');
        navigator.geolocation.getCurrentPosition(app.onSuccess, app.onError);
    },

    onSuccess: function (position) {
        var longitude = position.coords.longitude;
        var latitude = position.coords.latitude;
        latitude = 27.985856;
        longitude = -81.959907
        console.log('longitude: ' + longitude);
        console.log('latitude: ' + latitude);
        var latLong = new google.maps.LatLng(latitude, longitude);
        //var mapOptions = {
        //    center: latLong,
        //    zoom: 13,
        //    mapTypeId: google.maps.MapTypeId.ROADMAP
        //};
        console.log('paso 1');
        //pintamos el mapa
        var mapOptions = {
            zoom: 14,
            center: latLong,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            backgroundColor: '#ffffff',
            noClear: true,
            disableDefaultUI: false,
            keyboardShortcuts: true,
            disableDoubleClickZoom: false,
            draggable: true,
            scrollwheel: true,
            draggableCursor: 'pointer',
            draggingCursor: 'crosshair',
            mapTypeControl: true,
            //mapTypeControlOptions: {
            //    style: google.maps.MapTypeControlStyle.HORIZONTAL_MENU,
            //    position: google.maps.ControlPosition.TOP_LEFT,
            //    mapTypeIds: [
            //        google.maps.MapTypeId.ROADMAP
            //    ]
            //},
            navigationControl: true,
            streetViewControl: true,
            navigationControlOptions: {
                position: google.maps.ControlPosition.TOP_LEFT,
                style: google.maps.NavigationControlStyle.ANDROID
            },
            scaleControl: true,
            scaleControlOptions: {
                position: google.maps.ControlPosition.TOP_LEFT,
                style: google.maps.ScaleControlStyle.DEFAULT
            }
        };

        var map = new google.maps.Map(document.getElementById("map"), mapOptions);
        //var marker = new google.maps.Marker({
        //    position: latLong,
        //    map: map,
        //    title: 'my location'
        //});

        var marker = new google.maps.Marker({
            position: latLong,
            map: map,
            animation: google.maps.Animation.BOUNCE,
            title: 'Insight Risk Technologies, LLC',
            icon: 'https://www.chancesrmis.com/um-usa/img/Logos/chancesr.jpg',
            cursor: 'pointer',
            draggable: true
        });

    },

    onError: function (error) {
        alert("the code is " + error.code + ". \n" + "message: " + error.message);
    },
};

app.initialize();