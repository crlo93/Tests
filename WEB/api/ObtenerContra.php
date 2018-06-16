<?php

header('Content-type: application/json'); // Type of data returns

require_once '../ws/get.php';

$Get = new Get();
$Get->setTable('user');
$Get->setWheres("usr_id=".$_POST["id"]);
$Get->addColumn('usr_password'); //obtengo para comparar si es la misma 
$Get->executeQuery();
print $Get->getJSON()


?>