<?php

header('Content-type: application/json');

require_once '../ws/put.php';
require_once '../ws/post.php';

$aLatLon = array();

//Para que actualice de true a false en la columna de activo 
  $Put = new PUT();
  $Put->setTable('map');
  $Put->addUpdate('activo', "FALSE");
  $Put->setWheres("1=1");
  $Put->executeQuery();
  print $Put->getJSON();
  print $Put->getSQL();

$Post = new POST();
$Post->setTable('map');

for($i = 0; $i<100; $i++) {
  // $aLatLon[$i]['LAT'] = getRandomInRange(-90, 90, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true)."F";
  // $aLatLon[$i]['LON'] = getRandomInRange(-180, 180, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true)."F";
  // $aLatLon[$i]['LAT'] = "20.".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  // $aLatLon[$i]['LON'] = "-103.".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  //print $aLatLon[$i]['LAT'] = getRandomInRange(-89, 89, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  //print $aLatLon[$i]['LON'] = getRandomInRange(-89, 89, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  //LatLon[$i]['LATLON'] =  $aLatLon[$i]['LAT'].",".$aLatLon[$i]['LON'];


  $Post->addInsert('latitud', $aLatLon[$i]['LAT'] = "20.".getRandomInRange(60, 70, true).getRandomInRange(-70, 70, true).getRandomInRange(-999, 999, true));
  $Post->addInsert('longitud', $aLatLon[$i]['LON'] = "-103.".getRandomInRange(26, 40, true).getRandomInRange(-70, 70, true).getRandomInRange(-999, 999, true));
 // $Post->addInsert('LatLon', $aLatLon[$i]['LATLON'] =  $aLatLon[$i]['LAT'].",".$aLatLon[$i]['LON']);
  $Post->addInsert('id_parMap', PiezaMap());
  $Post->addInsert('activo',TRUE);
  

  $Post->executeQuery();
  $Post->clearInserts();

  print $Post->getJSON();
  print $Post->getSQL();

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


function PiezaMap(){
  return rand(1, 10);

}

?>

