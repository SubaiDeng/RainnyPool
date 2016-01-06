using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;

namespace ColorfulRain
{
    class Draw
    {
        public Bitmap bmp;
        public DrawRain rain;
        public Light light;
        public Random ran;
        
        public Draw(int count)
        {
            ran = new Random();
            bmp = new Bitmap(1000, 650);
            rain = new DrawRain(1,1,count,0,150,10,ran.Next());
            light = new Light(ran.Next());
        }

        public void DrawImag( )
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            SolidBrush b = new SolidBrush(Color.Gray);
            g.FillRectangle(b, 0, 500, 1000, 200);
            //画雨
            rain.RainFall(bmp);
            light.Show(bmp);
        }
    }

    class DrawRain
    {

        [DllImport("kernel32.dll")]
        private static extern int Beep(int dwFreq, int dwDuration); 

        private Random ran;
        private List<RainDrops> lis;
        public int speed;//下雨速度
        public int wide;//雨滴宽度
        public int status;//状态
        public int count;//雨滴数目
        public int degree;//角度
        public int alpha;//透明度
        public int length;//长度
        public int AddSpeed;

        public DrawRain(int spd,int wid,int cnt ,int deg,int alp,int len,int r)
        {
            AddSpeed = 0;
            ran = new Random(r);
            lis = new List<RainDrops>();
            speed = spd;
            wide = wid;
            count = cnt;
            degree = deg;
            alpha = alp;
            length = len;
            status = 0;
        }

        public void RainFall(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            foreach(var e in lis)
            {
                if (e.status == 1)
                {
                    Pen p = new Pen(e.color, 2);
                    g.DrawEllipse(p, e.wave.Xsite , e.wave.Ysite, e.wave.hight, e.wave.wide);
                }
                else if(e.status == 0)
                {
                    Pen p = new Pen(e.color, e.wide);
                    p.StartCap = LineCap.Triangle;
                    p.EndCap = LineCap.Triangle;
                    Point posA = new Point(e.Xsite, e.Ysite);
                    Point posB = new Point(e.Xsite + (int)(e.length * (e.degree == 0 ? 0 : Math.Sin(Math.PI / e.degree))), e.Ysite + (int)( e.length * (e.degree == 0 ? 1 :Math.Cos(Math.PI / e.degree))));
                    g.DrawLine(p, posA, posB);
                    p.Dispose();                
                }
            }
        }
        public void Refresh()
        {
            List<RainDrops> temp;
            temp = new List<RainDrops>();

            foreach (var e in lis)
            {
                switch(e.status)
                {
                    case 0:
                        e.Alpha = ran.Next(0, 255);
                        e.Xsite = (e.Xsite + (int)((e.length+AddSpeed) * (e.degree == 0 ? 0 : Math.Sin(Math.PI / e.degree)))+1000)%1000;
                        e.Ysite = e.Ysite + (int)((e.length+AddSpeed) * (e.degree == 0 ? 1 : Math.Cos(Math.PI / e.degree)));
                        if (e.Xsite >= 1000)
                            e.Xsite %= 1000;
                        if (e.Ysite >= e.destina)
                        {
                            if (false)
                                SoundPlay();
                            e.status = 1;
                        }
                        break;
                    case 1:
                        e.wave.wide ++;
                        e.wave.hight = e.wave.wide * 2;
                        e.wave.Xsite = (e.wave.Xsite-1+1000)%1000;
                        if (e.wave.wide >= e.wave.aim)
                            e.status = 2;
                        break;
                    case 2:
                        temp.Add(e);
                        break;
                    default:
                        break;
                }
            }
            while (lis.Count < count)
            {
                lis.Add(new RainDrops(alpha, wide, length, degree, speed, ran.Next()));
            }
            foreach(var e in temp)
            {
                lis.Remove(e);
            }
        }
        public void SoundPlay()
        {
            Thread soundThread = new Thread(new ThreadStart(Sound));
            soundThread.Start();
        }
        public void Sound()
        {
            int a = 0X600;
            int b = 25;
            Beep(a, b);
        }
    }
    class Light
    {
        public int node;
        public int size;
        public Random ran;
        public int Xsite;
        public int Ysite;
        public int status;

        public int time;
        
        public Light(int r)
        {
            ran = new Random(r);
            node = ran.Next(7, 12);
            size = ran.Next(10, 20);
            Xsite = ran.Next(100, 900);
            Ysite = ran.Next(0, 20);
            
        }
        public  void Show(Bitmap bmp)
        {
            int j = ran.Next(7,12);
            drawLight(bmp, Xsite,Ysite,j);
        }
        private void drawLight(Bitmap bmp,int x,int y, int c)
        {
            if (c <= 0)
                return;
            int temp = ran.Next(0, 3);
            int nextX = x + ran.Next(-40, 40);
            int nextY = y + ran.Next(30, 40);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(Pens.Yellow,x,y,nextX,nextY);
            if (temp == 0)
            {
                nextX = x + ran.Next(-40, 40);
                nextY = y + ran.Next(30, 40);
                g.DrawLine(Pens.Yellow, x, y, nextX, nextY);
                drawLight(bmp, nextX, nextY, c - 1);
            }
            drawLight(bmp, nextX, nextY, c - 1);
        }
    }

}
