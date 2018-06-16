<?php

header('Content-type: application/json'); // Type of data returns


require_once '../ws/get.php';


$Get = new Get();
$Get->setTable('robot');
$Get->setWheres("id_usuario=".$_POST["id"]);
$Get->addColumn('name');
$Get->executeQuery();
print $Get->getJSON();

?>