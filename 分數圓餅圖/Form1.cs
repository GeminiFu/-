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
        float radius = 200;
        int section1 = 3;
        int section2 = 3;

        Point center;
        Graphics g;
        Bitmap bmp;
        List<float> angleList1 = new List<float>();
        List<float> angleList1Count = new List<float>();
        List<float> angleList2 = new List<float>();
        List<float> angleList2Count = new List<float>();
        bool clickDown1 = false;
        Brush brush = new SolidBrush(Color.FromArgb(255, 0, 0));

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);

            center = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            num_Radius.Value = (decimal)radius;
            num_Section.Value = section1;
            lbl_Section1.Text = $"0 / 3";
            lbl_Section2.Text = $"0 / 3";
            //DrawCircle();

            rb_Draw_2.Checked = true;
            rb_Draw_1.Checked = true;
        }

        private void DrawCircle()
        {
            Pen penBlack = new Pen(Color.Black);
            float p0X, p0Y, p1X, p1Y;
            double radian;

            if (rb_Draw_1.Checked)
            {
                g.Clear(Color.White); // 畫布清空
                angleList1.Clear(); // 角度清空

                // 畫一個圓
                g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                // 畫線
                for (int i = 0; i < section1; i++)
                {
                    if (section1 == 1)
                    {
                        break;
                    }
                    angleList1.Add(360f * i / section1);
                    radian = DegreeToRad(angleList1[i]); // 角度轉弧度
                    p0X = center.X; // 中心點
                    p0Y = center.Y; // 中心點
                    p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                    p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                    g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
                }

                pictureBox1.Image = bmp;
            }
            else if (rb_Draw_2.Checked)
            {
                g.Clear(Color.White); // 畫布清空
                angleList2.Clear(); // 角度清空

                // 畫一個圓
                g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                // 畫線
                for (int i = 0; i < section2; i++)
                {
                    if (section2 == 1)
                    {
                        break;
                    }

                    angleList2.Add(360f * i / section2);
                    radian = DegreeToRad(angleList2[i]); // 角度轉弧度
                    p0X = center.X; // 中心點
                    p0Y = center.Y; // 中心點
                    p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                    p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                    g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
                }

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
            if (rb_Draw_1.Checked)
            {
                angleList1Count.Clear();

                section1 = (int)num_Section.Value;
                lbl_Section1.Text = $"{angleList1Count.Count} / {section1}";
            }
            else if (rb_Draw_2.Checked)
            {
                angleList2Count.Clear();
                section2 = (int)num_Section.Value;
                lbl_Section2.Text = $"{angleList2Count.Count} / {section2}";
            }

            DrawCircle();
        }

        private void rb_Draw_1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Draw_1.Checked)
            {
                num_Section.Value = section1;
            }
            DrawCircle();
        }

        private void rb_Draw_2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Draw_2.Checked)
            {
                num_Section.Value = section2;
            }
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

                    if (rb_Draw_1.Checked)
                    {
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
                        float index = angleList1.FindIndex(x => x > angle);
                        float p0X, p0Y, p1X, p1Y;

                        p0X = center.X - radius; // 圓心
                        p0Y = center.Y - radius; // 圓心

                        if (index > 0)
                        {
                            // 填滿圓，畫角度是順時鐘，所以加個負號變成逆時鐘
                            g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList1[(int)index - 1], -360 / section1);

                            if (!angleList1Count.Any(x => x == angleList1[(int)index]))
                            {
                                angleList1Count.Add(angleList1[(int)index]);
                            }
                        }
                        else
                        {
                            g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList1[angleList1.Count - 1], -360 / section1);

                            if (!angleList1Count.Any(x => x == 0))
                            {
                                angleList1Count.Add(0);
                            }
                        }

                        lbl_Section1.Text = $"{angleList1Count.Count} / {section1}";
                        pictureBox1.Image = bmp; // 畫上圖案
                    }
                    else if (rb_Draw_2.Checked)
                    {
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
                        float index = angleList2.FindIndex(x => x > angle);
                        float p0X, p0Y, p1X, p1Y;

                        p0X = center.X - radius; // 圓心
                        p0Y = center.Y - radius; // 圓心

                        if (index > 0)
                        {
                            // 填滿圓，畫角度是順時鐘，所以加個負號變成逆時鐘
                            g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList2[(int)index - 1], -360 / section2);

                            if (!angleList2Count.Any(x => x == angleList2[(int)index]))
                            {
                                angleList2Count.Add(angleList2[(int)index]);
                            }
                        }
                        else
                        {
                            g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList2[angleList2.Count - 1], -360 / section2);

                            if (!angleList2Count.Any(x => x == 0))
                            {
                                angleList2Count.Add(0);
                            }
                        }

                        lbl_Section2.Text = $"{angleList2Count.Count} / {section2}";
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

                        if (rb_Draw_1.Checked)
                        {                        // 在圓裡面
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

                            float index = angleList1.FindIndex(x => x > angle);

                            if (index > 0)
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList1[(int)index - 1], -360 / section1);
                                if (!angleList1Count.Any(x => x == angleList1[(int)index]))
                                {
                                    angleList1Count.Add(angleList1[(int)index]);
                                }
                            }
                            else
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList1[angleList1.Count - 1], -360 / section1);
                                if (!angleList1Count.Any(x => x == 0))
                                {
                                    angleList1Count.Add(0);
                                }
                            }

                            lbl_Section1.Text = $"{angleList1Count.Count} / {section1}";
                            pictureBox1.Image = bmp;
                        }
                        else if (rb_Draw_2.Checked)
                        {                        // 在圓裡面
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

                            float index = angleList2.FindIndex(x => x > angle);

                            if (index > 0)
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList2[(int)index - 1], -360 / section2);

                                if (!angleList2Count.Any(x => x == angleList2[(int)index]))
                                {
                                    angleList2Count.Add(angleList2[(int)index]);
                                }
                            }
                            else
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList2[angleList2.Count - 1], -360 / section2);

                                if (!angleList2Count.Any(x => x == 0))
                                {
                                    angleList2Count.Add(0);
                                }
                            }

                            lbl_Section2.Text = $"{angleList2Count.Count} / {section2}";
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

        // ----------------------------------------------------
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > (center.X - radius) && e.X < (center.X + radius)) // 判斷 X 軸是否在圓裡面
            {
                if (e.Y > (center.Y - radius) && e.Y < (center.Y + radius)) // 判斷 Y 軸是否在圓裡面
                {
                    if (section1 == 0)
                    {
                        return;
                    }

                    clickDown1 = true;

                    if (rb_Draw_1.Checked)
                    {
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
                        float index = angleList1.FindIndex(x => x > angle);
                        float p0X, p0Y, p1X, p1Y;

                        p0X = center.X - radius; // 圓心
                        p0Y = center.Y - radius; // 圓心

                        if (index > 0)
                        {
                            // 填滿圓，畫角度是順時鐘，所以加個負號變成逆時鐘
                            g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList1[(int)index - 1], -360f / section1);

                            if (!angleList1Count.Any(x => x == angleList1[(int)index]))
                            {
                                angleList1Count.Add(angleList1[(int)index]);
                            }
                        }
                        else
                        {
                            if (section1 == 1)
                            {
                                g.FillEllipse(brush, p0X, p0Y, 2 * radius, 2 * radius);

                            }
                            else
                            {
                                g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList1[angleList1.Count - 1], -360f / section1);
                            }

                            if (!angleList1Count.Any(x => x == 0))
                            {
                                angleList1Count.Add(0);
                            }
                        }

                        Pen penBlack = new Pen(Color.Black);
                        double radian;

                        // 畫一個圓
                        g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                        // 畫線
                        for (int i = 0; i < section1; i++)
                        {
                            if (section1 == 1)
                            {
                                break;
                            }
                            angleList1.Add(360f * i / section1);
                            radian = DegreeToRad(angleList1[i]); // 角度轉弧度
                            p0X = center.X; // 中心點
                            p0Y = center.Y; // 中心點
                            p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                            p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                            g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
                        }


                        lbl_Section1.Text = $"{angleList1Count.Count} / {section1}";
                        pictureBox1.Image = bmp; // 畫上圖案
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clickDown1)
            {
                if (e.X > (center.X - radius) && e.X < (center.X + radius)) // 判斷 X 軸是否在圓裡面
                {
                    if (e.Y > (center.Y - radius) && e.Y < (center.Y + radius)) // 判斷 Y 軸是否在圓裡面
                    {
                        if (section1 == 0)
                        {
                            return;
                        }

                        if (rb_Draw_1.Checked)
                        {                        // 在圓裡面
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

                            float index = angleList1.FindIndex(x => x > angle);

                            if (index > 0)
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList1[(int)index - 1], -360f / section1);
                                if (!angleList1Count.Any(x => x == angleList1[(int)index]))
                                {
                                    angleList1Count.Add(angleList1[(int)index]);
                                }
                            }
                            else
                            {
                                if (section1 == 1)
                                {
                                    g.FillEllipse(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
                                }
                                else
                                {
                                    g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList1[angleList1.Count - 1], -360f / section1);
                                }
                                if (!angleList1Count.Any(x => x == 0))
                                {
                                    angleList1Count.Add(0);
                                }
                            }

                            Pen penBlack = new Pen(Color.Black);
                            double radian;
                            float p0X, p0Y, p1X, p1Y;

                            // 畫一個圓
                            g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                            // 畫線
                            for (int i = 0; i < section1; i++)
                            {
                                if (section1 == 1)
                                {
                                    break;
                                }
                                angleList1.Add(360f * i / section1);
                                radian = DegreeToRad(angleList1[i]); // 角度轉弧度
                                p0X = center.X; // 中心點
                                p0Y = center.Y; // 中心點
                                p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                                p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                                g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
                            }


                            lbl_Section1.Text = $"{angleList1Count.Count} / {section1}";
                            pictureBox1.Image = bmp;
                        }
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            clickDown1 = false;
        }
        // ----------------------------------------------------

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > (center.X - radius) && e.X < (center.X + radius)) // 判斷 X 軸是否在圓裡面
            {
                if (e.Y > (center.Y - radius) && e.Y < (center.Y + radius)) // 判斷 Y 軸是否在圓裡面
                {
                    if (section2 == 0)
                    {
                        return;
                    }
                    
                    clickDown1 = true;

                    if (rb_Draw_2.Checked)
                    {
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
                        float index = angleList2.FindIndex(x => x > angle);
                        float p0X, p0Y, p1X, p1Y;

                        p0X = center.X - radius; // 圓心
                        p0Y = center.Y - radius; // 圓心

                        if (index > 0)
                        {
                            // 填滿圓，畫角度是順時鐘，所以加個負號變成逆時鐘
                            g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList2[(int)index - 1], -360f / section2);

                            if (!angleList2Count.Any(x => x == angleList2[(int)index]))
                            {
                                angleList2Count.Add(angleList2[(int)index]);
                            }
                        }
                        else
                        {
                            if (section2 == 1)
                            {
                                g.FillEllipse(brush, p0X, p0Y, 2 * radius, 2 * radius);
                            }
                            else
                                g.FillPie(brush, p0X, p0Y, 2 * radius, 2 * radius, -angleList2[angleList2.Count - 1], -360f / section2);

                            if (!angleList2Count.Any(x => x == 0))
                            {
                                angleList2Count.Add(0);
                            }
                        }
                        Pen penBlack = new Pen(Color.Black);
                        double radian;

                        // 畫一個圓
                        g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                        // 畫線
                        for (int i = 0; i < section2; i++)
                        {
                            if (section2 == 1)
                            {
                                break;
                            }
                            angleList2.Add(360f * i / section2);
                            radian = DegreeToRad(angleList2[i]); // 角度轉弧度
                            p0X = center.X; // 中心點
                            p0Y = center.Y; // 中心點
                            p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                            p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                            g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
                        }

                        lbl_Section2.Text = $"{angleList2Count.Count} / {section2}";
                        pictureBox2.Image = bmp;
                    }
                }
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (section2 == 0)
            {
                return;
            }
            if (clickDown1)
            {
                if (e.X > (center.X - radius) && e.X < (center.X + radius)) // 判斷 X 軸是否在圓裡面
                {
                    if (e.Y > (center.Y - radius) && e.Y < (center.Y + radius)) // 判斷 Y 軸是否在圓裡面
                    {
                        if (rb_Draw_2.Checked)
                        {                        // 在圓裡面
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

                            float index = angleList2.FindIndex(x => x > angle);

                            if (index > 0)
                            {
                                g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList2[(int)index - 1], -360f / section2);

                                if (!angleList2Count.Any(x => x == angleList2[(int)index]))
                                {
                                    angleList2Count.Add(angleList2[(int)index]);
                                }
                            }
                            else
                            {
                                if (section2 == 1)
                                {
                                    g.FillEllipse(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
                                }
                                else
                                    g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, -angleList2[angleList2.Count - 1], -360f / section2);

                                if (!angleList2Count.Any(x => x == 0))
                                {
                                    angleList2Count.Add(0);
                                }
                            }
                            Pen penBlack = new Pen(Color.Black);
                            double radian;
                            float p0X, p0Y, p1X, p1Y;

                            // 畫一個圓
                            g.DrawEllipse(penBlack, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);

                            // 畫線
                            for (int i = 0; i < section2; i++)
                            {
                                if (section2 == 1)
                                {
                                    break;
                                }
                                angleList2.Add(360f * i / section2);
                                radian = DegreeToRad(angleList2[i]); // 角度轉弧度
                                p0X = center.X; // 中心點
                                p0Y = center.Y; // 中心點
                                p1X = center.X + ((float)Math.Cos(radian) * radius); // Cosine 算臨邊 也就是 X 座標
                                p1Y = center.Y + ((float)Math.Sin(radian) * radius); // Sine 算臨邊 也就是 Y 座標
                                g.DrawLine(penBlack, p0X, p0Y, p1X, p1Y); // 畫線
                            }

                            lbl_Section2.Text = $"{angleList2Count.Count} / {section2}";
                            pictureBox2.Image = bmp;
                        }
                    }
                }
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            clickDown1 = false;
        }

        private void btn_Pick_Color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                brush = new SolidBrush(colorDialog.Color);
            }
        }
    }
}
