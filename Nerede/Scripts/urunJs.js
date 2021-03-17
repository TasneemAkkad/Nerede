var infowindow1;
var dukkanMarker;
var dukkanX;
var dukkanY;
$("document").ready(function () {
    var kullaniciX = Number($("#xKoordinat").val().replace(",", "."));
    var kullaniciY = Number($("#yKoordinat").val().replace(",", "."));
    var myLatlng = new google.maps.LatLng(kullaniciY, kullaniciX);
    marker.setPosition(myLatlng);
    map.setCenter(myLatlng);
    map.setZoom(15);
    $("#urunler")[0].selectedIndex = 0;
    dukkanX = Number($("#koordinat option").eq(0).val().toString().replace(",", "."));
    dukkanY = Number($("#koordinat option").eq(1).val().toString().replace(",", "."));
    var Coords = new google.maps.LatLng(dukkanY, dukkanX);
    infowindow1 = new google.maps.InfoWindow({
        content: '<a href="https://www.google.com.tr/maps/dir/' + kullaniciY + ',' + kullaniciX + '/' + dukkanY + ',' + dukkanX + '" id="infoBox">Rota Başlat</a>'
    })

    dukkanMarker = new google.maps.Marker(
        {
            size: new google.maps.Size(30, 30),
            position: Coords,
            map: map
        });
    google.maps.event.addListener(dukkanMarker, 'click', function () {
        infowindow1.open(map, dukkanMarker);
    })
    map.setZoom(13);
});
function changeDS() {
    dukkanX = Number($("#koordinat option").eq(($("#urunler")[0].selectedIndex) * 2).val().toString().replace(",", "."));
    dukkanY = Number($("#koordinat option").eq(($("#urunler")[0].selectedIndex * 2) + 1).val().toString().replace(",", "."));
    var Coords = new google.maps.LatLng(dukkanY, dukkanX);
    var kullaniciX = Number($("#xKoordinat").val().replace(",", "."));
    var kullaniciY = Number($("#yKoordinat").val().replace(",", "."));
    infowindow1.setContent('<a href="https://www.google.com.tr/maps/dir/' + kullaniciY + ',' + kullaniciX + '/' + dukkanY + ',' + dukkanX + '" id="infoBox">Rota Başlat</a>');

    dukkanMarker.setPosition(Coords);

}