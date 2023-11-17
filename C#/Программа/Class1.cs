using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        private Int16 WidthForm, HeightForm, MinX = -4, MaxX = 6, MinY = -5, MaxY = 8; 
        private Byte Count_Array_Data = 0; 
        private Int16[][] Array_Data; 
        private const Byte PaddingWidth = 3, PaddingHeight = 3, LenRow = 3; 
        private Boolean Permission_Change_ArrayData = true; 
        private Pen Pen_Main = new Pen(Color.Black); 
        private Graphics Graphic; 
        private SolidBrush Brush_Main = new SolidBrush(Color.FromArgb(60, 110, 160));
       
        public Form1() 
        { 
            InitializeComponent(); 
            Fill_Form_Default(); 
        }

        private void Fill_Form_Default() 
        {
            WidthForm = (Int16)(Graphic1.Size.Width - PaddingWidth); 
            HeightForm = (Int16)(Graphic1.Size.Height - PaddingHeight);
            //TextArea_OurData.Text = "40 37 39 42 40 39 38 40 41 36 41 41 40 39 41 40 37 43 40 39 39 38 40 37 40 38 42 41 40 42 41 40 38 39 41 40 41 41 39 37"; 
            TextArea_OurData.Text = "54 66 62 50 55 85 85 73 73 53 67 64 77 47 75 61 50 73 71 46 76 51 75 76 54 61 68 69 72 55 66 66 67 68 70 68 87 62 89 66 70 68 55 76 82 87 82 59 78 86 71 43 72 74 68 69 60 66 84 72 79 71 87 65 74 90 79 60 65 75 60 59 67 77 79 56 74 81 78 80 76 77 49 51 66 54 72 62 51 89 74 60 67 75 71 63 63 80 93 86";
        }

        private Boolean Distinct_ArrayElements(Int16[] Array, UInt16 Count, Int16 Value) 
        { 
            for (UInt16 i = 0; i < Count; i++) 
                if (Array[i] == Value) 
                    return false; 
            return true; 
        }

        private Int16[] Sort_Array(Int16[] Array, Byte Count) 
        {
            for (Byte i1 = 0; i1 < Count - 1; i1++)
                for (Byte i2 = (Byte)(Count - 1); i2 > i1; i2--) 
                { 
                    Int16 Value1 = Array[i2 - 1], Value2 = Array[i2]; 
                    if (Value1 > Value2) 
                    { 
                        Array[i2 - 1] = Value2; 
                        Array[i2] = Value1; 
                    } 
                }

            return Array;
        }

        private void Cout_Array(Int16[][] Array) 
        {
            foreach (Int16[] SubArray in Array)
            {
                String New_String = "";
                foreach (Int16 Value in SubArray) 
                    New_String += Value + " "; 
                TextArea_OurData.Text += "\n\n" + New_String;
            }
        }

        private void Cout_Array(Int16[] Array) 
        {
            String New_String = "";
            foreach (Int16 Value in Array) 
                New_String += Value + " "; 
            TextArea_OurData.Text += "\n\n" + New_String;
        }

        private void Cin_Table() 
        {
            for (Byte i = 0; i < Count_Array_Data;) 
                TableData.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = Array_Data[0][i++] + "" }); 
            
            DataGridViewRow Row;
            for (Byte i1 = 1; i1 < LenRow; i1++)
            {
                Row = new DataGridViewRow();
                for (Byte i2 = 0; i2 < Count_Array_Data;) 
                    Row.Cells.Add(new DataGridViewTextBoxCell() { Value = Array_Data[i1][i2++] + "" }); 
                TableData.Rows.Add(Row);
            }

            Row = new DataGridViewRow(); 
            Int16 Summa_Cumulative = Array_Data[2][Count_Array_Data - 1];
            for (Byte i = 0; i < Count_Array_Data;) 
                Row.Cells.Add(new DataGridViewTextBoxCell() { Value = 1.0 * Array_Data[1][i++] / Summa_Cumulative + "" }); 
            
            TableData.Rows.Add(Row); 
            Single Step_Interval = (Single)((Array_Data[0][1] - Array_Data[0][0]) / 2.0); 
            Row = new DataGridViewRow();
            for (Byte i = 0; i < Count_Array_Data;) 
            { 
                Int16 Val = Array_Data[0][i++]; 
                Row.Cells.Add(new DataGridViewTextBoxCell() { Value = "[" + (Val - Step_Interval) + "; " + (Val + Step_Interval) + "]" }); 
            }
            TableData.Rows.Add(Row); Row = new DataGridViewRow();
            for (Byte i = 0; i < Count_Array_Data;) 
                Row.Cells.Add(new DataGridViewTextBoxCell() { Value = Array_Data[1][i++] * 0.5 / Step_Interval + "" }); 
            TableData.Rows.Add(Row);

            //TableData.Rows.Add(new DataGridViewRow() { Cells = { new DataGridViewTextBoxCell() { Value = "105" }, new DataGridViewTextBoxCell() { Value = "Job" } } }); 
        }

        private Int16 MaxValue_Array(Int16[] Array) 
        { 
            Int16 MaxValue = Array[0]; 
            for (Byte i = 1; i < Count_Array_Data;) 
            { 
                Int16 Value = Array[i++]; 
                if (Value > MaxValue) 
                    MaxValue = Value; 
            } 
            
            return MaxValue; }

        private Int16 MinValue_Array(Int16[] Array) 
        {
            Int16 MinValue = Array[0]; 
            for (Byte i = 1; i < Count_Array_Data;) 
            { 
                Int16 Value = Array[i++]; 
                if (Value < MinValue) 
                    MinValue = Value; 
            } 
            
            return MinValue; 
        }

        private Byte IndexMaxValue_Array(Int16[] Array, Int16 MaxValue) 
        { 
            Byte Index = 0; 
            foreach (Int16 Value in Array) 
            { 
                if (Value == MaxValue) 
                    break; 
                Index++;     
            } 
            
            return Index; 
        }

        private void Get_DataWithForm() 
        {
            if (Permission_Change_ArrayData)
            {
                String String_OurData = TextArea_OurData.Text + " \0", String_Value = ""; 
                Char CharI = String_OurData[0]; 
                Int16 Count_Array_Row = 0;
                for (UInt16 i = 1; CharI != '\0'; CharI = String_OurData[i++]) 
                    if (CharI == ' ' && String_Value != "") 
                    { 
                        Count_Array_Row++; 
                        String_Value = ""; 
                    } 
                    else 
                        String_Value += CharI; 
                
                CharI = String_OurData[0]; Int16[] Array_Row = new Int16[Count_Array_Row];
                for (UInt16 i = 1, Ind = 0; CharI != '\0'; CharI = String_OurData[i++]) 
                    if (CharI == ' ' && String_Value != "") 
                    { 
                        Int16 Value = Convert.ToInt16(String_Value); 
                        String_Value = ""; 
                        if (Distinct_ArrayElements(Array_Row, Ind, Value)) 
                            Count_Array_Data++; 
                        Array_Row[Ind++] = Value; 
                    } 
                    else 
                        String_Value += CharI; 
                
                Array_Data = new Int16[LenRow][];
                for (Byte i = 0; i < LenRow;) 
                    Array_Data[i++] = new Int16[Count_Array_Data]; 
                
                Array_Data[0][0] = Array_Row[0];
                for (Byte i = 1, Ind = 1; i < Count_Array_Row; i++) 
                { 
                    Int16 Value = Array_Row[i]; 
                    if (Distinct_ArrayElements(Array_Data[0], Ind, Value)) 
                        Array_Data[0][Ind++] = Value; 
                }
                
                Array_Data[0] = Sort_Array(Array_Data[0], Count_Array_Data); 
                Byte Index = 0;
                foreach (Int16 Value in Array_Data[0])
                {
                    Byte RepeatCount = 0;
                    foreach (Int16 Value1 in Array_Row) 
                        if (Value == Value1) 
                            RepeatCount++; 
                    
                    Array_Data[1][Index++] = RepeatCount;
                }

                Index = 0; Int16 CumulativeCount = 0;
                foreach (Int16 Value in Array_Data[1]) 
                { 
                    CumulativeCount += Value; 
                    Array_Data[2][Index++] = CumulativeCount; 
                }

                Cin_Table(); Permission_Change_ArrayData = false;
            }
        }

        private void Check_Range_Graphic() 
        { 
            if (MinY >= 0) 
                MinY = (Int16)((MaxY - MinY > 15) ? -3 : -1); 
            else if (MaxY <= 0) 
                MaxY = 1; 
            
            if (MinX >= 0) 
                MinX = -1; 
            else if (MaxX <= 0) 
                MaxX = 1; 
        }

        private Int16[] Array_Straight(Int16 Y) 
        {
            Byte Index = 0;
            foreach (Int16 Value in Array_Data[2]) 
            { 
                Index++; 
                if (Value > Y) 
                    break; 
            }
            
            return new Int16[4] { Array_Data[0][Index - 1], Array_Data[2][Index - 1], Array_Data[0][Index], Array_Data[2][Index] };
        }

        private Int16 Fx(Int16 X) => (Int16)(PaddingWidth + (WidthForm - PaddingWidth) * (X - MinX) / (MaxX - MinX));
        private Int16 Fy(Int16 Y) => (Int16)(PaddingHeight + (HeightForm - PaddingHeight) * (Y - MaxY) / (MinY - MaxY));

        private void DrawCoordGrid() 
        {
            Check_Range_Graphic(); 
            Graphic.DrawRectangle(Pen_Main, PaddingWidth, PaddingHeight, WidthForm - PaddingWidth, HeightForm - PaddingHeight); 
            Graphic.FillRectangle(Brush_Main, PaddingWidth, PaddingHeight, WidthForm - PaddingWidth, HeightForm - PaddingHeight); 
            Font LocalFont = new Font("Times New Roman", 14); Brush_Main.Color = Color.FromArgb(0, 0, 0);
            for (Int16 i1 = MinX; i1 < MaxX; i1++)
                for (Int16 i2 = MinY; i2 < MaxY;) 
                    Graphic.DrawLine(Pen_Main, Fx(i1), Fy(i2++), Fx(i1), Fy(i2));
            for (Int16 i1 = MinY; i1 < MaxY; i1++)
                for (Int16 i2 = MinX; i2 < MaxX;) 
                    Graphic.DrawLine(Pen_Main, Fx(i2++), Fy(i1), Fx(i2), Fy(i1)); 
            Pen_Main.Width = 2; 
            Graphic.DrawLine(Pen_Main, Fx(MinX), Fy(0), Fx(MaxX), Fy(0)); 
            Graphic.DrawLine(Pen_Main, Fx(0), Fy(MinY), Fx(0), Fy(MaxY)); 
            Pen_Main.Width = 1; 
            Graphic.DrawString("0", LocalFont, Brush_Main, Fx(0), Fy(0)); 
            Graphic.DrawString("X", LocalFont, Brush_Main, Fx(MaxX) - 20, Fy(0)); 
            Graphic.DrawString("Y", LocalFont, Brush_Main, Fx(0), Fy(MaxY) - 1);
        }

        private void DrawGraphic(SByte Switch) 
        {
            Graphic = Graphic1.CreateGraphics();
            switch (Switch)
            {
                case 0:
                    {
                        MinX = MinValue_Array(Array_Data[0]); MaxX = MaxValue_Array(Array_Data[0]); MinY = MinValue_Array(Array_Data[1]); MaxY = MaxValue_Array(Array_Data[1]); DrawCoordGrid();
                        for (Byte i = 1; i < Count_Array_Data;) Graphic.DrawLine(Pen_Main, Fx(Array_Data[0][i - 1]), Fy(Array_Data[1][i - 1]), Fx(Array_Data[0][i]), Fy(Array_Data[1][i++])); Int16 Mx0 = Array_Data[0][IndexMaxValue_Array(Array_Data[1], MaxY)]; Pen_Main.Width = 2; Graphic.DrawLine(Pen_Main, Fx(Mx0), Fy(0), Fx(Mx0), Fy(MaxY)); Brush_Main.Color = Color.FromArgb(40, 190, 120); Graphic.DrawString(Mx0 + "", new Font("Times New Roman", 14), Brush_Main, Fx(Mx0) - 10, Fy(0) - 5); break;
                    }
                case 1:
                    {
                        Single Step_Interval = (Single)((Array_Data[0][1] - Array_Data[0][0]) / 2.0); MinX = (Int16)(Array_Data[0][0] - Step_Interval); MaxX = (Int16)(Array_Data[0][Count_Array_Data - 1] + Step_Interval); MinY = (Int16)(MinValue_Array(Array_Data[1]) * 0.5 / Step_Interval); MaxY = (Int16)(MaxValue_Array(Array_Data[1]) * 0.5 / Step_Interval); DrawCoordGrid(); Pen_Main.Width = 2; TextArea_OurData.Text += "\n\n" + MinY;
                        for (Byte i = 0; i < Count_Array_Data;) { Int16 Value = Array_Data[0][i]; Graphic.DrawRectangle(Pen_Main, Fx((Int16)(Value - Step_Interval)), Fy((Int16)(Array_Data[1][i] * 0.5 / Step_Interval)), Fx((Int16)(Step_Interval)), Fy(0) - Fy((Int16)(Array_Data[1][i++] * 0.5 / Step_Interval))); }
                        break;
                    }
                case 2:
                    {
                        MinX = MinValue_Array(Array_Data[0]); MaxX = MaxValue_Array(Array_Data[0]); MinY = MinValue_Array(Array_Data[2]); MaxY = MaxValue_Array(Array_Data[2]); DrawCoordGrid();
                        for (Byte i = 1; i < Count_Array_Data;) Graphic.DrawLine(Pen_Main, Fx(Array_Data[0][i - 1]), Fy(Array_Data[2][i - 1]), Fx(Array_Data[0][i]), Fy(Array_Data[2][i++])); Int16[] Array_StraightXY = Array_Straight((Int16)(MaxY / 2.0));
                        Int16 Mx0 = (Int16)(Array_StraightXY[0] + (MaxY / 2.0 - Array_StraightXY[1]) * (Array_StraightXY[2] - Array_StraightXY[0]) / (Array_StraightXY[3] - Array_StraightXY[1])); Pen_Main.Width = 2; Graphic.DrawLine(Pen_Main, Fx(0), Fy((Int16)(MaxY / 2.0)), Fx(Mx0), Fy((Int16)(MaxY / 2.0))); Graphic.DrawLine(Pen_Main, Fx(Mx0), Fy(0), Fx(Mx0), Fy((Int16)(MaxY / 2.0))); Brush_Main.Color = Color.FromArgb(40, 190, 120); Graphic.DrawString(Mx0 + "", new Font("Times New Roman", 14), Brush_Main, Fx(Mx0) - 10, Fy(0) - 5); break;
                    }
                case 3:
                    {
                        MinX = MinValue_Array(Array_Data[2]); MaxX = MaxValue_Array(Array_Data[2]); MinY = MinValue_Array(Array_Data[0]); MaxY = MaxValue_Array(Array_Data[0]); DrawCoordGrid();
                        for (Byte i = 1; i < Count_Array_Data;) Graphic.DrawLine(Pen_Main, Fx(Array_Data[2][i - 1]), Fy(Array_Data[0][i - 1]), Fx(Array_Data[2][i]), Fy(Array_Data[0][i++])); break;
                    }
                case 4:
                    {
                        MinX = Array_Data[0][0]; MaxX = Array_Data[0][Count_Array_Data - 1]; MinY = 0; MaxY = 100; Int16 CumulativeCount = Array_Data[2][Count_Array_Data - 1]; DrawCoordGrid(); Pen_Main.Width = 2;
                        for (Byte i = 2; i < Count_Array_Data;) { Int16 ValueFy = Fy((Int16)(Array_Data[2][i] * 100 / CumulativeCount)); Graphic.DrawLine(Pen_Main, Fx((Int16)(Array_Data[0][i - 1] * 100 / CumulativeCount)), ValueFy, Fx((Int16)(Array_Data[0][i++] * 100 / CumulativeCount)), ValueFy); }
                        Pen_Main.Width = 1; break;
                    }

                default: { MessageBox.Show("Вы не выбрали вид графика"); break; }
            }

            Pen_Main.Width = 1; Brush_Main.Color = Color.FromArgb(60, 110, 160);

            //        for (Byte i = 1; i < Count_Array_Data;) Graphic.DrawLine(Pen_Main, Fx(Array_Data[0][i - 1]), Fy(Array_Data[Switch][i - 1]), Fx(Array_Data[0][i]), Fy(Array_Data[Switch][i++])); 

        }

        private void Button_Click_SolveTask1(object sender, EventArgs e) 
        { 
            Get_DataWithForm(); 
            DrawGraphic((SByte) Select_Graphic.SelectedIndex); 
        }

        private void TextArea_OurData_Leave(object sender, EventArgs e) 
        { 
            Permission_Change_ArrayData = true; 
            Array_Data = new Int16[0][]; 
        }


    }
}
