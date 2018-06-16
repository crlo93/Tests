<?php

header('Content-type: application/json'); // Type of data returns


require_once '../../ws/get.php';


//Extraer Datos de BODY
$Get = new Get();
$Get->setTable('partUser INNER JOIN partMap ON partUser.id_partMap= partMap.prt_id' );
$Get->setWheres("id_user=".$_POST["id"]);
$Get->setWheres('prt_type=2');
$Get->addColumn('id_partMap');
$Get->addColumn('prt_name');
$Get->addColumn('img');

$Get->executeQuery();
print $Get->getJSON();

?>