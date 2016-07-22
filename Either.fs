module Either 

type EitherT<'right, 'left> =
  | Right of 'right
  | Left of 'left

let map mapper either =
  match either with
  | Right r -> Right(mapper r)
  | Left l -> Left l

let bind binding either =
  match either with
  | Right r -> binding r
  | Left l -> Left l
