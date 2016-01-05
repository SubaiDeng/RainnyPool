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
        public RainDrops(int alpha,int wid,int len,int deg ,int spd,int rand)
        {
            ran = new Random(rand);
            Alpha = alpha ;
            GenerateColor();
            Xsite = ran.Next(1,1000);
            Ysite = 0;
            length = len + ran.Next(0, 10);
            wide = wid + ran.Next(0, 3);
            degree = deg;
            destina = 500+ran.Next(0,150);
            status = 0;
            speed = spd+ran.Next(0,10);
            wave = new Wave(Xsite,destina);
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
}
