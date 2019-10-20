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
            POINT p = new POINT();
            GetCursorPos(out p);
            Task.Run(task1);
        }

        public async Task task1()
        {
            for (int i = 0; i <= 2000; i++)
            {
                await Task.Delay(5);
                SetRelativeCursorPosY(-1);
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