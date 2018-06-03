<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

var_dump($_POST);

require_once '../../ws/get.php';

$Get = new Get();

$Get->setTable("partUser");

$Get->addColumn("id_partMap");
$Get->addColumn("stck");

$Get->setWheres("id_user = ".$_POST['idUser']);

$Get->executeQuery();

print $Get->getSQL();

$JsonGetUser = json_decode($Get->getJSON(),true);

$isNew = true;

if ($JsonGetUser['STATUS']=='0') {
  $stck = 0;
  foreach ($JsonGetUser['DATA'] as $key => $value) {
    if ($value['id_partMap']==$_POST['idPartMap']) {
      $isNew = false;
      $stck = $value['stck'];
      break;
    }
  }
}


if ($isNew) {
  # Insert
  require_once '../../ws/post.php';

  $Post = new Post();

  $Post->setTable("partUser");

  $Post->addInsert("idPartUser",rand(1,100000000)); //Esto deberia ser auto increment
  $Post->addInsert("id_partMap",$_POST['idPartMap']);
  $Post->addInsert("id_user",$_POST['idUser']);
  $Post->addInsert("lvl",1);
  $Post->addInsert("stck",1);

  $Post->executeQuery();

  print $Post->getSQL();
} else {
  # Update
  $stck+=1;

  $n1 = 1;
  $n2 = 0;
  $fibonacci  = 0;
  for ($i=0; $i <= $stck; $i++) {
    $fibonacci  = $n1 + $n2;
    $n1 = $n2;
    $n2 = $fibonacci ;
  }
  # Check lvl
  require_once '../../ws/put.php';

  $Put = new Put();

  $Put->setTable("partUser");

  $Put->addUpdate("stck",$stck);
  $Put->addUpdate("lvl",$fibonacci);

  $Put->setWheres("id_partMap = ".$_POST['idPartMap']);

  $Put->executeQuery();

  print $Put->getSQL();
}

?>
