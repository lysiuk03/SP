using System;
using System.Threading;
using System.Windows;

namespace _02_Threads_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(thread.Text) || string.IsNullOrEmpty(starts.Text) || string.IsNullOrEmpty(ends.Text))
            {
                MessageBox.Show("Fill in all the data!");
                return;
            }
            int threads = int.Parse(thread.Text);
            int start = int.Parse(starts.Text);
            int end = int.Parse(ends.Text);
            Tuple<int, int> tuple = Tuple.Create(start, end);

            for (int i = 0; i < threads; i++)
            {
                Thread thread = new Thread(Task1);
                thread.Start((object)tuple);
            }
        }
        void Task1(object t)
        {
            Tuple<int, int> tuple = (Tuple<int, int>)t;
            for (int i = tuple.Item1; i <= tuple.Item2; i++)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    listbox.Items.Add(i);
                });
                Thread.Sleep(100);
            }
        }
    }
}
