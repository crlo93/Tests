<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

header('Content-type: application/json'); // Type of data returns

require_once '../../ws/delete.php';

$Delete = new DELETE();
if (isset($_POST)) {
  $Delete->setTable($_POST['table']);
  $Delete->setWheres("usr_id = ".$_POST['usr_id']);
  $Delete->setLimit($_POST['limit']);
  $Delete->executeQuery();
  print $Delete->getJSON();
  // print $Delete->getSQL();
}
?>
