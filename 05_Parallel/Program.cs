using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

//Task 1-2
Parallel.Invoke(() => Factorial(8));
//Task 3
Parallel.For(3, 8, MultiplicationTable);
//Task 4
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
File.WriteAllText("list", JsonSerializer.Serialize(numbers));
List<int> nb = JsonSerializer.Deserialize<List<int>>(File.ReadAllText("list"));
Parallel.ForEach(nb, OnlyFactorial);
//Task 5
Console.WriteLine();
Console.WriteLine("Sum: "+ nb.AsParallel().Sum());
Console.WriteLine("Max: " + nb.AsParallel().Max());
Console.WriteLine("Min: " + nb.AsParallel().Min());




void Factorial(int x)
{
    int result = 1;

    for (int i = 1; i <= x; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Result {result}");
    Parallel.Invoke(
        () => CalculateDigitCount(result),
        () => CalculateDigitSum(result)
    );
}
void CalculateDigitCount(int n)
{
    Console.WriteLine($"Digit count: {n.ToString().Length}");
}

void CalculateDigitSum(int number)
{
    int sum = 0;
    foreach (char digit in number.ToString())
    {
        sum += int.Parse(digit.ToString());
    }
    Console.WriteLine($"Digit sum: {sum}");
}
void MultiplicationTable(int x)
{
    Console.WriteLine($" {x}*1={x*1}");
    Console.WriteLine($" {x}*2={x * 2}");
    Console.WriteLine($" {x}*3={x * 3}");
    Console.WriteLine($" {x}*4={x * 4}");
    Console.WriteLine($" {x}*5={x * 5}");
    Console.WriteLine($" {x}*6={x * 6}");
    Console.WriteLine($" {x}*7={x * 7}");
    Console.WriteLine($" {x}*8={x * 8}");
    Console.WriteLine($" {x}*9={x * 9}");
    Console.WriteLine($" {x}*10={x * 10}");
    Console.WriteLine();
}
void OnlyFactorial(int x)
{
    int result = 1;

    for (int i = 1; i <= x; i++)
    {
        result *= i;
    }
    Console.WriteLine($"Result {result}");
}