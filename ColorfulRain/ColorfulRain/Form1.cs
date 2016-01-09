using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Media;


namespace ColorfulRain
{
    public partial class RainWindow : Form
    {
        Draw draw;
        int count;
        int speed;
        Thread paintThread;
        Thread windThread;
        Thread denseThread;
        public RainWindow()
        {
            count = 100;
            speed = 0;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            windThread = null;
            denseThread = null;
            InitializeComponent();
            axWindowsMediaPlayer1.settings.setMode("loop", true);
        }

        private void RainWindow_Load(object sender, EventArgs e)
        {
            DegreeBar.Value = 5;
            draw = new Draw(count);
            paintThread = new Thread(new ThreadStart(paint));
            paintThread.Start();
            axWindowsMediaPlayer1.URL = @"Sound\little.mp3";
        }

        private void RainWindow_Paint(object sender, PaintEventArgs e)
        {
        }
        private void paint()
        {
            while (true)
            {
                draw.DrawImag();
                this.CreateGraphics().DrawImage(draw.bmp, 0, 0);                
                Delay(10);
                draw.rain.count = count;
            }
        }

        //延时函数，延时  n ms
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        private void DenseBar_Scroll(object sender, EventArgs e)
        {
            int value = this.DenseBar.Value;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            if (denseThread != null)
            {
                denseThread.Abort();
                denseThread = null;
            }
            count = (value + 1) * 100;
            if (value < 3)
            {
                axWindowsMediaPlayer1.URL = @"Sound\little.mp3";
            }
            else if (value < 7)
            {
                axWindowsMediaPlayer1.URL = @"Sound\middle.mp3";
            }
            else
            {
                axWindowsMediaPlayer1.URL = @"Sound\big.mp3";
            }
            
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            int value = this.SpeedBar.Value;
            draw.rain.AddSpeed = value;
        }

        private void DegreeBar_Scroll(object sender, EventArgs e)
        {
            int value = this.DegreeBar.Value;
            if (windThread != null)
            {
                windThread.Abort();
                windThread = null;            
            }
            switch (value)
            {
                case 0:
                    draw.rain.degree = -3;
                    break;
                case 1:
                    draw.rain.degree = -4;
                    break;
                case 2:
                    draw.rain.degree = -5;
                    break;
                case 3:
                    draw.rain.degree = -6;
                    break;
                case 4:
                    draw.rain.degree = -7;
                    break;
                case 5:
                    draw.rain.degree = 0;
                    break;
                case 6:
                    draw.rain.degree = 7;
                    break;
                case 7:
                    draw.rain.degree = 6;
                    break;
                case 8:
                    draw.rain.degree = 5;
                    break;
                case 9:
                    draw.rain.degree = 4;
                    break;
                case 10:
                    draw.rain.degree = 3;
                    break;
                    
            }
        }

        private void lightning_Click(object sender, EventArgs e)
        {
            draw.light.status = 1;
            System.Media.SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = @"Sound\light.wav";
            sp.Play();
        }

        private void RainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            paintThread.Abort();
            if (windThread != null)
                windThread.Abort();
            if (denseThread != null)
                denseThread.Abort();
        }

        private void windy_Click(object sender, EventArgs e)
        {
            if (windThread == null)
            {
                windThread = new Thread(new ThreadStart(WindStart));
                windThread.Start();
            }
        }
        private void WindStart()
        {
            int temp = 1;
            int n = 3;
            while(true)
            {
                draw.rain.degree = n*temp;
                n++;
                Delay(500);
                if (n == 8)
                {
                    temp *= -1;
                    n = 3;
                }
            }
        }

        private void brash_Click(object sender, EventArgs e)
        {
            if (denseThread == null)
            {
                denseThread = new Thread(new ThreadStart(DenseStart));
                denseThread.Start();
            }
        }
        private void DenseStart()
        {
            int n = 3;
            while (true)
            {
                Delay(1000);
                switch (n)
                { 
                    case 3:
                        n = 5;
                        break;
                    case 5:
                        n = 8;
                        break;
                    case 8:
                        n = 3;
                        break;
                    default: break;
                }
                count = (n + 1) * 200;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            count = 0;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
    }
}
