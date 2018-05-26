<?php
header('Content-type: application/json'); // Type of data returns

require_once '../delete.php';

$Delete = new DELETE();
if (isset($_POST)) {
  $Delete->setTable($_POST['table']);
  $Delete->addWhere("usr_id =".$_POST['usr_id']);
  $Delete->executeQuery();
  print $Delete->getJSON();
}
?>
