<?php
header('Content-type: application/json'); // Type of data returns

require_once '../put.php';

$Put = new PUT();
if (isset($_POST)) {
  $Put->setTable($_POST['table']);
  // $Post->addUpdate('usr_id',$_POST['usr_id']);
  $Put->addUpdate('usr_nick',$_POST['usr_nick']);
  // $Put->addUpdate('usr_email',$_POST['usr_email']);
  // $Put->addUpdate('usr_password',$_POST['usr_password']);
  // $Post->addUpdate('usr_icon',$_POST['usr_icon']);
  // $Put->addUpdate('usr_status',$_POST['usr_status']);
  $Put->addWhere("usr_id =".$_POST['usr_id']);
  $Put->executeQuery();
  print $Put->getJSON();
}
?>
