using System.Threading;

namespace CS_DrawingUsingCode_Example
{
    public partial class Form1 : Form
    {
        bool isRun;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isRun = false;
            CreateGraphics().Clear(BackColor);
            for (int i = 20; i < 800; i += 20)
                CreateGraphics().DrawLine(Pens.Red, new Point(i, 60), new Point(i += 200, 60));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isRun = false;
            CreateGraphics().Clear(BackColor);
            Point[] points = { new Point(300, 250), new Point(600, 50), new Point(900, 250), new Point(300, 250) };
            CreateGraphics().DrawLines(Pens.Red, points);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isRun = !isRun;

            ThreadPool.QueueUserWorkItem(delegate
            {                
                CreateGraphics().Clear(BackColor);
                int x = 400, y = 120, z = 300;
                while (true)
                {
                    for (; z > 0; x += 10, y += 10, z -= 20)
                    {
                        Thread.Sleep(30);
                        if (!isRun) return;
                        CreateGraphics().DrawRectangle(Pens.Red, x, y, z, z);
                    }
                    for (; z < 300; x -= 10, y -= 10, z += 20)
                    {
                        Thread.Sleep(30);
                        if (!isRun) return;
                        CreateGraphics().DrawRectangle(Pens.White, x, y, z, z);
                    }
                }
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isRun = !isRun;

            ThreadPool.QueueUserWorkItem(delegate
            {
                CreateGraphics().Clear(BackColor);
                int x = 400, z = 300;
                while (true)
                {
                    for (; z > 0; x += 10, z -= 20)
                    {
                        Thread.Sleep(30);
                        if (!isRun) return;
                        CreateGraphics().DrawEllipse(Pens.Red, x, 120, z, 300);
                    }
                    for (; z < 300; x -= 10, z += 20)
                    {
                        Thread.Sleep(30);
                        if (!isRun) return;
                        CreateGraphics().DrawEllipse(Pens.White, x, 120, z, 300);
                    }
                }
            });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            isRun = !isRun;

            ThreadPool.QueueUserWorkItem(delegate
            {
                float s1 = 0, s2 = 90, s3 = 180, s4 = 270;
                while (true)
                {
                    Thread.Sleep(3);
                    CreateGraphics().Clear(BackColor);
                    if (!isRun) return;
                    CreateGraphics().DrawPie(Pens.Red, 400, 120, 300, 300, s1 += 6, 30);
                    CreateGraphics().DrawPie(Pens.Red, 400, 120, 300, 300, s2 += 6, 30);
                    CreateGraphics().DrawPie(Pens.Red, 400, 120, 300, 300, s3 += 6, 30);
                    CreateGraphics().DrawPie(Pens.Red, 400, 120, 300, 300, s4 += 6, 30);
                }
            });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            isRun = !isRun;

            ThreadPool.QueueUserWorkItem(delegate
            {
                while (true)
                {
                    Thread.Sleep(30);
                    CreateGraphics().Clear(BackColor);
                    if (!isRun) return;
                    Point[] points =
                    {
                        new Point(400, Random.Shared.Next(110, 130)),
                        new Point(Random.Shared.Next(540, 560), 270),
                        new Point(400, Random.Shared.Next(420, 440)),
                        new Point(Random.Shared.Next(240, 260), 270),
                    };
                    CreateGraphics().DrawPolygon(Pens.Red, points);
                }
            });
        }

        private void button7_Click(object sender, EventArgs e)
        {
            isRun = !isRun;

            ThreadPool.QueueUserWorkItem(delegate
            {
                int i1 = 0, i2 = 751;
                bool isStart1 = true, isStart2 = true;
                Font f = new Font("Cooper", 23);
                while (true)
                {
                    Thread.Sleep(100);
                    CreateGraphics().Clear(BackColor);
                    if (!isRun) return;
                    CreateGraphics().DrawRectangle(Pens.Navy, 250, 250, 501, 50);
                    CreateGraphics().FillRectangle(Brushes.LightBlue, 251, 251, 500, 49);

                    if (i1 >= 250) isStart1 = false; else if (i1 <= 0) isStart1 = true;
                    CreateGraphics().FillRectangle(Brushes.Blue, 251, 251, isStart1 ? i1 : i1, 49);
                    if (i2 <= 500) isStart2 = false; else if (i2 >= 751) isStart2 = true;
                    if (isStart2)
                        CreateGraphics().FillRectangle(Brushes.Blue, i2 -= 5, 251, i1 += 5, 49);
                    else
                        CreateGraphics().FillRectangle(Brushes.Blue, i2 += 5, 251, i1 -= 5, 49);

                    CreateGraphics().DrawString(Math.Round(i1 / 2.55d).ToString(), f, Brushes.White, 477, 260);
                }
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = false;
        }
    }
}