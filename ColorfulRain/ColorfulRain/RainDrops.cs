using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ColorfulRain
{
    class RainDrops
    {
        Random ran;//随机数
        public Color color;//颜色
        public int Xsite;//X坐标
        public int Ysite;//Y坐标
        public int Alpha; //透明度
        public int wide;//粗细
        public int length;//长度
        public int degree;//角度
        public int destina;//目标坐标
        public int status; //状态
        public int speed;//速度
        public Wave wave;// 波纹
        public LotusDrop lotusDrop;
        public bool onTheLotus;
        public RainDrops(int alpha,int wid,int len,int deg ,int spd,int rand)
        {
            ran = new Random(rand);
            Alpha = alpha +ran.Next(0,100);
            GenerateColor();
            Xsite = ran.Next(1,1000);
            Ysite = 0;
            length = len + ran.Next(0, 10);
            wide = wid + ran.Next(0, 3);
            degree = deg;
            destina = 500+ran.Next(0,150);
            status = 0;
            speed = spd+ran.Next(0,20);
            wave = new Wave(Xsite,destina);
            lotusDrop = new LotusDrop(Xsite,Ysite,color);
            onTheLotus = false;
        }
        private void GenerateColor()
        {
            int a,b,c;
            a = ran.Next(1,255);
            b = ran.Next(1,255);
            c = ran.Next (1,255);
            color = Color.FromArgb(Alpha,a,b,c);
        }

    }

    class Wave
    {
        public int Xsite;
        public int Ysite;
        public float wide;
        public float hight;
        public float aim;

        public Wave(int x, int y)
        {
            Xsite = x;
            Ysite = y;
            wide = 1;
            hight = 1;
            aim = 30;
        }
    }

    class LotusDrop
    {
        public int Xsite;
        public int Ysite;
        public LightPoint[] DropAry;
        public int status;
        public Color color;


        public  LotusDrop(int x, int y, Color c)
        {
            Xsite = x;
            Ysite = y;
            color = c;
        }
        public void start(int x, int y)
        {
            Xsite = x;
            Ysite = y;
            DropAry = new LightPoint[4];
            DropAry[0] = new LightPoint(Xsite, Ysite, Xsite + (int)(7 * Math.Sin(Math.PI / 6)), Ysite - (int)(7 * Math.Cos(Math.PI / 6)), 255);
            DropAry[1] = new LightPoint(Xsite, Ysite, Xsite + (int)(7 * Math.Sin(Math.PI / -6)), Ysite - (int)(7 * Math.Cos(Math.PI / -6)), 255);
            DropAry[2] = new LightPoint(Xsite, Ysite, Xsite + (int)(7 * Math.Sin(Math.PI / 3)), Ysite - (int)(7 * Math.Cos(Math.PI / 3)), 255);
            DropAry[3] = new LightPoint(Xsite, Ysite, Xsite + (int)(7 * Math.Sin(Math.PI / -3)), Ysite - (int)(7 * Math.Cos(Math.PI / -3)), 255);
            status = 0;
        }

        public void LotusDropDraw(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            Pen p = new Pen(color, 3);
            foreach (var e in DropAry)
            {
                g.DrawLine(p, e.front, e.rear);
            }
            LotusDropRefresh();
        }
        public void Start()
        {
            
        }

        public void LotusDropRefresh()
        {
            int len = 2;
            DropAry[0].front.X += (int)(len * Math.Sin(Math.PI / 6));
            DropAry[0].front.Y -= (int)(len * Math.Cos(Math.PI / 6));
            DropAry[0].rear.X += (int)(len * Math.Sin(Math.PI / 6));
            DropAry[0].rear.Y -= (int)(len * Math.Cos(Math.PI / 6));
            DropAry[1].front.X += (int)(len * Math.Sin(Math.PI / -6));
            DropAry[1].front.Y -= (int)(len * Math.Cos(Math.PI / 6));
            DropAry[1].rear.X += (int)(len * Math.Sin(Math.PI / -6));
            DropAry[1].rear.Y -= (int)(len * Math.Cos(Math.PI / 6));
            DropAry[2].front.X += (int)(len * Math.Sin(Math.PI / 3));
            DropAry[2].front.Y -= (int)(len * Math.Cos(Math.PI / 3));
            DropAry[2].rear.X += (int)(len * Math.Sin(Math.PI / 3));
            DropAry[2].rear.Y -= (int)(len * Math.Cos(Math.PI / 3));
            DropAry[3].front.X += (int)(len * Math.Sin(Math.PI / -3));
            DropAry[3].front.Y -= (int)(len * Math.Cos(Math.PI / 3));
            DropAry[3].rear.X += (int)(len * Math.Sin(Math.PI / -3));
            DropAry[3].rear.Y -= (int)(len * Math.Cos(Math.PI / 3));
            status++;
        }

    }
}
