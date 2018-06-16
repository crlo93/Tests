<?php

header('Content-type: application/json'); // Type of data returns


require_once '../ws/get.php';

$Get = new Get();
$Get->setTable('robot');
$Get->setWheres("id_usuario=".$_POST["id"]);
$Get->addColumn('id_arml');
$Get->addColumn('id_armr');
$Get->addColumn('id_head');
$Get->addColumn('id_body');
$Get->addColumn('id_legs');

$Get->executeQuery();
print $Get->getJSON();

?>