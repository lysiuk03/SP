using System;
using System.Threading;
using System.Windows;

namespace _02_Threads_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] numbers = new int[1000];
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 1000);
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            Thread thread1 = new Thread(Min);
            thread1.Start((object)numbers);
            Thread thread2 = new Thread(Max);
            thread2.Start((object)numbers);
            Thread thread3 = new Thread(Average);
            thread3.Start((object)numbers);
            Thread thread4 = new Thread(new ParameterizedThreadStart(Show));
            thread4.Start((object)numbers);
        }
        void Min(object numbers)
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
            Application.Current.Dispatcher.Invoke(() =>
            {
                minimum.Text = min.ToString();
            });
        }

        void Max(object numbers)
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
            Application.Current.Dispatcher.Invoke(() =>
            {
                maximum.Text = max.ToString();
            });
        }
        void Average(object numbers)
        {
            int[] num = (int[])numbers;
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
            }
            double average = sum / num.Length;
            Application.Current.Dispatcher.Invoke(() =>
            {
                avg.Text = average.ToString();
            });
        }
        void Show(object numbers)
        {
            int[] num = (int[])numbers;
            for (int i = 0; i < num.Length; i++)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    listbox.Items.Add(num[i]);
                });
                Thread.Sleep(100);
            }
        }
    }
}
