<?php

header('Content-type: application/json');

require_once '../ws/put.php';
require_once '../ws/post.php';

$aLatLon = array();


/*$Put = new PUT();
  $Put->setTable('map');
  $Put->addUpdate('activo', FALSE);
  $Put->setWheres(1=1);
  $Put->executeQuery();
*/

$Post = new POST();
$Post->setTable('map');

for($i = 0; $i<2; $i++) {
  // $aLatLon[$i]['LAT'] = getRandomInRange(-90, 90, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true)."F";
  // $aLatLon[$i]['LON'] = getRandomInRange(-180, 180, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true)."F";
  // $aLatLon[$i]['LAT'] = "20.".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  // $aLatLon[$i]['LON'] = "-103.".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  //print $aLatLon[$i]['LAT'] = getRandomInRange(-89, 89, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  //print $aLatLon[$i]['LON'] = getRandomInRange(-89, 89, false).".".getRandomInRange(-999, 999, true).getRandomInRange(-999, 999, true);
  //LatLon[$i]['LATLON'] =  $aLatLon[$i]['LAT'].",".$aLatLon[$i]['LON'];


  $Post->addInsert('latitud', $aLatLon[$i]['LAT'] = "20.".getRandomInRange(-40, 40, true).getRandomInRange(-40, 40, true).getRandomInRange(-999, 999, true));
  $Post->addInsert('longitud', $aLatLon[$i]['LON'] = "-103.".getRandomInRange(-40, 40, true).getRandomInRange(-40, 40, true).getRandomInRange(-999, 999, true));
 // $Post->addInsert('LatLon', $aLatLon[$i]['LATLON'] =  $aLatLon[$i]['LAT'].",".$aLatLon[$i]['LON']);
  $Post->addInsert('activo',TRUE);
  $Post->addInsert('prt_element', randomElemento());
  $Post->addInsert('prt_lvl', randomNivel());
  $Post->addInsert('prt_def', randomDefensa());
  $Post->addInsert('prt_dmg',randomAtaque());
  $Post->addInsert('prt_cooldown', randomCoolD());
  $Post->addInsert('prt_speed', randomSpeed());
  $Post->addInsert('prt_type', randomTipo());
  $Post->executeQuery();
  $Post->clearInserts();

  //print $Post->getJSON();
 // print $Post->getSQL();

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


function randomElemento(){
  return rand(1, 5);

}


function randomNivel(){

  return rand(1,50);
}

function randomDefensa(){
  return rand(0, 20);
}

function randomAtaque()
{
  return rand(0,30);
}

function randomCoolD(){

  return rand (0, 30);

}

function randomSpeed(){

  return rand(0,20);
}

function randomTipo(){

  return rand(0,30);
}



?>

