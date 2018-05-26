<?php
header('Content-type: application/json'); // Type of data returns

require_once '../../ws/get.php';

$Get = new Get();
if (isset($_POST)) {
  $Get->setTable($_POST['table']);
  // $Get->addColumn($_POST['column']);
  // $Get->setWheres("usr_id > ".$_POST['usr_id']);
  $Get->setOrderBy($_POST['order']);
  // $Get->setLimit($_POST['limit']);
  $Get->executeQuery();
  print $Get->getJSON();
  // print $Get->getSQL();
}
?>
