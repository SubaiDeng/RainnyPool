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
            SolidBrush b = new SolidBrush(Color.SkyBlue);
            g.FillRectangle(b, 0, 500, 1000, 200);
            //画雨
            rain.RainFall(bmp);
            rain.Refresh();
            light.drawLight(bmp);

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
        public int status;
        public List<OneLight> LightAry;
        public int count;
        public Random ran;
        
        public Light(int r)
        {
            ran = new Random(r);
            count  = 0;
            LightAry = new List<OneLight>();
            status = 0;
        }
        public void drawLight(Bitmap bmp)
        {
             if(status == 1)
             {
                OneLight temp = new OneLight(ran.Next());
                LightAry.Add(temp);
            }
            if (LightAry.Count != 0)
            {
                List<OneLight> tempList = new List<OneLight>();
                foreach (var e in LightAry)
                {
                    e.DrawOneLight(bmp);
                    e.Refresh();
                    if (e.nodeAry.Count == 0)
                        tempList.Add(e);
                }
                foreach (var e in tempList)
                {
                    LightAry.Remove(e);
                }                
            }
            status = 0;
        }


    }
    class OneLight
    {
        public int count;
        public Random ran;
        public List<LightPoint> nodeAry;
        public Queue<LightPoint> spread;
        public int status;
        public OneLight(int r)
        {
            ran = new Random(r);
            count = ran.Next(7, 12);
            int Xsite = ran.Next(100, 900);
            int Ysite = ran.Next(0, 20);
            LightPoint firstPoint = new LightPoint();
            firstPoint.front=new Point(Xsite,Ysite);
            firstPoint.rear = new Point(Xsite+ran.Next(-40,40),Ysite+ran.Next(20,30));
            firstPoint.alp = 255;
            firstPoint.status = 1;
            nodeAry = new List<LightPoint>();
            spread = new Queue<LightPoint>();
            spread.Enqueue(firstPoint);
            nodeAry.Add(firstPoint);
            status = 0;
        }
        public void DrawOneLight( Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            //Pen p = new Pen(Color.White, 3);
            //g.DrawLine(p, 10, 10,20,20);
            foreach (var e in nodeAry)
            { 
                Color  color = Color.FromArgb(e.alp,Color.Yellow);
                Pen p = new Pen(color, 3);
                g.DrawLine(p, e.front, e.rear);
            }
        }
        public void Refresh()
        {
            count--;
            for(int i = 0 ; i < nodeAry.Count;i++)
            {
                nodeAry[i].alp -= 10;
            }
            List<LightPoint> tempList;
            tempList = new List<LightPoint>();
            int j = spread.Count;
            while (j> 0)
            {
                tempList.Add(spread.Dequeue());
                j --;
            }
            if (count >= 0)
            {
                foreach (var e in tempList)
                {
                    if (e.status == 1)
                    {
                        LightPoint mainPoint = new LightPoint();
                        mainPoint.front = new Point(e.rear.X, e.rear.Y);
                        mainPoint.rear = new Point(e.rear.X + ran.Next(-40, 40), e.rear.Y + ran.Next(30, 40));
                        mainPoint.alp = 255;
                        mainPoint.status = 1;
                        spread.Enqueue(mainPoint);
                        nodeAry.Add(mainPoint);
                    }
                    else
                    {
                        if (ran.Next(0, 3) == 0)
                        {
                            LightPoint otherPoint = new LightPoint();
                            otherPoint.front = new Point(e.rear.X, e.rear.Y);
                            otherPoint.rear = new Point(e.rear.X + ran.Next(-40, 40), e.rear.Y + ran.Next(30, 40));
                            otherPoint.alp = 255;
                            otherPoint.status = 0;
                            spread.Enqueue(otherPoint);
                            nodeAry.Add(otherPoint);
                        }
                    }
                    if (ran.Next(0, 3) == 0)
                    {
                        LightPoint otherPoint = new LightPoint();
                        otherPoint.front = new Point(e.rear.X, e.rear.Y);
                        otherPoint.rear = new Point(e.rear.X + ran.Next(-40, 40), e.rear.Y + ran.Next(30, 40));
                        otherPoint.alp = 255;
                        otherPoint.status = 0;
                        spread.Enqueue(otherPoint);
                        nodeAry.Add(otherPoint);
                    }
                }         
            
            }
            List<LightPoint> tempAry = new List<LightPoint>();
            foreach(var e in nodeAry)
            {
                if (e.alp <= 0)
                    tempAry.Add(e);
            }
            foreach (var e in tempAry)
            {
                nodeAry.Remove(e);
            }
        }
    }
    class LightPoint
    {
        public Point front;
        public Point rear;
        public int alp;
        public int status;
    }
}
