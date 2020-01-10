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
        private int time = 10;
        private DispatcherTimer timers;
        private string titlePomodoro;
        private int pomodori = 1;
        private Boolean pause = false;
        private Boolean end = false;

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
            Pomodori.Text = $"{pomodori}/4";
            //            timers.Start();
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
                restart();
            }
        }

        void restart()
        {
            Console.WriteLine(pomodori);
            Console.WriteLine(pause);
            if (pomodori <= 4 && !pause) {
                if (pomodori < 4)
                {
                    MessageBox.Show("C'est l'heure de la pause !");
                    setTime(5);
                    pause = true;
                    pomodori += 1;
                } else
                {
                    MessageBox.Show("Session terminer. Pause de 15 minutes ! :)");
                    setTime(15);
                    pause = true;
                    pomodori += 1;
                }
                timers.Start();
            }
            else if (pomodori < 5 && pause)
            {
                MessageBox.Show("Il faut retourné travailler !");
                setTime(10);
                pause = false;
                Pomodori.Text = $"{pomodori}/4";
                timers.Start();
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

        void setTime(int duration)
        {
            time = duration;
        }
    }
}
