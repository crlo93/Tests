<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

/* UPDATE */
class Put {

  /* CONNECTION */
  private $conn;

  /* QUERY */
  private $table = "";
  private $updates = "";
  private $wheres = "";

  /* RESULT */
  private $sql = "";
  private $json = "";

  function __construct() {
    $servername = "mysql.hostinger.mx";
    $username = "u991170820_rfw";
    $password = "aRHyHEm5nn";
    $dbname = "u991170820_rfw";
    $this->conn = new mysqli($servername, $username, $password, $dbname);
  }

  public function setTable($value = '') {
    $this->table = $value;
  }

  public function addUpdate($rKey,$rValue) { //r receive
    if ( !empty($rKey) && !empty($rValue) ) {
      $fValue = "";
      if ( !is_numeric($rValue) && strpos($rValue,"'")===false ) {
        $fValue = "'".$rValue."'";
      } else {
        $fValue = $rValue;
      }
      $this->updates .= $rKey." = ".$fValue.", ";
    }
  }

  public function clearUpdates() {
    $this->updates = "";
  }

  public function setWheres($value = '') {
    $this->wheres = $value;
  }

  public function clearWheres() {
    $this->wheres = "";
  }

  public function executeQuery() {
    $json = [];
    $updates = (!empty($this->updates)) ? substr($this->updates, 0, -2) : ""; // Delete last concatenation
    $wheres = (!empty($this->wheres)) ? $this->wheres : "";
    $this->sql = "UPDATE ".$this->table." SET ".$updates." WHERE ".$wheres.";"; // Set query
    $stmt = $this->conn->query($this->sql);
    if ( $stmt ) {
      $json = array('STATUS' => 0, 'DETAIL' => "Consulta exitosa"); // Add STATUS to JSON
    } else {
      $json = array('STATUS' => 500, 'DETAIL' => "Consulta errónea"); // Add STATUS to JSON
    }
    $this->json = json_encode($json,256); // Print JSON
  }

  public function getJSON() {
    return $this->json;
  }

  public function getSQL() {
    return $this->sql;
  }

  function __destruct() {
    $this->conn->close();
  }

}
?>
