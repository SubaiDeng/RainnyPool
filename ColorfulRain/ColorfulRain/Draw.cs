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
        public LotusPool lotusPool;
        
        public Draw(int count)
        {
            ran = new Random();
            lotusPool = new LotusPool(); 
            bmp =new Bitmap(1000, 650);
            rain = new DrawRain(1,2,count,0,150,10,ran.Next(),this);
            light = new Light(ran.Next());
        }

        public void DrawImag( )
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.FromArgb(0,0,40));
            BackgroundDraw();

            //画雨
            rain.WaveDraw(bmp);
            lotusPool.DrawLotus(bmp);
            light.drawLight(bmp);
            rain.RainFall(bmp);
            rain.LotusDropDraw(bmp);
            rain.Refresh();

        }
        public void BackgroundDraw()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Point point1;
            Point point2;
            Point point3;
            Point point4;
            Point point5;
            SolidBrush b;
            //画山
            //山1
            b = new SolidBrush(Color.FromArgb(0, 70, 0));
            point1 = new Point(-100, 550);
            point2 = new Point(150, 200);
            point3 = new Point(400, 550);
            Point[] mountain1;
            mountain1 = new Point[3];
            mountain1[0] = point1;
            mountain1[1] = point2;
            mountain1[2] = point3;
            g.FillClosedCurve(b, mountain1);


            //山4
            b = new SolidBrush(Color.FromArgb(0, 50, 0));
            point1 = new Point(750, 550);
            point2 = new Point(900, 100);
            point3 = new Point(1300, 550);
            Point[] mountain4;
            mountain4 = new Point[3];
            mountain4[0] = point1;
            mountain4[1] = point2;
            mountain4[2] = point3;
            g.FillClosedCurve(b, mountain4);
            //山3
            b = new SolidBrush(Color.FromArgb(0,100,0));
            point1 = new Point(600, 550);
            point2 = new Point(750, 200);
            point3 = new Point(1000, 550);
            Point[] mountain3;
            mountain3 = new Point[3];
            mountain3[0] = point1;
            mountain3[1] = point2;
            mountain3[2] = point3;
            g.FillClosedCurve(b, mountain3);            
            //山2
            b = new SolidBrush(Color.FromArgb(0, 130, 0));
            point1 = new Point(100, 550);
            point2 = new Point(300, 300);
            point3 = new Point(600, 550);
            Point[] mountain2;
            mountain2 = new Point[3];
            mountain2[0] = point1;
            mountain2[1] = point2;
            mountain2[2] = point3;
            g.FillClosedCurve(b, mountain2);

            //画湖
            b = new SolidBrush(Color.SkyBlue);
            point1 = new Point(0, 500);
            point2 = new Point(500, 470);
            point3 = new Point(1000, 500);
            point4 = new Point(1000, 650);
            point5 = new Point(0, 650);
            Point[] pool;
            pool = new Point[5];
            pool[0] = point1;
            pool[1] = point2;
            pool[2] = point3;
            pool[3] = point4;
            pool[4] = point5;
            g.FillClosedCurve(b, pool);
            //画月亮
            g.FillEllipse(Brushes.LightYellow,40,20,55,55);
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
        public Draw draw;

        public DrawRain(int spd,int wid,int cnt ,int deg,int alp,int len,int r,Draw d)
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
            draw = d;
        }

        public void RainFall(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            foreach(var e in lis)
            {
                if (e.status == 0)
                {
                    int destX = e.Xsite + (int)(e.length * (e.degree == 0 ? 0 : Math.Sin(Math.PI / e.degree)));
                    int destY = e.Ysite + (int)(e.length * (e.degree == 0 ? 1 : Math.Cos(Math.PI / e.degree)));
                    bool onTheLotus = false;
                    foreach(var f in draw.lotusPool.LotusAry)
                    {
                        if(true == f.InLotus(destX,destY))
                        {
                            onTheLotus = true;
                        }
                    }
                    if (onTheLotus == false)
                    {
                        e.onTheLotus = false;
                        Pen p = new Pen(e.color, e.wide);
                        p.StartCap = LineCap.Triangle;
                        p.EndCap = LineCap.Triangle;
                        Point posA = new Point(e.Xsite, e.Ysite);
                        Point posB = new Point(destX, destY);
                        g.DrawLine(p, posA, posB);
                        p.Dispose();
                    }
                    else
                    {
                        e.onTheLotus = true;
                    }
                }      
            }
        }
        public void LotusDropDraw(Bitmap bmp)
        {

            {
                Graphics g = Graphics.FromImage(bmp);
                foreach (var e in lis)
                {

                    if (e.status == 1 && e.onTheLotus == true)
                        e.lotusDrop.LotusDropDraw(bmp);
                }
            }
        }
        public void WaveDraw( Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var e in lis)
            {
                if (e.status == 1&&e.onTheLotus == false)
                {
                    Pen p = new Pen(e.color, 2);
                    g.DrawEllipse(p, e.wave.Xsite, e.wave.Ysite, e.wave.hight, e.wave.wide);
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
                        e.Xsite = (e.Xsite + (int)((e.length+AddSpeed) * (e.degree == 0 ? 0 : Math.Sin(Math.PI / e.degree)))+1000)%1000;
                        e.Ysite = e.Ysite + (int)((e.length+AddSpeed) * (e.degree == 0 ? 1 : Math.Cos(Math.PI / e.degree)));
                        if (e.Xsite >= 1000)
                            e.Xsite %= 1000;
                        if (e.Ysite >= e.destina)
                        {
                            if (false)
                                SoundPlay();
                            e.status = 1;
                            e.wave.Xsite = e.Xsite;
                            e.wave.Ysite = e.Ysite;
                            e.lotusDrop.start(e.Xsite, e.Ysite);
                        }
                        break;
                    case 1:
                        if (e.onTheLotus == false)
                        {
                            e.wave.wide++;
                            e.wave.hight = e.wave.wide * 2;
                            e.wave.Xsite = (e.wave.Xsite - 1 + 1000) % 1000;
                            if (e.wave.wide >= e.wave.aim)
                                e.status = 2;
                        }
                        else
                        {
                            e.lotusDrop.LotusDropRefresh();
                            if (e.lotusDrop.status >= 30)
                                e.status = 2;                        
                        }
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
            g.SmoothingMode = SmoothingMode.AntiAlias;
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
        public LightPoint(int fx, int fy, int rx, int ry, int a)
        {
            front = new Point(fx, fy);
            rear = new Point(rx, ry);
            alp = a;
            status = 0;
        }
        public LightPoint()
        {
            alp = 0;
            status = 0;
        }
    }

    class LotusPool
    {
        public List<Lotus> LotusAry;
        public int status;
        public LotusPool ()
        {
            LotusAry = new List<Lotus>();
            Lotus temp;
            temp = new Lotus(30, 535, 120, 30);
            LotusAry.Add(temp);
            temp = new Lotus(140, 565, 150, 40);
            LotusAry.Add(temp);
            temp = new Lotus(70, 605, 90, 20);
            LotusAry.Add(temp);

            status = 1;
        }
        public void DrawLotus(Bitmap bmp)
        {
            if(status == 1)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                foreach (var e in LotusAry)
                {
                    g.FillEllipse(new SolidBrush(Color.FromArgb(50,160,0)), e.Xsite, e.Ysite, e.doubleA, e.doubleB);
                    PointF point1;
                    PointF point2;
                    PointF point3;

                    point1 = new PointF(e.Xsite+(int)(e.doubleA/2),e.Ysite+(int)(e.doubleB/2));
                    point2 = new PointF(e.Xsite + (int)(e.doubleA / 2) + 20, e.Ysite + (int)(e.doubleB/2) - 3);
                    point3 = new PointF(e.Xsite + (int)(e.doubleA / 2) + 40, e.Ysite + (int)(e.doubleB/2)+3);                
                   PointF[] c;
                   int col = 120;
                    c = new PointF[3];
                    c[0] = point1;
                    c[1] = point2;
                    c[2] = point3;
                    g.DrawCurve(new Pen(Color.FromArgb(0, col, 0), 2), c);


                    point1 = new PointF(e.Xsite + (int)(e.doubleA / 2), e.Ysite + (int)(e.doubleB / 2));
                    point2 = new PointF(e.Xsite + (int)(e.doubleA / 2) - 20, e.Ysite + (int)(e.doubleB / 2) - 3);
                    point3 = new PointF(e.Xsite + (int)(e.doubleA / 2) - 40, e.Ysite + (int)(e.doubleB / 2)+3);
                    c = new PointF[3];
                    c[0] = point1;
                    c[1] = point2;
                    c[2] = point3;
                    g.DrawCurve(new Pen(Color.FromArgb(0, col, 0), 2), c);


                    point1 = new PointF(e.Xsite + (int)(e.doubleA / 2), e.Ysite + (int)(e.doubleB / 2));
                    point2 = new PointF(e.Xsite + (int)(e.doubleA / 2) + 20, e.Ysite + (int)(e.doubleB / 2) -6);
                    point3 = new PointF(e.Xsite + (int)(e.doubleA / 2) + 40, e.Ysite + (int)(e.doubleB / 2) -3);
                    c = new PointF[3];
                    c[0] = point1;
                    c[1] = point2;
                    c[2] = point3;
                    g.DrawCurve(new Pen(Color.FromArgb(0, col, 0), 2), c);


                    point1 = new PointF(e.Xsite + (int)(e.doubleA / 2), e.Ysite + (int)(e.doubleB / 2));
                    point2 = new PointF(e.Xsite + (int)(e.doubleA / 2) - 20, e.Ysite + (int)(e.doubleB / 2) - 6);
                    point3 = new PointF(e.Xsite + (int)(e.doubleA / 2) - 40, e.Ysite + (int)(e.doubleB / 2) - 3);
                    c = new PointF[3];
                    c[0] = point1;
                    c[1] = point2;
                    c[2] = point3;
                    g.DrawCurve(new Pen(Color.FromArgb(0, col, 0), 2), c);

                }
            }
        }
    }

    class Lotus
    {
        public int Xsite;
        public int Ysite;
        public int doubleA;
        public int doubleB;

        public Lotus(int x,int y,int da, int db)
        { 
            Xsite = x;
            Ysite = y;
            doubleA = da;
            doubleB = db;        
        }
        public bool InLotus(int x, int y)
        {
            float a = doubleA / 2;
            float b = doubleB / 2;
            int centerX = Xsite + (int)(a);
            int centerY = Ysite + (int)(b);
            float ans;
            ans = (x - centerX) * (x - centerX) / (a * a) + (y - centerY) * (y - centerY) / (b * b);
            if (ans < 1)
                return true;
            else
                return false;
        }
    }


}
