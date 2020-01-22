using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace FunctionLibrary
{
    public static class MousePointer
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

        public static void ControlMove(Control con, Thickness margin, Window window)
        {
            Thickness margin_new = new Thickness();
            if (margin.Left > 0)
            {
                if (margin.Left + con.Width * 2 + 4 <= window.ActualWidth)
                {
                    margin_new.Left = margin.Left;
                }
                else
                {
                    margin_new.Left = window.ActualWidth - con.Width * 2 + 4;
                }
            }
            else
            {
                margin_new.Left = 0;
            }
            if (margin.Top > 0)
            {
                if (margin.Top < window.ActualHeight - 60)
                {
                    margin_new.Top = margin.Top;
                }
                else
                {
                    margin_new.Top = window.ActualHeight - 60;
                }
            }
            else
            {
                margin_new.Top = 0;
            }
            con.Margin = margin_new;
        }

        public static Point[] calculateObjectPanicArea(Control con)
        {
            return new Point[] { new Point(con.Margin.Left - 20, con.Margin.Top - 20), new Point(con.Margin.Left + con.Width + 20, con.Margin.Top + 50) };
        }

        public static bool isMouseInBound(Point[] Bound, Point Mouse)
        {
            if (Mouse.X >= Bound[0].X && Mouse.X <= Bound[1].X && Mouse.Y >= Bound[0].Y && Mouse.Y <= Bound[1].Y) return true;
            else return false;
        }

        public static Point calculateMousePoint(this Window window)
        {
            POINT p = new POINT();
            GetCursorPos(out p);

            return new Point(p.X - window.Left - 8, p.Y - window.Top - 31);
        }

        public static async Task task1(this Window window, Control control)
        {
            while (true)
            {
                POINT p = new POINT();
                GetCursorPos(out p);
                window.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        Point[] PanicArea = calculateObjectPanicArea(control);
                        Point MousePoint = calculateMousePoint(window);
                        Point[] WindowArea = new Point[] { new Point(0, 0), new Point(window.ActualWidth, window.Height - 30) };
                        if (isMouseInBound(PanicArea, MousePoint) && isMouseInBound(WindowArea, MousePoint))
                        {
                            if (MousePoint.X >= PanicArea[0].X && MousePoint.X <= control.Margin.Left)
                            {
                                ControlMove(control, new Thickness(control.Margin.Left + new Random().Next(0, 10), control.Margin.Top, 0, 0), window);
                            }
                            else if (MousePoint.X <= PanicArea[1].X && MousePoint.X >= control.Margin.Left + control.Width)
                            {
                                ControlMove(control, new Thickness(control.Margin.Left - new Random().Next(0, 10), control.Margin.Top, 0, 0), window);
                            }
                            if (MousePoint.Y >= PanicArea[0].Y && MousePoint.Y <= control.Margin.Top)
                            {
                                ControlMove(control, new Thickness(control.Margin.Left, control.Margin.Top + new Random().Next(0, 10), 0, 0), window);
                            }
                            else if (MousePoint.Y <= PanicArea[1].Y && MousePoint.Y >= control.Margin.Top + 30)
                            {
                                ControlMove(control, new Thickness(control.Margin.Left, control.Margin.Top - new Random().Next(0, 10), 0, 0), window);
                            }
                        }
                    }));
                await Task.Delay(1);
            }
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
