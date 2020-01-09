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
using System.Windows.Threading;

namespace Porodoro
{
    /// <summary>
    /// Logique d'interaction pour Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        private int time = 1500;
        private DispatcherTimer timers;
        private string titlePomodoro;

        public Timer(string title)
        {
            titlePomodoro = title;
            //Console.WriteLine(Task.Content);
            ShowsNavigationUI = false;
            InitializeComponent();
            Task.Text = titlePomodoro;
            timers = new DispatcherTimer();
            timers.Interval = new TimeSpan(0, 0, 1);
            timers.Tick += Timer_Tick;
            timers.Start();
        }


        void Timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                doTimer.Text = string.Format("{0}:{1}", time / 60, time % 60);
            }
            else
            {
                timers.Stop();
                MessageBox.Show("Fini !");
            }
        }

        void doStart(object sender, EventArgs e)
        {
            timers.Start();
        }
        void doPause(object sender, EventArgs e)
        {
            timers.Stop();
        }
    }
}
