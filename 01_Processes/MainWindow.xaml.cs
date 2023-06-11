using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace _01_Processes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(double.Parse(time_.Text));
            timer.Start();
        }

        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            var pr = grid.SelectedItem as Process;
            if (pr != null)
            {
                pr.Kill();
            }
           else
            {
                MessageBox.Show("Nothing is selected!");
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            var pr = grid.SelectedItem as Process;
            if (pr != null)
            {
                MessageBox.Show($"{pr.ProcessName} {pr.Id}");
            }
            else
            {
                MessageBox.Show("Nothing is selected!");
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Executable files (*.exe)|*.exe";
            if (fd.ShowDialog() == true)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = fd.FileName;
                try
                {
                    Process.Start(info);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
