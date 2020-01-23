using FunctionLibrary;
using NieGadalismyOGrach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NieGadalismyOGrach
{
    /// <summary>
    /// Interaction logic for CatchTheButton.xaml
    /// </summary>
    public partial class CatchTheButton : Window, IGameStage
    {
        private bool startRunning = false;
        private bool clickedRight = false;

        public CatchTheButton()
        {
            InitializeComponent();
            currentTask.Content = Properties.Resources.ClickButtonRight;
        }

        public string StageName => "Click the button";

        public Action OnStageWin { get; set; }

        public Action OnStageLose { get; set; }

        public void OnStageEnd()
        {
            StaButt.Visibility = Visibility.Visible;
        }

        public void OnStageStart()
        {
            StaButt.Visibility = Visibility.Visible;
        }

        private void Butt1_Click(object sender, RoutedEventArgs e)
        {
            if (startRunning)
            {
                OnStageWin?.Invoke();
            }
            else
            {
                clickedRight = true;
                currentTask.Content = Properties.Resources.ClickButtonLeft;
            }
        }

        private void StaButt_Click(object sender, RoutedEventArgs e)
        {
            if (clickedRight)
            {
                currentTask.Content = Properties.Resources.ClickButtonRight;
                Task.Run(() => MousePointer.EscapeButtonTask(this, Butt1));
                startRunning = true;
            }
        }
    }
}
