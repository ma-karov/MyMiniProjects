using System;
using System.Drawing;
using System.Windows.Forms;

namespace задача_6._1
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent(); 
            x1 = pictureBox2.Width; 
            x2 = pictureBox2.Height; 
            textBox1.Text = "Снимок 1.PNG"; 
            u[0].X = 10; 
            u[0].Y = 10; 
            u[1].X = x1 - 30; 
            u[1].Y = 30; 
            u[2].X = x1 - 50; 
            u[2].Y = x2 - 60; 
            u[3].X = 40; 
            u[3].Y = x2 - 30;
            I2 = pictureBox1.Width; 
            J2 = pictureBox1.Height; 
            button2.Enabled = false; //this.MouseMove += new MouseEventHandler(mouse_move); this.MouseUp += new MouseEventHandler(mouse_click); this.MouseDown += new MouseEventHandler(mouse_down); 
            g1 = pictureBox1.CreateGraphics(); 
            g2 = pictureBox2.CreateGraphics(); 
            pen = new Pen(Color.Red, 2);
        }

        Graphics g1, g2; 
        Pen pen; 
        Bitmap bitmap; 
        Point[] u = new Point[4]; 
        String s;
        Int32 lx = 0, ly = 0, I2, J2, x1, x2; 
        Int16 num = -1, k; 
        Double A1, B1, C1, D1, A2, B2, C2, D2;

        private void button1_Click(Object sender, EventArgs e) 
        {
            s = textBox1.Text; 
            try { 
                pictureBox1.Load(s); 
                button2.Enabled = true; 
                pictureBox1.Width = pictureBox2.Width = x1; 
                pictureBox1.Height = pictureBox2.Height = x2; 
                pictureBox2.Image = null; 
            }
            catch
            {
                MessageBox.Show("указан неверный путь\nпопробуйте ввести еще раз "); 
                pictureBox1.Width = pictureBox2.Width = pictureBox1.Height = pictureBox2.Height = 50; 
                button2.Enabled = false; 
                g1.Clear(Color.RosyBrown); 
                g2.Clear(Color.LightSteelBlue);
                
                g1.DrawLine(pen, 0, 0, pictureBox1.Width - 2, 0); 
                g1.DrawLine(pen, 0, 0, 0, pictureBox1.Height - 2);
                g1.DrawLine(pen, pictureBox1.Width - 2, 0, pictureBox1.Width - 2, pictureBox1.Height - 2);
                g1.DrawLine(pen, 0, pictureBox1.Height - 2, pictureBox1.Width - 2, pictureBox1.Height - 2);
                
                g2.DrawLine(pen, 0, 0, pictureBox1.Width - 2, 0); 
                g2.DrawLine(pen, 0, 0, 0, pictureBox1.Height - 2);
                g2.DrawLine(pen, pictureBox1.Width - 2, 0, pictureBox1.Width - 2, pictureBox1.Height - 2);
                g2.DrawLine(pen, 0, pictureBox1.Height - 2, pictureBox1.Width - 2, pictureBox1.Height - 2);
            }
        }

        private void button2_Click(Object sender, EventArgs e) 
        {
            Bitmap Bit1 = new Bitmap(s), Bit2 = new Bitmap(s);
            for (Int16 i1 = 0; i1 < Bit2.Width; i1++)
                for (Int16 i2 = 0; i2 < Bit2.Height; i2++) 
                    Bit2.SetPixel(i1, i2, Color.LightSteelBlue);//pen.DashStyle = DashStyle.Solid;
            
            pen.Width = 2; 
            pen.Color = Color.Red; 
            g2.DrawRectangle(pen, 1, 1, pictureBox2.Width - 2, pictureBox2.Height - 2); 
            I2 = Bit1.Width; J2 = Bit1.Height;
            D1 = u[0].X; D2 = u[0].Y; 
            Double a1_x = u[1].X, a1_y = u[1].Y, a2_x = u[2].X, a2_y = u[2].Y, a3_x = u[3].X, a3_y = u[3].Y,
            A1 = (Double)(a1_x - D1) / I2; A2 = (Double)(a1_y - D2) / I2; C1 = (Double)(a3_x - D1) / J2; C2 = (Double)(a3_y - D2) / J2;
            B1 = (Double)(a2_x - a3_x - a1_x + D1) / I2 / J2; B2 = (Double)(a2_y - a3_y - a1_y + D2) / I2 / J2;
            
            for (Int16 i1 = 0; i1 < I2; i1++)
                for (Int16 i2 = 0; i2 < J2; i2++)
                {
                    Int16 t1 = (Int16)(A1 * i1 + B1 * i1 * i2 + C1 * i2 + D1), t2 = (Int16)(A2 * i1 + B2 * i1 * i2 + C2 * i2 + D2); //Int16 i = Convert.ToInt16(t1), j = Convert.ToInt16(t2); 
                    Bit2.SetPixel(t1, t2, Bit1.GetPixel(i1, i2));
                }
            g2.DrawImage(Bit2, 0, 0);// Pen1.DashStyle = DashStyle.Solid;
            pen.Width = 2; pen.Color = Color.Red; g2.DrawRectangle(pen, 1, 1, pictureBox2.Width - 2, pictureBox2.Height - 2);// Pen1.DashStyle = DashStyle.Dot;
            pen.Width = 2; pen.Color = Color.Black; g2.DrawPolygon(pen, u);
        }

        Boolean check(Single x1, Single y1, Single x2, Single y2) => ( Math.Abs(Math.Abs(x1) - Math.Abs(x2)) < 3 && Math.Abs(Math.Abs(y1) - Math.Abs(y2)) < 3 ); 

        private void mouse_click(Object sender, MouseEventArgs e) 
        { 
            if (num != -1) 
            { 
                num = -1; 
                button2_Click(sender, e); 
            } 
        }

        private void mouse_move(Object sender, MouseEventArgs e) 
        {
            if (num != -1 && k > -1)
            {
                u[k].X = e.X; u[k].Y = e.Y; 
                g2.Clear(Color.LightSteelBlue);
                pen.Width = 2; 
                pen.Color = Color.Black; 
                g2.DrawPolygon(pen, u);
            }
        }

        private void mouse_down(Object sender, MouseEventArgs e) 
        {
            lx = e.X; ly = e.Y;
            for (Byte i = 0; i < 4 && num == -1; i++) 
                if (check(lx, ly, u[i].X, u[i].Y)) 
                { 
                    num = 1; 
                    k = i; 
                }
        }
    }
}
