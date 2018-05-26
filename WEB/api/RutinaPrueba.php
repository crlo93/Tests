<?php

header('Content-type: application/json'); // Type of data returns

require_once '../ws/put.php';
require_once '../ws/post.php';
require_once '../ws/get.php';
require_once '../ws/delete.php';


//Tabla battle

$Post = new POST();
$Post->setTable('battle');
$Post->addInsert('bttl_user1', '200');
$Post->addInsert('bttl_user2', '210');
$Post->addInsert('bttl_type', '2');
$Post->addInsert('bttl_winner', '200');
$Post->addInsert('bttl_date', '2018-4-9');
$Post->addInsert('bttl_duration', '073046');
$Post->executeQuery();
print $Post->getJSON();
print $Post->getSQL();

/*Tabla user
$Get = new Get();
 $Get->setTable('user');
 $Get->setOrderBy('usr_nick');
 $Get->executeQuery();
print $Get->getJSON();
print $Get->getSQL();


//Tabla User
$Post = new POST();
$Post->setTable('user');
$Post->addInsert('usr_nick', 'PruebaR');
$Post->addInsert('usr_email', 'Prueba@gmail.com');
$Post->addInsert('usr_password', '1234prueba');
$Post->executeQuery();
print $Post->getJSON();
print $Post->getSQL();

//Tabla User
$Put = new PUT();
$Put->setTable('user');
// $Post->addUpdate('usr_id',$_POST['usr_id']);
$Put->addUpdate('usr_email','Prueba34@gmail.com');
// $Put->addUpdate('usr_email',$_POST['usr_email']);
// $Put->addUpdate('usr_password',$_POST['usr_password']);
// $Post->addUpdate('usr_icon',$_POST['usr_icon']);
// $Put->addUpdate('usr_status',$_POST['usr_status']);
$Put->setWheres("usr_id =".'299');
$Put->executeQuery();
print $Put->getJSON();
print $Put->getSQL();


//Tabla User
$Delete = new DELETE();
  $Delete->setTable('user');
  $Delete->setWheres("usr_id = ".'271');
  $Delete->executeQuery();
  print $Delete->getJSON();
  print $Delete->getSQL();
*/
//$Post->_destruct();
?>