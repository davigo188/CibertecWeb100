(function (cibertec) {
    window.cibertec.getLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
    }

    function showPosition(position) {
        var location = { lat: position.coords.latitude, lng: position.coords.longitude };
        var map = new google.maps.Map(document.getElementById('googleMap'), {
            zoom: 15,
            center: location
        });

        var marker = new google.maps.Marker({
            position: location,
            map: map,
            title: 'Cibertec!'
        });
    }

})(window.cibertec = window.cibertec || {});