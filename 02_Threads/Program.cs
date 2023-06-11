using System.Threading;

//Thread thread = new Thread(Task1);
//thread.Start();

Console.Write("Threads: ");
int threads = int.Parse(Console.ReadLine());


Console.Write("Start:");
int start = int.Parse(Console.ReadLine());

Console.Write("End:");
int end = int.Parse(Console.ReadLine());
Console.WriteLine();

Tuple<int,int> tuple = Tuple.Create(start, end);

//Thread thread = new Thread(Task1);
//thread.Start((object)tuple);

for (int i = 0; i < threads; i++)
{
    Thread thread = new Thread(Task1);
    thread.Start((object)tuple);
    thread.Join();
}

Console.WriteLine("End!");

/*static void Task1()
{
    for (int i = 0; i <= 50; i++)
    {
        Console.WriteLine(i);
    }
}*/

static void Task1(object t)
{
    Tuple<int, int> tuple = (Tuple<int, int>)t;
    for (int i = tuple.Item1; i <= tuple.Item2; i++)
    {
        Console.WriteLine(i);
    }
}