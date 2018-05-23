<?php
/* SELECT */
class Get {

  private $table = "";
  private $rows = 1000;
  private $orderBy = "";
  private $conn;
  private $wheres = array();
  private $columns = "";
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

  public function setRows($value=1000) {
    $this->rows = $value;
  }

  public function setOrderBy($value='') {
    $this->orderBy = $value;
  }

  public function clearOrderBy($value='') {
    $this->orderBy = "";
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

  public function clearColumns() {
    $this->columns = "";
  }

  public function addColumn($value = "") {
    if (isset($value)) {
      $this->columns .= $value.", ";
    }
  }

  public function executeQuery() {
    $json = [];
    $orderBy = ($this->orderBy!="") ? " ORDER BY ".$this->orderBy : "";
    $columns = (!empty($this->columns)) ? substr($this->columns, 0, -2) : "*";
    $wheres = $this->getWheres();
    $wheres = (!empty($wheres)) ? " WHERE ".$wheres : "";
    $rows = ($this->rows!=0) ? "TOP ".$this->rows : "";
    $this->sql = "SELECT ".$rows." ".$columns." FROM ".$this->table.$wheres.$orderBy; // Set query
    $stmt = $this->conn->query($this->sql);
    if ( $stmt ) {
      if ($stmt->num_rows > 0) { // Query success
        $json = array('STATUS' => 0);
        while( $row = $stmt->fetch_assoc()  ) { // Get all rows from query
          $json['DATA'][] = array_map("utf8_encode",$row);
        }
        $json['LENGTH'] = $stmt->num_rows;
      } else { // No data
        $json = array('STATUS' => 404); // Add STATUS to JSON
      }
    } else { // Error consulta
      $json = array('STATUS' => 500); // Add STATUS to JSON
    }
    //$json['SQL'] = $this->sql;
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
