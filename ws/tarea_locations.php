<?php

$aLatLon = array();

for($i = 0; $i<1000; $i++) {
  // $aLatLon[$i]['LAT'] = getRandomInRange(-90, 90, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true)."F";
  // $aLatLon[$i]['LON'] = getRandomInRange(-180, 180, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true)."F";
  // $aLatLon[$i]['LAT'] = "20.".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  // $aLatLon[$i]['LON'] = "-103.".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  $aLatLon[$i]['LAT'] = getRandomInRange(-89, 89, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  $aLatLon[$i]['LON'] = getRandomInRange(-89, 89, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  $aLatLon[$i]['LATLON'] =  $aLatLon[$i]['LAT'].",".$aLatLon[$i]['LON'];
}

function getRandomInRange($from, $to, $isPositive) {
  $rNum = 0;
  if ($isPositive) {
    $rNum = rand($from,$to);
    if ($rNum<0) {
      $rNum *= -1;
    }
  } else {
    $rNum = rand($from,$to);
  }
  return $rNum;
}

print json_encode($aLatLon,256);

?>
