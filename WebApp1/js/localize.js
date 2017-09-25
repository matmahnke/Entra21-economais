//calculo de distancia

var latitude;
var longitude;
var mercadoLat;
var mercadoLong;

function getLatLong(callback) {

    navigator.geolocation.watchPosition(function (position) {
        latitude = position.coords.latitude;
        longitude = position.coords.longitude;
        localStorage.setItem("userLocation", latitude + "," + longitude);
        /*$.ajax({
            type: "POST",
            url: "/Lista/SaveLocations",
            data: '{latitude: "' + latitude + '",longitude: "' + longitude+ '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
            },
        });*/
        callback();
    });
}

function bringDistance() {
    var p1 = new google.maps.LatLng(latitude, longitude);
    var p2 = new google.maps.LatLng(mercadoLat, mercadoLong);
    alert(calcDistance(p1, p2));
    function calcDistance(p1, p2) {
        return (google.maps.geometry.spherical.computeDistanceBetween(p1, p2) / 1000).toFixed(2);
    }
};