<?php

// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

require_once '../../ws/get.php';

$Get = new Get();

$Get->setTable('map');

$Get->setWheres('activo = 1');

$Get->executeQuery();

print $Get->getJSON(); ?>
