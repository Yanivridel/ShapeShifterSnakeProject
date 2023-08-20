using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Figures
{
    [Serializable]
    public abstract class Figure
    {
        int x, y;
        public Color clr;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Color Clr
        {
            get
            {
                return clr;
            }
            set
            {
                clr = value;
            }
        }

        public abstract void Draw(Graphics g,int i);
        public abstract bool IsInside(int xVal,int yVal);
    }
    [Serializable]
    public class mySquare : Figure
    {
        protected int width;
        public mySquare() : this(Color.Yellow, 190, 190, 20) { }
        public mySquare(Color clrVal, int xVal = 190, int yVal = 190, int widthVal = 20)
        {
            X = xVal;
            Y = yVal;
            width = widthVal;
            clr = clrVal;
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public override void Draw(Graphics g, int i)
        {
            SolidBrush br = new SolidBrush(clr);
            g.FillRectangle(br, X - (width / 2), Y - (width / 2), width, width);
            if (i == 0)
            {
                Pen pen = new Pen(Color.DarkCyan, 2);
                g.DrawRectangle(pen, X - (width / 2), Y - (width / 2), width, width);
            }
        }
        public override bool IsInside(int xVal, int yVal)
        {
            if (xVal > X - (width / 2) && xVal < X + (width / 2)
                && yVal > Y - (width / 2) && yVal < Y + (width / 2))
            {
                return true;
            }
            return false;
        }
        ~mySquare() { }
    }
    [Serializable]
    public class myCircle : Figure
    {
        int radius;
        public myCircle() : this(Color.Yellow, 190, 190, 10) { }
        public myCircle(Color clrVal,int xVal = 190, int yVal = 190, int rVal = 10)
        {
            X = xVal;
            Y = yVal;
            radius = rVal;
            clr = clrVal;
        }
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        public override void Draw(Graphics g, int i)
        {
            SolidBrush br = new SolidBrush(clr);
            g.FillEllipse(br, X - radius, Y - radius, 2 * radius, 2 * radius);
            if (i == 0)
            {
                Pen pen = new Pen(Color.DarkCyan, 2);
                g.DrawEllipse(pen, X - radius, Y - radius, 2 * radius, 2 * radius);
            }
        }
        public override bool IsInside(int xVal, int yVal)
        {
            double disx = Math.Abs(X - xVal); disx *= disx;
            double disy = Math.Abs(Y - yVal); disy *= disy;
            double dis = Math.Sqrt(disx + disy);
            if (dis < 10)
            {
                return true;
            }
            return false;
        }
        ~myCircle() { }
    }
    [Serializable]
    public class myTriangle : Figure
    {
        int side;
        public myTriangle() : this(Color.Yellow, 190, 190, 20) { }
        public myTriangle(Color clrVal, int xVal = 190, int yVal = 190, int sideVal = 20)
        {
            X = xVal;
            Y = yVal;
            side = sideVal;
            clr = clrVal;
        }
        public int Side
        {
            get
            {
                return side;
            }
            set
            {
                side = value;
            }
        }

        public override void Draw(Graphics g, int i)
        {
            SolidBrush br = new SolidBrush(clr);
            Point p1 = new Point(X - (side / 2), Y + (side / 2));
            Point p2 = new Point(X + (side / 2), Y + (side / 2));
            Point p3 = new Point(X, Y - (side / 2));
            Point[] arr = { p1, p2, p3 };
            g.FillPolygon(br, arr);
            if (i == 0)
            {
                Pen pen = new Pen(Color.DarkCyan, 2);
                g.DrawPolygon(pen, arr);
            }

        }
        public override bool IsInside(int xVal, int yVal)
        {
            Point p1 = new Point(X - (side / 2), Y + (side / 2));
            Point p2 = new Point(X + (side / 2), Y + (side / 2));
            Point p3 = new Point(X, Y - (side / 2));
            double A = area(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
            double A1 = area(xVal, yVal, p2.X, p2.Y, p3.X, p3.Y);
            double A2 = area(p1.X, p1.Y, xVal, yVal, p3.X, p3.Y);
            double A3 = area(p1.X, p1.Y, p2.X, p2.Y, xVal, yVal);
            return (A == A1 + A2 + A3);
        }
        static double area(int x1, int y1, int x2,
                       int y2, int x3, int y3)
        {
            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }

        ~myTriangle() { }
    }
    [Serializable]
    public class myRectangle : mySquare
    {
        protected int height;
        public myRectangle() : this(Color.Yellow, 190, 190, 10,20) { }
        public myRectangle(Color clrVal, int xVal = 190, int yVal = 190, int widthVal = 10, int heightVal = 20)
        {
            X = xVal;
            Y = yVal;
            width = widthVal;
            height = heightVal;
            clr = clrVal;
        }

        public int Heigth
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public override void Draw(Graphics g, int i)
        {
            SolidBrush br = new SolidBrush(clr);
            g.FillRectangle(br, X - (width / 2), Y - (height / 2), width, height);
            if (i == 0)
            {
                Pen pen = new Pen(Color.DarkCyan, 2);
                g.DrawRectangle(pen, X - (width / 2), Y - (height / 2), width, height);
            }
        }
        public override bool IsInside(int xVal, int yVal)
        {
            if (xVal > X - (width / 2) && xVal < X + (width / 2)
                && yVal > Y - (height / 2) && yVal < Y + (height / 2))
            {
                return true;
            }
            return false;
        }
        ~myRectangle() { }
    }
    [Serializable]
    public class myRhombus : mySquare
    {
        public myRhombus() : this(Color.Yellow, 190, 190, 20) { }
        public myRhombus(Color clrVal, int xVal = 190, int yVal = 190, int widthVal = 20)
        {
            X = xVal;
            Y = yVal;
            width = widthVal;
            clr = clrVal;
        }

        public override void Draw(Graphics g, int i)
        {
            SolidBrush br = new SolidBrush(clr);
            Point p1 = new Point(X - (width / 2), Y);
            Point p2 = new Point(X + (width / 2), Y);
            Point p3 = new Point(X, Y + (width / 2));
            Point p4 = new Point(X, Y - (width / 2));
            Point[] arr = { p1, p4, p2,p3 };
            g.FillPolygon(br, arr);
            if (i == 0)
            {
                Pen pen = new Pen(Color.DarkCyan, 2);
                g.DrawPolygon(pen, arr);
            }
        }
        public override bool IsInside(int xVal, int yVal)
        {
            Point p1 = new Point(X - (width / 2), Y);
            Point p2 = new Point(X + (width / 2), Y);
            Point p3 = new Point(X, Y + (width / 2));
            Point p4 = new Point(X, Y - (width / 2));

            double A = area(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y);
            double A1 = area(xVal, yVal, p2.X, p2.Y, p3.X, p3.Y);
            double A2 = area(p1.X, p1.Y, xVal, yVal, p3.X, p3.Y);
            double A3 = area(p1.X, p1.Y, p2.X, p2.Y, xVal, yVal);

            double S = area(p1.X, p1.Y, p2.X, p2.Y, p4.X, p4.Y);
            double S1 = area(xVal, yVal, p2.X, p2.Y, p4.X, p4.Y);
            double S2 = area(p1.X, p1.Y, xVal, yVal, p4.X, p4.Y);
            double S3 = area(p1.X, p1.Y, p2.X, p2.Y, xVal, yVal);
            return (A == A1 + A2 + A3 || S== S1 + S2 + S3);
        }
        static double area(int x1, int y1, int x2,
                       int y2, int x3, int y3)
        {
            return Math.Abs((x1 * (y2 - y3) +
                             x2 * (y3 - y1) +
                             x3 * (y1 - y2)) / 2.0);
        }
        ~myRhombus() { }
    }

    [Serializable]
    public class settings
    {
        public int record, score;
        public settings()
        {
            record = 0;
            score = 0;
        }
        public int Record
        {
            get
            {
                return record;
            }
            set
            {
                record = value;
            }
        }
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        ~settings() { }
    }
}
