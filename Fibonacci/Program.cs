Console.WriteLine("Input two integers");

Console.WriteLine("Integer A");
int A =Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Integer B");
int B =Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Choose iteration count");
int iteration = Convert.ToInt32(Console.ReadLine());
int count = 2; 
int Fibonacci( int a, int b)
{
    if(count < iteration)
    {

        count += 1;

        int fib = a + b;

        Console.WriteLine($"Fibonacci number: {a} & {b}");
        Console.WriteLine(fib);

        a = b;
        b = fib;
        Fibonacci(a, b);
       

    }
    else
    {
        Console.WriteLine(0);
    }
    return a + b;
}
Fibonacci(A, B);

