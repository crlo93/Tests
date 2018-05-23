<?php
/* INSERT */
class Post {

  private $table = "";
  private $conn;
  private $keys = ""; // Columns for insert into database
  private $values = ""; // Values of columns
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

  public function clearInserts() {
    $this->keys = "";
    $this->values = "";
  }

  public function addInsert($rKey,$rValue) { //r receive
    $fKey = ""; // f format
    $fValue = "";
    if ( !empty($rKey) && !empty($rValue) ) {
      $fKey = $rKey.", ";
      if (is_numeric($rValue)) {
        $fValue = $rValue.", ";
      } else if (strpos($rValue,"'")===false) {
        $fValue = "'".$rValue."', ";
      } else {
        $fValue = $rValue.", ";
      }
      $this->keys .= $fKey;
      $this->values .= $fValue;
    }
  }

  public function executeQuery() {
    $json = [];
    $keys = (!empty($this->keys)) ? substr($this->keys, 0, -2) : "" ; // Delete last concatenation
    $values = (!empty($this->values)) ? substr($this->values, 0, -2) : "" ; // Delete last concatenation
    $this->sql = "INSERT INTO ".$this->table." ( ".$keys." ) VALUES ( ".$values." );"; // Set query
    $stmt = $this->conn->query($this->sql);
    if ( $stmt ) {
      $json = array('STATUS' => 0); // Add STATUS to JSON
    } else {
      $json = array('STATUS' => 500); // Add STATUS to JSON
      //$json = array('QUERY' => $sql, 'KEYS' => $this->keys,'VALUES' => $this->values); // Add STATUS to JSON
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
