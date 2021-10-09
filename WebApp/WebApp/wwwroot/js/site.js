// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    // Initialize and add the map
      function initMap() {
        // The location of stock markets
          const telAviv = { lat: 32.064, lng: 34.77 };
          const newYork = { lat: 40.706, lng: -74.011 };
          const tokyo = { lat: 35.682, lng: 139.778 };

        //create map
        const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 2,
            center: telAviv, newYork, tokyo
        });

        //locate the pins
        const markerTelAviv = new google.maps.Marker({
            position: telAviv,
          map: map,
        });
        const markerNewYork = new google.maps.Marker({
              position: newYork,
              map: map,
        });
          const markerTokyo = new google.maps.Marker({
              position: tokyo,
              map: map,
          });
      }
