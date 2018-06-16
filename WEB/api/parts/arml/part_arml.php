<?php
header('Content-type: application/json'); // Type of data returns

require_once '../../../ws/get.php';

$Get = new Get();

$Get->setTable('user');

$Get->setWheres('usr_id = 1');
$Get->AddColumn('usr_nick');
$Get->AddColumn('usr_email');

$Get->executeQuery();

print $Get->getJSON();

?>
