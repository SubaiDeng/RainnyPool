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


namespace ColorfulRain
{
    public partial class RainWindow : Form
    {
        Draw draw;
        int count;
        int speed;
        public RainWindow()
        {
            count = 100;
            speed = 0;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            InitializeComponent();
        }

        private void RainWindow_Load(object sender, EventArgs e)
        {
            DegreeBar.Value = 5;
            draw = new Draw(count);
            Thread DrawThread = new Thread(new ThreadStart(paint));
            DrawThread.Start();
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
            count = (value + 1) * 100;
            
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            int value = this.SpeedBar.Value;
            draw.rain.AddSpeed = value;
        }

        private void DegreeBar_Scroll(object sender, EventArgs e)
        {
            int value = this.DegreeBar.Value;
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
        }
    }
}
