class ArithmeticExceptionExample
{
public static void main(String[] args)
{
int numerator=10;
int denominator=0;
try
{
int result=10/0;
System.out.println(result);
}
catch(ArithmeticException e)
{
System.out.println("cannot divide the number");
}
}
}