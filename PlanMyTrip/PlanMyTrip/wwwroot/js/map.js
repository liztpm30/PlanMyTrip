let marker;

function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 13,
        center: { lat: 59.325, lng: 18.07 },
    });

    marker = new google.maps.Marker({
        map,
        draggable: true,
        animation: google.maps.Animation.DROP,
        position: { lat: 59.327, lng: 18.067 },
    });

    //Save the initial position
    savePosition();

    //Add event listeners
    marker.addListener("click", toggleBounce);
    marker.addListener("dragend", savePosition);
}

function toggleBounce() {
    if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

function savePosition() {

    var point = marker.getPosition();
    var lat = point.lat();
    var lng = point.lng();

    //Save this variables in html elements that will be then submitted by the form
    var htmlLat = document.getElementById("lat");
    var htmlLng = document.getElementById("lng");

    htmlLat.value = lat;
    htmlLng.value = lng;
}