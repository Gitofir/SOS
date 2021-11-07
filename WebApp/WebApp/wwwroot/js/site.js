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

// Canvas
//const canvas = document.getElementById("canvas");
//canvas.addEventListener("load", () => {
   // const canvas = document.getElementById("canvas");

    const canvas = document.querySelector("#canvas");
    const ctx = canvas.getContext("2d");

canvas.height = top.innerHeight;
canvas.width = top.innerWidth;

    let painting = false;

    function startPosition() {
        painting = true;
        draw(e);
    }

    function finishedPosition() {
        painting = false;
        ctx.beginPath();
    }

    function draw(e) {
        if (!painting) return;

        ctx.lineWidth = 2;
        ctx.lineCap = "round";
        ctx.lineTo(e.clientX, e.clientY);
        ctx.stroke();
        ctx.beginPath();
        ctx.moveTo(e.clientX, e.clientY);
    }

    //EventListener
    canvas.addEventListener("mousedown", startPosition);
    canvas.addEventListener("mouseup", finishedPosition);
    canvas.addEventListener("mousemove", draw);
//});

//resizing
window.addEventListener("resize",()=>{
    canvas.height = top.innerHeight;
    canvas.width=top.innerWidth;
});

||||||| 55ccd38
=======
﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
>>>>>>> 3a7376ebed44f88d2c5e2b2065e3db626afe674a
