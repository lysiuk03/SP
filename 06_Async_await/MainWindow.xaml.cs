using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _06_Async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //async- allow metod to use await keywords
            //await - wait task without freezing
            //Task<int> task = Task.Run(GenerateValue);
            //task.Wait();//freez
            //int value=GenerateValue();
            //list.Items.Add(task.Result);//freez
            //int value = await task;
            //int value = await Task.Run(GenerateValue);
            //list.Items.Add(value);
            //list.Items.Add(await Task.Run(GenerateValue));
            //int value = await GenerateValueAsync();
            //list.Items.Add(value);
            list.Items.Add(await GenerateValueAsync());
            //MessageBox.Show("Complete!");

        }
        Task<int> GenerateValueAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(random.Next(5000));
                //MessageBox.Show("Generate");
                return random.Next(1000);
            });

        }
        int GenerateValue()
        {

            Thread.Sleep(random.Next(5000));
            //MessageBox.Show("Generate");
            return random.Next(1000);

        }
    }
}
