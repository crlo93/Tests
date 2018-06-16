<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);
header('Content-type: application/json'); // Type of data returns

require_once '../ws/put.php';

$Put = new PUT();
if (isset($_POST)) {
  $Put->setTable($_POST['table']);
  // $Post->addUpdate('usr_id',$_POST['usr_id']);
  $Put->addUpdate('id_arml',$_POST['id_arml']);
  $Put->addUpdate('id_armr',$_POST['id_armr']);
  $Put->addUpdate('id_head',$_POST['id_head']);
  $Put->addUpdate('id_body',$_POST['id_body']);
  $Put->addUpdate('id_legs',$_POST['id_legs']);
  $Put->addUpdate('name',$_POST['name']);
  $Put->addUpdate('active',$_POST['active']);
  $Put->setWheres("id_usuario =".$_POST['id_usuario']);
  $Put->executeQuery();
  print $Put->getJSON();
 print $Put->getSQL();
}



/*
require_once '../ws/post.php';

$Post = new POST();
if (isset($_POST)) {
  $Post->setTable('robot');
  // $Post->addInsert('usr_id',$_POST['usr_id']);
  $Post->addInsert('id_usuario',$_POST['id_usuario']);
  $Post->addInsert('id_arml',$_POST['id_arml']);
  $Post->addInsert('id_armr',$_POST['id_armr']);
  $Post->addInsert('id_head',$_POST['id_head']);
  $Post->addInsert('id_body',$_POST['id_body']);
  $Post->addInsert('id_legs',$_POST['id_legs']);
  $Post->addInsert('active',$_POST['active']);
  $Post->addInsert('name',$_POST['name']);

  // $Post->addInsert('usr_icon',$_POST['usr_icon']);
  //$Post->addInsert('usr_status',$_POST['usr_status']);
  print $Post->executeQuery();
  print $Post->getJSON();
}
*/
?>
