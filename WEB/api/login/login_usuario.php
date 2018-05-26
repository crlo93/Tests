<?php
header('Content-type: application/json'); // Type of data returns

require_once '../../ws/get.php';

$Get = new Get();
if (isset($_POST)) {
  $Get->setTable("user");
  $Get->addColumn("usr_nick");
  $Get->addColumn("usr_password");
  // $Get->addColumn($_POST['column']);
  // $Get->setWheres("usr_id > ".$_POST['usr_id']);
  $Get->setOrderBy($_POST['order']);
  // $Get->setLimit($_POST['limit']);
  $Get->executeQuery();
  //print $Get->getJSON();
  // print $Get->getSQL();
  $Json = json_decode($Get->getJSON(), true);

  $_POST = json_decode(file_get_contents('php://input'), true);

  $_POST['Password'] = md5($_POST['Password']);

  $login = false;
  foreach ($Json['DATA'] as $value) {
    if($_POST['Username']==$value['usr_nick'] && $_POST['Password']==$value['usr_password']){
      $login = true;
      break;
    }
  }

  unset($Json['DATA']);
  unset($Json['LENGTH']);

  if ($login==true) {
    $Json['STATUS'] = 0;
  } else {
    $Json['STATUS'] = 500;
  }

  $Json = json_encode($Json,256);
  print $Json;
}
?>
