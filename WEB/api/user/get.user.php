<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

if (isset($_GET['id'])) {
  require_once '../../ws/get.php';

  $Get = new Get();

  $Get->setTable('user');

  $Get->setWheres('usr_id = '.$_GET['id']);

  $Get->executeQuery();

  print $Get->getJSON();
}
?>
