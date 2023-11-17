using System;
using System.Drawing;
using System.Windows.Forms;

namespace задача_4 { public partial class Form1 : Form { public Form1() { InitializeComponent(); I1 = 3; J1 = 3; I2 = (Int16)(pictureBox1.Width - 3); J2 = (Int16)(pictureBox1.Height - 3); } Double x1, y1, x2, y2, x, y, y3, h; Int16 I1 = 3, J1 = 3, I2, J2, n = 200;
void button1_Click(object sender, EventArgs e) { for (x1 = -2.8, x2 = 3.1, h = (x2 - x1)/n, x = x1, y = y1 = y2 = FFFF(x); x <= x2; x += h, y = FFFF(x)) { if (y > y1) y1 = y; else if (y < y2) y2 = y; y = F(x); if (y > y1) y1 = y; else if (y < y2) y2 = y; y = FF(x); if (y > y1) y1 = y; else if (y < y2) y2 = y; y = FFF(x); if (y > y1) y1 = y; else if (y < y2) y2 = y; } DrawGraphic1(); }
void button2_Click(object sender, EventArgs e) { for (x1 = -1, x2 = 4, h = (x2 - x1) / n, x = x1, y = y1 = y2 = f(x); x <= x2; x += h, y = f(x)) if (y > y1) y1 = y; else if (y < y2) y2 = y; DrawGraphic2(); }

int x_screen(double x) { return I1 + (int)((x - x1)*(I2 - I1)/(x2 - x1)); }
int y_screen(double y) { return J1 - (int)((y - y1)*(J2 - J1)/(y1 - y2)); }
Single F(double x) { return (Single)(1.2*Math.Sin(x*x)*Math.Exp(x/5)); }
Single FF(double x) { return (Single)(1.2* Math.Sin(x*x)); }
Single FFF(double x) { return (Single)(2.25*Math.Sin(x*x) * Math.Exp(x/3)); }
Single FFFF(double x) { return (Single)(0.25*Math.Sin(x*x)*Math.Exp(x/7)); }
Single f(double x) { return (Single)((x - 3)/(x*x + 2)); }

void DrawGraphic1() { Graphics graphics = pictureBox1.CreateGraphics(); graphics.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
graphics.FillRectangle(Brushes.MintCream, 1, 1, pictureBox1.Width - 3, pictureBox1.Height - 3); Pen pen = new Pen(Color.Red, 1.5f); int i;  //pen.DashStyle = DashStyle.Solid;
for (x = x1, y = F(x), i = 1; i < n; i++) { x += h; y3 = F(x);  graphics.DrawLine(pen, x_screen(x), y_screen(y), x_screen(x), y_screen(y3)); y = y3; }  pen.Color = Color.Blue;  //pen.DashStyle = DashStyle.Solid;
for (x = x1, y = FF(x), i = 1; i < n; i++) { x += h; y3 = FF(x); graphics.DrawLine(pen, x_screen(x), y_screen(y), x_screen(x), y_screen(y3)); y = y3; } pen.Color = Color.Green;  //pen.DashStyle = DashStyle.Solid;
for (x = x1, y = FFF(x), i = 1; i < n; i++) { x += h; y3 = FFF(x); graphics.DrawLine(pen, x_screen(x), y_screen(y), x_screen(x), y_screen(y3)); y = y3; } pen.Color = Color.Orange;  
for (x = x1, y = FFFF(x), i = 1; i < n; i++) { x += h; y3 = FFFF(x); graphics.DrawLine(pen, x_screen(x), y_screen(y), x_screen(x), y_screen(y3)); y = y3; } pen.Color = Color.Black; //textBox1.Text = pictureBox1.Width.ToString(); textBox2.Text = pictureBox1.Height.ToString();
for (i = (Int32)y2; i < y1; i++) { graphics.DrawLine(pen, x_screen(i), y_screen(y2), x_screen(i), y_screen(y1)); graphics.DrawLine(pen, x_screen(x1), y_screen(i), x_screen(x2), y_screen(i)); } pen.Color = Color.Brown;
graphics.DrawLine(pen, x_screen(0), y_screen(y1), x_screen(0), y_screen(y2)); graphics.DrawLine(pen, x_screen(x1), y_screen(0), x_screen(x2), y_screen(0));
graphics.DrawString("0", SystemFonts.DefaultFont, new SolidBrush(Color.Black), x_screen(0) + 3, y_screen(0) - 15);
graphics.DrawString("Y", SystemFonts.DefaultFont, new SolidBrush(Color.Black), x_screen(0) - 15, y_screen(y1) + 3);
graphics.DrawString("X", SystemFonts.DefaultFont, new SolidBrush(Color.Black), x_screen(x2) - 10, y_screen(0) - 15); } 

void DrawGraphic2() { Graphics graphics = pictureBox1.CreateGraphics(); graphics.FillRectangle(Brushes.Black, 0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1);
graphics.FillRectangle(Brushes.MintCream, 1, 1, pictureBox1.Width - 3, pictureBox1.Height - 3);
Pen pen = new Pen(Color.Red, 1.5f); x = x1; y = f(x);  //pen.DashStyle = DashStyle.Solid;
for (int i = 1; i < n; i++) { x += h; y3 = f(x);  graphics.DrawLine(pen, x_screen(x), y_screen(y), x_screen(x), y_screen(y3)); y = y3; } pen.Color = Color.Black; 
for (Int16 i = (Int16)y2; i < (Int16)y1;) graphics.DrawLine(pen, x_screen(x1), y_screen(i), x_screen(x2), y_screen(i++)); 
for (Int16 i = (Int16)x1; i < (Int16)x2;) graphics.DrawLine(pen, x_screen(i), y_screen(y2), x_screen(i++), y_screen(y1)); pen.Color = Color.Brown; 
graphics.DrawLine(pen, x_screen(0), y_screen(y1), x_screen(0), y_screen(y2)); graphics.DrawLine(pen, x_screen(x1), y_screen(0), x_screen(x2), y_screen(0));
graphics.DrawString("0", SystemFonts.DefaultFont, new SolidBrush(Color.Black), x_screen(0) + 3, y_screen(0) - 15);
graphics.DrawString("Y", SystemFonts.DefaultFont, new SolidBrush(Color.Black), x_screen(0) - 15, y_screen(y1) + 3);
graphics.DrawString("X", SystemFonts.DefaultFont, new SolidBrush(Color.Black), x_screen(x2) - 10, y_screen(0) - 15); } } }