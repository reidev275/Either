class Either(object):
   def __init__(self, value, is_right):
     self.is_right = is_right
     self.value = value

   @staticmethod
   def right(value):
     return Either(value, True)

   @staticmethod
   def left(value):
     return Either(value, False)

   def map(self, mapping):
     if self.is_right:
       return Either.right(mapping(self.value))
     else:
       return Either.left(self.value)

   def bind(self, binding):
     if self.is_right:
       return binding(self.value)
     else:
       return Either(self.value, False)
       
   def __str__(self):
     if self.is_right:
       return "Right " + str(self.value)
     else:
       return "Left " + str(self.value)
       
right_two = Either.right(2)
print(right_two)

right_four = right_two.map(lambda x: x + 2)
print(right_four)

def divide (x,y):
  if y == 0:
    return Either.left("Cannot divide by 0")
  else:
    return Either.right(x / y)

right_one = right_four.bind(lambda x: divide(x, 4))
print(right_one)

div_by_zero = right_four.bind(lambda x: divide(x, 0))
print(div_by_zero)