<?php
/* DELETE */
class Delete {

  //private
  private $table = "";
  private $conn;
  private $wheres = array();
  private $sql = "";
  private $json = "";

  function __construct() {
    $servername = "mysql.hostinger.mx";
    $username = "u991170820_rfw";
    $password = "aRHyHEm5nn";
    $dbname = "u991170820_rfw";
    $this->conn = new mysqli($servername, $username, $password, $dbname);
  }

  public function getSQL() {
    return $this->sql;
  }

  public function setTable($value='') {
    $this->table = $value;
  }

  public function clearWheres() {
    $this->wheres = array();
  }

  public function addWhere($value = "") {
    if (isset($value)) {
      array_push($this->wheres,$value);
    }
  }

  private function getWheres() {
    $str_where = "";
    foreach ($this->wheres as $value) {
      $str_where .= $value." AND ";
    }
    $str_where = (empty($str_where)) ? "" : substr($str_where, 0, -5);
    return $str_where;
  }

  public function executeQuery() {
    $json = [];
    $wheres = $this->getWheres();
    $this->sql = "DELETE FROM ".$this->table." WHERE ".$wheres.";"; // Set query
    $stmt = $this->conn->query($this->sql);
    if ( $stmt ) {
      $json = array('STATUS' => 0); // Add STATUS to JSON
    } else {
      $json = array('STATUS' => 500); // Add STATUS to JSON
      //$json = array('QUERY' => $sql, 'UPDATES' => $updates); // Add STATUS to JSON
    }
    $this->json = json_encode($json,256); // Print JSON
  }

  public function getJSON() {
    return $this->json;
  }

  function __destruct() {
    $this->conn->close();
  }

}
?>
