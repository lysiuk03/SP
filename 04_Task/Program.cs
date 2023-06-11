
using System.Threading.Tasks;


//Task1

using System.Threading.Tasks;

Task task1 = new Task(DataTimes);
task1.Start();

Task task2 = Task.Factory.StartNew(DataTimes);

Task task3 = Task.Run(DataTimes);
Console.ReadLine();

//Task 2-1
Task task2_1 = Task.Run(() =>
{
    for (int number = 1; number <= 1000; number++)
    {
        if (IsPrime(number))
        {
            Console.Write(number + " ");
        }
    }
    Console.WriteLine("\n");
});

task2_1.Wait();

//Task 2-2
Task<int> task2_2 = Task.Run(() => PrimeNumber(10, 100));
Console.WriteLine(task2_2.Result);
task2_2.Wait();
Console.WriteLine();

//task 4
int[] array = { 4, 4, 12, 2, 4, 9, 32, 7, 6 };
Task<int>[] tasks = new Task<int>[4]
            {
                new Task<int>(() => array.Min()),
                new Task<int>(() => array.Max()),
                new Task<int>(() => (int)array.Average()),
                new Task<int>(() => array.Sum())
            };
foreach (var t in tasks)
    t.Start();
Task.WaitAll(tasks);
Console.WriteLine($"Min: "+tasks[0].Result);
Console.WriteLine($"Max: "+ tasks[1].Result);
Console.WriteLine($"Average: "+ tasks[2].Result);
Console.WriteLine($"Sum: "+ tasks[3].Result);

//Task 5
Task<int[]> t1 = Task.Run(() => array.Distinct().ToArray());

Task<int[]> t2 = t1.ContinueWith(t1 => t1.Result.OrderBy(x => x).ToArray());
Task<int> t3 = t2.ContinueWith(t => Search(t.Result, 4));

Console.WriteLine("t1");
foreach (int num in t1.Result)
{
    Console.Write(num + " ");
}
Console.WriteLine();
Console.WriteLine("t2");
foreach (int num in t2.Result)
{
    Console.Write(num + " ");
}
Console.WriteLine();

Console.WriteLine("Search: " + t3.Result);

void DataTimes()
{
    DateTime datetime = DateTime.Now;
    Console.WriteLine(datetime.ToString("dd/MM/yyyy HH:mm:ss"));
}
bool IsPrime(int number)
{
    if (number < 2)
    {
        return false;
    }

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }

    return true;
}
int PrimeNumber(int x, int y)
{
    int count = 0;

    for (int number = x; number <= y; number++)
    {
        if (IsPrime(number))
        {
            count++;
        }
    }
    return count;
}
int Search(int[] t2,int n)
{
    int index = Array.BinarySearch(t2, n);
    return index >= 0 ? t2[index] : -1;
}