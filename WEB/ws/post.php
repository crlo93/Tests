<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

/* INSERT */
class Post {

  /* CONNECTION */
  private $conn;

  /* QUERY */
  private $table = "";
  private $keys = ""; // Columns for insert into database
  private $values = ""; // Values of columns

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

  public function addInsert($rKey,$rValue) { //r receive  //r receive
    if ( !empty($rKey) && !empty($rValue) ) {
      $fValue = ""; // f format
      if (!is_numeric($rValue) && strpos($rValue,"'")===false) {
        $fValue = "'".$rValue."'";
      } else {
        $fValue = $rValue;
      }
      $this->keys .= $rKey.", ";
      $this->values .= $fValue.", ";
    }
  }

  public function clearInserts() {
    $this->keys = "";
    $this->values = "";
  }

  public function executeQuery() {
    $json = [];
    $keys = (!empty($this->keys)) ? substr($this->keys, 0, -2) : "" ; // Delete last concatenation
    $values = (!empty($this->values)) ? substr($this->values, 0, -2) : "" ; // Delete last concatenation
    $this->sql = "INSERT INTO ".$this->table." ( ".$keys." ) VALUES ( ".$values." );"; // Set query
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
