<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

header('Content-type: application/json'); // Type of data returns

require_once '../../ws/post.php';
require_once '../../ws/get.php';

if (isset($_POST)) {
  $Post = new Post();
  $Post->setTable("user");
  // $Post->addInsert('usr_id',$_POST['usr_id']);
  $Post->addInsert('usr_nick',$_POST['usr_nick']);
  $Post->addInsert('usr_email',$_POST['usr_email']);
  $Post->addInsert('usr_password',$_POST['usr_password']);
  // $Post->addInsert('usr_icon',$_POST['usr_icon']);
  //$Post->addInsert('usr_status',$_POST['usr_status']);
  $Post->executeQuery();
  print $Post->getJSON()."\n\n\n";

  $Get = new Get();
  $Get->setTable("user");
  $Get->addColumn("max(usr_id) as id");
  $Get->executeQuery();
  $jsonGet = json_decode($Get->getJSON(),true);
  print $Get->getJSON()."\n\n\n";
  $id = $jsonGet['DATA'][0]['id'];

  $Post = new Post();
  $Post->setTable("robot");
  $Post->addInsert('id_usuario',$id);
  $Post->addInsert('name','robot 1');
  $Post->addInsert('active','true');
  $Post->executeQuery();
  print $Post->getJSON()."\n\n\n";
}
?>
