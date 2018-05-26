<?php
header('Content-type: application/json'); // Type of data returns

require_once '../get.php';

$Get = new Get();
if (isset($_POST)) {
  $Get->setTable($_POST['table']);
  $Get->setRows(0);
  $Get->executeQuery();
  print $Get->getJSON();
}
?>
