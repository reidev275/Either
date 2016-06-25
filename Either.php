<?php
class Either {
  private $val = null;
  private $isRight = TRUE;

  private function __construct( $val, $isRight ) {
    $this->val = $val;
    $this->isRight = $isRight;
  }

  public static function Right( $right ) {
    $instance = new self( $right, TRUE );
    return $instance;
  }

  public static function Left( $left ) {
    $instance = new self( $left, FALSE );
    return $instance;
  }

  public function map(callable $mapping) {
    if ( $this->isRight ) {
      $result = call_user_func( $mapping, $this->val );
      return Either::Right( $result );
    }
    return Either::Left( $val );
  }

  public function bind(callable $binding) {
    if ( $this->isRight ) {
      return call_user_func($binding, $this->val);
    } else {
      return Either::Left( $val );
    }
  }
}

$rightTwo = Either::Right(2);
//Right 2

function addTwo($number) {
  return $number+2;
}

$rightFour = $rightTwo->map("addTwo");
//Right 4

?>
