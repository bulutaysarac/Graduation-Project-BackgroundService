using System;
using System.Collections.Generic;
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
using System.Timers;
using System.Diagnostics;
using System.Reflection;

namespace BackgroundService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Timer controllerTimer = new Timer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controllerTimer.Interval = 100;
            controllerTimer.Elapsed += ControllerTimer_Elapsed;
            controllerTimer.Start();
            this.Hide();
        }

        private void ControllerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("LabControlClient").Length == 0)
                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\LabControlClient.exe");
            }
            catch{}
        }
    }
}
