<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

if (isset($_POST['id'])) {
  require_once '../../ws/get.php';

  $Get = new Get();

  $Get->setTable('user');

  $Get->addColumn('usr_nick');

  $Get->setWheres('usr_id = '.$_POST['id']);

  $Get->executeQuery();

  print $Get->getJSON();
}
?>
