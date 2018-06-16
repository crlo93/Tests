<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

header('Content-type: application/json'); // Type of data returns

// require_once '../ws/put.php';
// require_once '../ws/post.php';
require_once '../ws/get.php';
// require_once '../ws/delete.php';

//Extraer Datos para Interfaz Perfil
$Get = new Get();
$Get->setTable('user');
$Get->setWheres("usr_id = ".$_POST["id"]);
$Get->addColumn('usr_nick');
$Get->addColumn('usr_email');
$Get->executeQuery();
print $Get->getJSON();

?>
