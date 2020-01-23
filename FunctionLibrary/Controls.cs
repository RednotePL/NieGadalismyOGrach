using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FunctionLibrary
{
    public class Controls
    {
    /// <summary>
    /// Move Control in window by setting margin
    /// </summary>
    /// <param name="con">WPF Control</param>
    /// <param name="margin">New Margin</param>
    /// <param name="window">Target Window</param>
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
        /// <summary>
        /// Calculate area where Control have triggered escaping function.
        /// </summary>
        /// <param name="con">WPF Control</param>
        /// <returns></returns>
        public static Point[] calculateObjectPanicArea(Control con)
        {
            return new Point[] { new Point(con.Margin.Left - 20, con.Margin.Top - 20), new Point(con.Margin.Left + con.Width + 20, con.Margin.Top + 50) };
        }
    }
}
