<?php

header('Content-type: application/json'); // Type of data returns

require_once '../ws/put.php';
require_once '../ws/post.php';
require_once '../ws/get.php';
require_once '../ws/delete.php';


//Extraer Datos para Interfaz Perfil
$Get = new Get();
$Get->setTable('user');
$Get->setWheres('usr_id=1');
$Get->addColumn('usr_nick');
$Get->addColumn('usr_email');
$Get->executeQuery();
print $Get->getJSON();
//print $Get->getSQL();

//Guardar nuevos datos
//Verificar Si ya existe nickname
//Verificaar contraseña si es igual
//Solo seleccionar los datos y sacar url
$Get = new Get();
$Get->setTable('partmap');
$Get->setWheres('prt_id=1');
$Get->executeQuery();
print $Get->getJSON();


//Guardar piezas del robot poner como POST 
$Post= new POST();
$Post->setTable('robot');
$Post->addInsert('id_arml', '1');
$Post->addInsert('id_armr','2');
$Post->addInsert('id_head', '3');
$Post->addInsert('id_body', '4');
$Post->addInsert('id_legs', '1');
$Post->addInsert('id_usuario','1');
$Post->addInsert('active', FALSE);
$Post->addInsert('name', 'Mirobot');
$Post->executeQuery();
print $Post->getJSON();


/*Cambiar nickname
$Put= new PUT();
$Put->setTable('user');
$Put->addUpdate('usr_nick', 'MaxiMax');
$Put->setWheres("usr_id =".'1');
$Put->executeQuery();
print $Put->getJSON();
print $Put->getSQL();

//cambiar contraseña, verificar si es la misma que ingreso 
$Get = new Get();
$Get->setTable('user');
$Get->addColumn('usr_password'); //obtengo para comparar si es la misma 
$Get->setWheres('usr_id=1');
$Get->executeQuery();
print $Get->getJSON()

//Poner nueva contraseña
$Put= new PUT();
$Put->setTable('user');
$Put->addUpdate('usr_password', '32456784');
$Put->setWheres("usr_id =".'1');
$Put->executeQuery();
print $Put->getJSON();
print $Put->getSQL();

//
*/
?>