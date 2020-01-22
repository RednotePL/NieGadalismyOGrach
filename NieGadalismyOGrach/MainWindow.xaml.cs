using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NieGadalismyOGrach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Sets Cursor Position using X,Y
        /// </summary>
        /// <param name="X">X Cord</param>
        /// <param name="Y">Y Cord</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// get Current Mouse POINT Object
        /// </summary>
        /// <param name="lpPoint">returned Object</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// Move cursor by X,Y pixels
        /// </summary>
        /// <param name="X">-left, +right</param>
        /// <param name="Y">-down, +up</param>
        private static void SetRelativeCursorPos(int X, int Y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            SetCursorPos(p.X - X, p.Y - Y);
        }

        /// <summary>
        /// Move cursor in X axis
        /// </summary>
        /// <param name="X">-left, +right</param>
        private static void SetRelativeCursorPosX(int X)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            SetCursorPos(p.X - X, p.Y);
        }

        /// <summary>
        /// Move cursor in Y axis
        /// </summary>
        /// <param name="Y">-down, +up</param>
        private static void SetRelativeCursorPosY(int Y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            SetCursorPos(p.X, p.Y - Y);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Butt1_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(task1);
        }

        public async Task task1()
        {
            while (true)
            {
                POINT p = new POINT();
                GetCursorPos(out p);
                this.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        Point[] PanicArea = calculateObjectPanicArea(Butt1);
                        Point MousePoint = calculateMousePoint();
                        Point[] WindowArea = new Point[] { new Point(0, 0), new Point(this.ActualWidth, this.Height - 30) };
                        if (isMouseInBound(PanicArea, MousePoint) && isMouseInBound(WindowArea, MousePoint))
                        {
                            if (MousePoint.X >= PanicArea[0].X && MousePoint.X <= Butt1.Margin.Left)
                            {
                                ControlMove(Butt1, new Thickness(Butt1.Margin.Left + new Random().Next(0, 10), Butt1.Margin.Top, 0, 0));
                            }
                            else if (MousePoint.X <= PanicArea[1].X && MousePoint.X >= Butt1.Margin.Left + Butt1.Width)
                            {
                                ControlMove(Butt1, new Thickness(Butt1.Margin.Left - new Random().Next(0, 10), Butt1.Margin.Top, 0, 0));
                            }
                            if (MousePoint.Y >= PanicArea[0].Y && MousePoint.Y <= Butt1.Margin.Top)
                            {
                                ControlMove(Butt1, new Thickness(Butt1.Margin.Left, Butt1.Margin.Top + new Random().Next(0, 10), 0, 0));
                            }
                            else if (MousePoint.Y <= PanicArea[1].Y && MousePoint.Y >= Butt1.Margin.Top + 30)
                            {
                                ControlMove(Butt1, new Thickness(Butt1.Margin.Left, Butt1.Margin.Top - new Random().Next(0, 10), 0, 0));
                            }
                        }
                    }));
                await Task.Delay(1);
            }
        }

        public void ControlMove(Control con, Thickness margin)
        {
            Thickness margin_new = new Thickness();
            if (margin.Left > 0)
            {
                if (margin.Left + con.Width * 2 + 4 <= this.ActualWidth)
                {
                    margin_new.Left = margin.Left;
                }
                else
                {
                    margin_new.Left = this.ActualWidth - con.Width * 2 + 4;
                }
            }
            else
            {
                margin_new.Left = 0;
            }
            if (margin.Top > 0)
            {
                if (margin.Top < this.ActualHeight - 60)
                {
                    margin_new.Top = margin.Top;
                }
                else
                {
                    margin_new.Top = this.ActualHeight - 60;
                }
            }
            else
            {
                margin_new.Top = 0;
            }
            con.Margin = margin_new;
        }

        public Point[] calculateObjectPanicArea(Control con)
        {
            return new Point[] { new Point(con.Margin.Left - 20, con.Margin.Top - 20), new Point(con.Margin.Left + con.Width + 20, con.Margin.Top + 50) };
        }

        public bool isMouseInBound(Point[] Bound, Point Mouse)
        {
            if (Mouse.X >= Bound[0].X && Mouse.X <= Bound[1].X && Mouse.Y >= Bound[0].Y && Mouse.Y <= Bound[1].Y) return true;
            else return false;
        }

        public Point calculateMousePoint()
        {
            POINT p = new POINT();
            GetCursorPos(out p);

            return new Point(p.X - this.Left - 8, p.Y - this.Top - 31);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CounterDecrease cd = new CounterDecrease();
            cd.Show();
        }
    }

    /// <summary>
    /// Struct for POINT c++ Class
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;

        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static implicit operator Point(POINT p)
        {
            return new Point(p.X, p.Y);
        }

        public static implicit operator POINT(Point p)
        {
            return new POINT((int)p.X, (int)p.Y);
        }
    }
}
