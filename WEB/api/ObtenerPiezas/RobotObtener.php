<?php

header('Content-type: application/json'); // Type of data returns


require_once '../../ws/get.php';


//Extraer Datos de LEGS
$Get = new Get();
$Get->setTable('robot');
$Get->setWheres('id_usuario=1');
$Get->addColumn('name');
$Get->addColumn('id_head');
$Get->executeQuery();
print $Get->getJSON();

?>