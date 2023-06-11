


int[] numbers = new int[1000];
Random random = new Random();
for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = random.Next(1, 1000);
}

Thread thread1 = new Thread(Min);
thread1.Start((object)numbers);
Thread thread2 = new Thread(Max);
thread2.Start((object)numbers);
Thread thread3 = new Thread(Average);
thread3.Start((object)numbers);
Thread thread = new Thread(Show);
thread.Start((object)numbers);
static void Min(object numbers)
{
    int[] num = (int[])numbers;
    int min = num[0];
    for (int i = 0; i < num.Length; i++)
    {
        if (num[i] < min)
        {
          min = num[i];
        }
    }
    Console.WriteLine("Minimum: "+min);
}

static void Max(object numbers)
{
    int[] num = (int[])numbers;
    int max = num[0];
    for (int i = 0; i < num.Length; i++)
    {
        if (num[i] > max)
        {
            max = num[i];
        }
    }
    Console.WriteLine("Maximum: " + max);
}
static void Average(object numbers)
{
    int[] num = (int[])numbers;
    int sum = 0;
    for (int i = 0; i < num.Length; i++)
    {
        sum += num[i];
    }
    double average = sum/num.Length;
    Console.WriteLine("Average: " + average);
}
static void Show(object numbers)
{
    int[] num = (int[])numbers;
    for (int i = 0; i < num.Length; i++)
    {
        Console.WriteLine(num[i]);
    }
}