<?php
// ini_set('display_errors', 1);
// ini_set('display_startup_errors', 1);
// error_reporting(E_ALL);

/* SELECT */
class Get {

  /* CONNECTION */
  private $conn;

  /* QUERY */
  private $columns = "";
  private $table = "";
  private $wheres = "";
  private $orderBy = "";
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

  public function addColumn($valueC = "") {
    if (isset($valueC)) {
      $this->columns .= $valueC.", ";
    }
  }

  public function clearColumns() {
    $this->columns = "";
  }

  public function setTable($valueT = '') {
    $this->table = $valueT;
  }

  public function setWheres($valueW = '') {
    $this->wheres = $valueW;
  }

  public function clearWheres() {
    $this->wheres = "";
  }

  public function setOrderBy($valueO = '') {
    $this->orderBy = $valueO;
  }

  public function clearOrderBy() {
    $this->orderBy = "";
  }

  public function setLimit($valueL = 0) {
    $this->limit = $valueL;
  }

  public function executeQuery() {
    $json = [];
    $columns = (!empty($this->columns)) ? substr($this->columns, 0, -2) : "*";
    $wheres =  (!empty($this->wheres)) ? " WHERE ".$this->wheres : "";
    $orderBy =  (!empty($this->orderBy)) ? " ORDER BY ".$this->orderBy : "";
    $limit =  ($this->limit>0) ? " LIMIT ".$this->limit : "";
    $this->sql = "SELECT ".$columns." FROM ".$this->table.$wheres.$orderBy.$limit.";"; // Set query
    $stmt = $this->conn->query($this->sql);
    if ( $stmt ) {
      if ($stmt->num_rows > 0) { // Query success
        $json = array('STATUS' => 0, 'DETAIL' => "Consulta exitosa");
        while( $row = $stmt->fetch_assoc()  ) { // Get all rows from query
          $json['DATA'][] = array_map("utf8_encode",$row);
        }
        $json['LENGTH'] = $stmt->num_rows;
      } else { // No data
        $json = array('STATUS' => 404, 'DETAIL' => "Consulta exitosa, sin información"); // Add STATUS to JSON
      }
    } else { // Error consulta
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
