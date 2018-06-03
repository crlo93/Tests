<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

if (isset($_POST)) {

  require_once '../../ws/get.php';

  $Get = new Get();

  $Get->setTable("user");

  $Get->addColumn("usr_id");
  $Get->addColumn("usr_nick");
  $Get->addColumn("usr_password");

  $Get->executeQuery();

  $Json = json_decode($Get->getJSON(), true);

  $idUsuario = 0;
  foreach ($Json['DATA'] as $value) {
    if($_POST['userName']==$value['usr_nick'] && $_POST['password']==$value['usr_password']){
      $idUsuario = $value['usr_id'];
      break;
    }
  }

  print $idUsuario;
}
?>
