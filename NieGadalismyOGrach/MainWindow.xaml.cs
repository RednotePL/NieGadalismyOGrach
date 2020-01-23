using System;
using System.Collections.Generic;
using System.Globalization;
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
using FunctionLibrary;

namespace NieGadalismyOGrach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager gameManager;

        public MainWindow()
        {
            InitializeComponent();
            Task.Run(BlinkText);

            gameManager = new GameManager();

            gameManager.EnqueueLevel(new CounterDecrease());
            gameManager.EnqueueLevel(new PickColor());
            gameManager.EnqueueLevel(new CatchTheButton());
        }

        //TODO: REMOVE
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CounterDecrease cd = new CounterDecrease();
            cd.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PickColor pc = new PickColor();
            pc.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            gameManager.ClearAllLevels();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            gameManager.StartGame();
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CatchTheButton ctb = new CatchTheButton();
            ctb.OnStageStart();
            ctb.Show();
        }

        private async Task BlinkText()
        {
            while (true)
            {
                Title.Dispatcher.Invoke(new Action(() =>
                {
                    Title.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }));
                await Task.Delay(TimeSpan.FromSeconds(1));
                Title.Dispatcher.Invoke(new Action(() =>
                {
                    Title.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                }));
                await Task.Delay(TimeSpan.FromSeconds(1));
                Title.Dispatcher.Invoke(new Action(() =>
                {
                    Title.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                }));
                await Task.Delay(TimeSpan.FromSeconds(1));
                Title.Dispatcher.Invoke(new Action(() =>
                {
                    Title.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }));
                await Task.Delay(TimeSpan.FromSeconds(1));

            }
        }
    }
}
