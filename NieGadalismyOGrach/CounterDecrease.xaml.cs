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
    /// Interaction logic for CounterDecrease.xaml
    /// </summary>
    public partial class CounterDecrease : Window, IGameStage
    {
        private int counter = 50;

        private Random rng = new Random();

        public CounterDecrease()
        {
            InitializeComponent();
        }

        public string StageName { get => "Decrease the counter"; }

        public Action OnStageWin { get; set; }

        public Action OnStageLose { get; set; }

        public void OnStageEnd()
        {
        }

        public void OnStageStart()
        {
            counter = 50;
            this.Btn1.Content = counter.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int decreaseAmount = 1;
            if (counter < 10)
            {
                decreaseAmount = rng.Next(1, 3);
            }

            counter -= decreaseAmount;
            this.Btn1.Content = counter.ToString();

            System.Diagnostics.Debug.WriteLine(counter);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (counter == 0)
            {
                MessageBox.Show(Properties.Resources.Stage_Cleared);
                OnStageWin?.Invoke();
            }

            if (counter < 0)
            {
                MessageBox.Show(Properties.Resources.U_Bad);
                OnStageLose?.Invoke();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OnStageStart();
        }
    }
}
