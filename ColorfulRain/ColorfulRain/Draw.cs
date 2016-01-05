using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ColorfulRain
{
    class Draw
    {
        public Bitmap bmp;
        public DrawRain rain;
        
        public Draw(int count)
        {
            bmp = new Bitmap(1000, 650);
            rain = new DrawRain(3,1,count,0,200,10);
        }

        public void DrawImag( )
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            SolidBrush b = new SolidBrush(Color.SkyBlue);
            g.FillRectangle(b, 0, 500, 1000, 150);
            //画雨
            rain.RainFall(bmp);
        }
    }

    class DrawRain
    {
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

        public DrawRain(int spd,int wid,int cnt ,int deg,int alp,int len)
        {
            AddSpeed = 0;
            ran = new Random();
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
                    g.DrawEllipse(p, e.wave.Xsite, e.wave.Ysite, e.wave.hight,e.wave.wide);
                }
                else if(e.status == 0)
                {
                    Pen p = new Pen(e.color, e.wide);
                    Point posA = new Point(e.Xsite, e.Ysite);
                    Point posB = new Point(e.Xsite, e.Ysite + e.length);
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
                        e.Ysite += e.speed+AddSpeed;
                        if (e.Ysite >= e.destina)
                        {
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
    }
}
