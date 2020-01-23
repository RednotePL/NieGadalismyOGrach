using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NieGadalismyOGrach
{
    public class Cursor_
    {
        /// <summary>
        /// Sets Cursor Position using X,Y
        /// </summary>
        /// <param name="X">X Cord</param>
        /// <param name="Y">Y Cord</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        /// <summary>
        /// get Current Mouse POINT Object
        /// </summary>
        /// <param name="lpPoint">returned Object</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        /// <summary>
        /// Move cursor by X,Y pixels
        /// </summary>
        /// <param name="X">-left, +right</param>
        /// <param name="Y">-down, +up</param>
        public static void SetRelativeCursorPos(int X, int Y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            SetCursorPos(p.X - X, p.Y - Y);
        }

        /// <summary>
        /// Move cursor in X axis
        /// </summary>
        /// <param name="X">-left, +right</param>
        public static void SetRelativeCursorPosX(int X)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            SetCursorPos(p.X - X, p.Y);
        }

        /// <summary>
        /// Move cursor in Y axis
        /// </summary>
        /// <param name="Y">-down, +up</param>
        public static void SetRelativeCursorPosY(int Y)
        {
            POINT p = new POINT();
            GetCursorPos(out p);
            SetCursorPos(p.X, p.Y - Y);
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


