class Either<Right, Left>
{
  readonly Right right;
  readonly Left left;
  readonly bool isRight = true;

  public Either(Right val)
  {
    right = val;    
  }

  public Either(Left val)
  {
    left = val;
    isRight = false;
  }
      
  public Either<T, Left> Map<T>(Func<Right, T> mapping)
  {
    if (isRight)
    {
      var result = mapping(right);
      return new Either<T, Left>(result);
    }
    return new Either<T, Left>(left);
  }

  public Either<T, Left> Bind<T>(Func<Right, Either<T, Left>> binding)
  {
    return isRight ? binding(right) : new Either<T, Left>(left);
  }

  public override string ToString()
  {
    return isRight
      ? "Right(" + right.ToString() + ")"
      : "Left(" + left.ToString() + ")";
  }
}

var five = new Either<int, string>(2)
  .Map(x => x + 3)
  .ToString();
//Right(5)

Either<int, string> Divide(int numerator, int denomenator)
{
  return denomenator == 0
    ? new Either<int, string>("cannot divide by 0")
    : new Either<int, string>(num / den);
}

var divByZero = new Either<int, string>(10)
  .Bind(x => Divide(x, 0))
  .ToString();
//Left(cannot divide by 0)

var fiveAgain = new Either<int, string>(10)
  .Bind(x => Divide(x, 2))
  .ToString();
//Right(5)
