<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

/* DELETE */
class Delete {

  /* CONNECTION */
  private $conn;

  /* QUERY */
  private $table = "";
  private $wheres = "";
  private $limit = 0;

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

  public function setWheres($value = '') {
    $this->wheres = $value;
  }

  public function clearWheres() {
    $this->wheres = "";
  }

  public function setLimit($value = 0) {
    $this->limit = $value;
  }

  public function executeQuery() {
    $json = [];
    $wheres =  (!empty($this->wheres)) ? $this->wheres : "";
    $limit =  ($this->limit>0) ? " LIMIT ".$this->limit : "";
    $this->sql = "DELETE FROM ".$this->table." WHERE ".$wheres.$limit.";"; // Set query
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
