<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

header('Content-type: application/json'); // Type of data returns

require_once '../../ws/post.php';

$Post = new POST();
if (isset($_POST)) {
  $Post->setTable("partUser");
  // $Post->addInsert('usr_id',$_POST['usr_id']);
  $Post->addInsert('idPartUser',$_POST['idPartUser']);
  $Post->addInsert('id_partMap',$_POST['id_partMap']);
  $Post->addInsert('id_user',$_POST['id_user']);
  $Post->addInsert('id_skinUser',$_POST['id_skinUser']);
  $Post->addInsert('lvl',$_POST['lvl']);
  $Post->addInsert('stck',$_POST['stck']);
  // $Post->addInsert('usr_icon',$_POST['usr_icon']);
  //$Post->addInsert('usr_status',$_POST['usr_status']);
  $Post->executeQuery();
  print $Post->getJSON();
}
?>
