<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
?>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title></title>
  <script src='https://api.tiles.mapbox.com/mapbox-gl-js/v0.44.1/mapbox-gl.js'></script>
  <link href='https://api.tiles.mapbox.com/mapbox-gl-js/v0.44.1/mapbox-gl.css' rel='stylesheet' />
</head>
<body>
  <div id='map' style='width: 1600px; height: 1200px;'></div>
  <script>
  mapboxgl.accessToken = 'pk.eyJ1Ijoic2lja2Fjb3BsZSIsImEiOiJjamRycTh0cHkwYm01MnhsbGxhd24yMTdqIn0.ppN6zYpWXWVLFX8DSy5P7g';
  var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/mapbox/streets-v9',
    center: [20.666,-103.391],
    zoom: 14,
  });
  
  <?php
  $json = file_get_contents('http://robo-fightworld.bigbang.uno/api/Random.php');
  $obj = json_decode($json,true);
  foreach ($obj as $value) {
    print "new mapboxgl.Marker()
      .setLngLat([".$value['LATLON']."])
      .addTo(map);\n";
  }
  ?>
  </script>
</body>
</html>
