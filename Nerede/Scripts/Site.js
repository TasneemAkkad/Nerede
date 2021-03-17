
var markerX, markerY;
let map;
var marker;
//mapı yüklemek için kullanılan fonksiyon
function initMap() {
    createMap();
    google.maps.event.addListener(map, 'click', function (event) {
        marker.setPosition(event.latLng);
    });
}
function createMap() {
    var Coords = new google.maps.LatLng(38.491858, 27.706803);
    var mapOptions =
    {
        zoom: 15,
        center: Coords,
    };
    map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
    marker = new google.maps.Marker(
        {
            size: new google.maps.Size(30, 30),
            position: Coords,
            icon: 'https://i.hizliresim.com/NMR5cc.png',
            map: map
        });
}
function currentLoc() {
    if (navigator.geolocation) {
        //kullanıcının konumunu alınıp harita üzerinde gösterilmesi için yazılan fonksiyon
        navigator.geolocation.getCurrentPosition(function (position) {
            var myLatlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            marker.setPosition(myLatlng);
            map.setCenter(myLatlng);
            map.setZoom(15);

        }, function (error) {
            alert("Error occurred. Error code: " + error.code);
            // error.code can be:
            //   0: unknown error
            //   1: permission denied
            //   2: position unavailable (error response from locaton provider)
            //   3: timed out
        });
    }

}
function getLocation() {
    $("#yKoordinat").val(marker.getPosition().lat().toString().replace(".", ","));
    $("#xKoordinat").val(marker.getPosition().lng().toString().replace(".",","));
}

function dos() {
    var arama = "/Kullanici/Arama?urunA=";
    arama += $("#productSearch").val();
    window.location = arama;
}

function silme() {
    var r = confirm("Stok Silinecek Emin Misin");
    if (r == true) {
        window.location = $(this).attr('href');
    }
    else
        return false;
}
