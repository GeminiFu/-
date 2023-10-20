using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace 分數圓餅圖
{
    public partial class Form1 : Form
    {
        float radius = 100;
        int section = 3;
        Point center;
        Graphics g;
        Bitmap bmp;
        List<float> angleList = new List<float>();
        bool clickDown1 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);

            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            num_Radius.Value = (decimal)radius;
            num_Section.Value = section;

            DrawCircle();
        }

        private void DrawCircle()
        {
            Pen penBlack = new Pen(Color.Black);
            float p0X, p0Y, p1X, p1Y;
            double radian;

            g.Clear(Color.White); // 畫布清空
            angleList.Clear(); // 角度清空

            // 畫一個圓
            g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

            // 畫線
            for (int i = 0; i < section; i++)
            {
                angleList.Add(360f * i / section);
                radian = DegreeToRad(angleList[i]); // 角度轉弧度
                p0X = center.X; // 中心點
                p0Y = center.Y; // 中心點
                p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
            }

            if (rb_Draw_1.Checked)
            {
                pictureBox1.Image = bmp;
            }
            else if (rb_Draw_2.Checked)
            {
                pictureBox2.Image = bmp;
            }
        }

        private double DegreeToRad(float degree)
        {
            double rad;

            rad = degree * (2f * (float)Math.PI) / 360f; // 360度 = 2PI，角度轉弧度是 x * 2PI / 360

            return rad;
        }

        private float RadToDegree(double rad)
        {
            float degree;

            degree = (float)rad * 360f / (2f * (float)Math.PI); // 360度 = 2PI，弧度轉角度是 x * 360 / 2PI

            return degree;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            radius = (int)num_Radius.Value;

            DrawCircle();
        }

        private void num_Section_ValueChanged(object sender, EventArgs e)
        {
            section = (int)num_Section.Value;

            DrawCircle();
        }

        private void rb_Draw_1_CheckedChanged(object sender, EventArgs e)
        {
            DrawCircle();
        }

        private void rb_Draw_2_CheckedChanged(object sender, EventArgs e)
        {
            DrawCircle();
        }

        private void pictureBox1_ClientSizeChanged(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);

            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);

            DrawCircle();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > (center.X - radius) && e.X < (center.X + radius)) // 判斷 X 軸是否在圓裡面
            {
                if (e.Y > (center.Y - radius) && e.Y < (center.Y + radius)) // 判斷 Y 軸是否在圓裡面
                {
                    clickDown1 = true;

                    float side = e.X - center.X; // 臨邊
                    float opponent = center.Y - e.Y; // 對邊
                    float incline = (float)Math.Sqrt(Math.Pow((double)side, 2) + Math.Pow((double)opponent, 2)); // 斜邊
                    float angle;

                    angle = RadToDegree(Math.Asin(opponent / incline)); // 用反三角函數得到弧度，再把弧度轉成角度

                    // 要把反三角函數得到的角度轉成 360 度的系統
                    if (side < 0 && opponent >= 0)
                    {
                        angle = 90 + (90 - angle); // 把左上四分之一個角度轉過來加上 90 度
                    }
                    else if (side <= 0 && opponent < 0)
                    {
                        angle = 180 - angle; // angle 是負的
                    }
                    else if (side >= 0 && opponent < 0)
                    {
                        angle = 270 + 90 + angle; // angle 是負的
                    }

                    Console.WriteLine($"Click angle is {angle}");

                    // 前面畫圓的時候，順便紀錄每條線的角度
                    // 在這邊找到第一個大於點擊的角度，點擊的位置就在這條線和上一條線中間
                    // 沒找到的話，代表是在最後一塊
                    float index = angleList.FindIndex(x => x > angle); 
                    Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0));
                    float p0X, p0Y, p1X, p1Y;

                    p0X = center.X - radius; // 圓心
                    p0Y = center.Y - radius; // 圓心

                    if (index > 0)
                    {
                        // 填滿圓，畫角度是順時鐘，所以加個負號變成逆時鐘
                        g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList[(int)index - 1], -360 / section);
                    }
                    else
                    {
                        g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList[angleList.Count - 1], -360 / section);
                    }

                    if (rb_Draw_1.Checked)
                    {
                        pictureBox1.Image = bmp; // 畫上圖案
                    }
                    else if (rb_Draw_2.Checked)
                    {
                        pictureBox2.Image = bmp;
                    }
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickDown1)
            {
                if (e.X > (center.X - radius) && e.X < (center.X + radius)) // 判斷 X 軸是否在圓裡面
                {
                    if (e.Y > (center.Y - radius) && e.Y < (center.Y + radius)) // 判斷 Y 軸是否在圓裡面
                    {
                        // 在圓裡面
                        float side = e.X - center.X;
                        float opponent = center.Y - e.Y;
                        float incline = (float)Math.Sqrt(Math.Pow((double)side, 2) + Math.Pow((double)opponent, 2));
                        float angle;

                        angle = RadToDegree(Math.Asin(opponent / incline));
                        Console.WriteLine($"Cosine angle is {angle}");
                        if (side < 0 && opponent >= 0)
                        {
                            angle = 90 + (90 - angle); // 把左上四分之一個角度轉過來加上 90 度
                        }
                        else if (side <= 0 && opponent < 0)
                        {
                            angle = 180 - angle; // angle 是負的
                        }
                        else if (side >= 0 && opponent < 0)
                        {
                            angle = 270 + 90 + angle; // angle 是負的
                        }
                        Console.WriteLine($"Click angle is {angle}");

                        float index = angleList.FindIndex(x => x > angle);
                        Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0));

                        if (index > 0)
                        {
                            g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList[(int)index - 1], -360 / section);
                        }
                        else
                        {
                            g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList[angleList.Count - 1], -360 / section);
                        }

                        if (rb_Draw_1.Checked)
                        {
                            pictureBox1.Image = bmp;
                        }
                        else if (rb_Draw_2.Checked)
                        {
                            pictureBox2.Image = bmp;
                        }
                    }
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            clickDown1 = false;
        }
    }
}
