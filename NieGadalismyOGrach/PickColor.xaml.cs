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
using NieGadalismyOGrach.Interfaces;

namespace NieGadalismyOGrach
{
    /// <summary>
    /// Logika interakcji dla klasy PickColorEasy.xaml
    /// </summary>
    public partial class PickColor : Window, IGameStage
    {
        private Random random = new Random();

        private List<KeyValuePair<string, SolidColorBrush>> notRetardedColors = new List<KeyValuePair<string, SolidColorBrush>>
        {
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Red, Brushes.Red),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Yellow, Brushes.Yellow),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Green, Brushes.Green),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Blue, Brushes.Blue),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.White, Brushes.White),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Gray, Brushes.Gray),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Black, Brushes.Black),
        };

        private List<KeyValuePair<string, SolidColorBrush>> mediumDifficultyColors = new List<KeyValuePair<string, SolidColorBrush>>
        {
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Red, Brushes.Red),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Orange, Brushes.Orange),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Yellow, Brushes.Yellow),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Green, Brushes.Green),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Turquoise, Brushes.Turquoise),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Blue, Brushes.Blue),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Purple, Brushes.Purple),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Pink, Brushes.Pink),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Brown, Brushes.Brown),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.White, Brushes.White),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Gray, Brushes.Gray),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Black, Brushes.Black),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Lime, Brushes.Lime),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Cyan, Brushes.Cyan),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Navy, Brushes.Navy),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Gold, Brushes.Gold),
        };

        private List<KeyValuePair<string, SolidColorBrush>> FUColors = new List<KeyValuePair<string, SolidColorBrush>>
        {
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.Pink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC0CB"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.LightPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB6C1"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.HotPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF69B4"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.DeepPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1493"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.ChampagnePink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F1DDCF"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PinkLace, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDF4"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PiggyPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FDDDE6"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PalePink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F9CCCA"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.BabyPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F4C2C2"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.SpanishPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F7BFBE"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.CameoPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#EFBBCC"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.OrchidPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F2BDCD"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.FairyTale, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F2C1D1"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.CherryBlossomPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7C5"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.LightHotPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB3DE"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.LavenderPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBAED2"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.CottonCandy, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFBCD9"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.CarnationPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA6C9"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.BakerMillerPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF91AF"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.TickleMePink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FC89AC"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.AmaranthPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F19CBB"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.CharmPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E68FAC"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.ChinaPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DE6FA1"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.MimiPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDAE9"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.TangoPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E4717A"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.CoralPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F88379"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PastelPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DEA5A4"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.NewYorkPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#D7837F"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.SolidPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#893843"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.SilverPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#C4AEAD"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.QueenPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8CCD7"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PinkLavender, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DBB2D1"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.MountbattenPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#997A8D"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.ChileanPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8C3BA"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PaleDogwood, (SolidColorBrush)(new BrushConverter().ConvertFrom("#EDCDC2"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PinkU, (SolidColorBrush)(new BrushConverter().ConvertFrom("#D74894"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.MexicanPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E4007C"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.BarbiePink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DA1884"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.FandangoPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#DE5285"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.ParadisePink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#E63E62"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.BrinkPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FB607F"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.FrenchPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FD6C9E"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.BrightPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007F"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.PersianPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#F77FBE"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.RosePink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF66CC"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.LightDeepPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF5CCD"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.UltraPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF6FFF"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.ShockingPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#FC0FC0"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.SuperPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#CF6BA9"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.RosePompadour, (SolidColorBrush)(new BrushConverter().ConvertFrom("#ED7A9B"))),
            new KeyValuePair<string, SolidColorBrush>(Properties.Resources.SteelPink, (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC33CC")))
        };

        private List<Button> colorButtons;

        private int stage = 1;

        private string answer = "";

        public PickColor()
        {
            InitializeComponent();
            colorButtons = new List<Button>
            {
                colorButton0,
                colorButton1,
                colorButton2,
                colorButton3,
                colorButton4,
                colorButton5,
                colorButton6,
                colorButton7,
                colorButton8,
                colorButton9,
                colorButton10,
                colorButton11,
                colorButton12,
                colorButton13,
                colorButton14,
                colorButton15,
                colorButton16,
                colorButton17,
                colorButton18,
                colorButton19,
                colorButton20,
                colorButton21,
                colorButton22,
                colorButton23,
                colorButton24,
                colorButton25,
                colorButton26,
                colorButton27,
                colorButton28,
                colorButton29,
                colorButton30,
                colorButton31,
                colorButton32,
                colorButton33,
                colorButton34,
                colorButton35,
                colorButton36,
                colorButton37,
                colorButton38,
                colorButton39,
                colorButton40,
                colorButton41,
                colorButton42,
                colorButton43,
                colorButton44,
                colorButton45,
                colorButton46,
                colorButton47,
                colorButton48,
                colorButton49
            };
            setUpStage();
        }

        public string StageName { get => "Pick a color"; }

        public Action OnStageWin { get; set; }

        public Action OnStageLose { get; set; }

        public void OnStageEnd()
        {
        }

        public void OnStageStart()
        {
        }

        private void rearrangeButtons()
        {
            foreach (Button button in colorButtons)
            {
                button.Visibility = Visibility.Hidden;
            }
            int buttonWidth;
            int buttonHeight;
            int buttonsHorizontal;
            int buttonsVertical;
            int fromLeft = 10;
            int fromBottom = 10;
            switch (stage)
            {
                default:
                    buttonsHorizontal = 2;
                    buttonsVertical = 2;
                    break;

                case 2:
                    buttonsHorizontal = 4;
                    buttonsVertical = 3;
                    break;

                case 3:
                    buttonsHorizontal = 10;
                    buttonsVertical = 5;
                    break;
            }
            buttonWidth = (int)((Width - 50 - (buttonsHorizontal - 1) * 10) / buttonsHorizontal);
            buttonHeight = (int)((Height - 150 - (buttonsVertical - 1) * 10) / buttonsVertical);
            fromLeft -= buttonWidth;
            fromBottom -= buttonHeight;
            for (int i = 0; i < buttonsHorizontal * buttonsVertical; i++)
            {
                colorButtons[i].HorizontalAlignment = HorizontalAlignment.Left;
                colorButtons[i].VerticalAlignment = VerticalAlignment.Bottom;
                colorButtons[i].Width = buttonWidth;
                colorButtons[i].Height = buttonHeight;
                if (i % buttonsHorizontal == 0)
                {
                    fromBottom += buttonHeight + 3;
                    fromLeft = 10 - buttonWidth;
                }
                fromLeft += buttonWidth + 10;
                colorButtons[i].Margin = new Thickness(fromLeft, 100, 0, fromBottom);
                colorButtons[i].Visibility = Visibility.Visible;
            }
        }

        private List<int> getXIndexesFromRange(int maxIndex, int indexesCount)
        {
            List<int> foundIndexes = new List<int>();
            List<int> availableIndexes = new List<int>();
            int pickedIndex;
            for (int i = 0; i <= maxIndex; i++)
            {
                availableIndexes.Add(i);
            }
            for (int i = 0; i < indexesCount; i++)
            {
                pickedIndex = availableIndexes[random.Next(availableIndexes.Count)];
                foundIndexes.Add(pickedIndex);
                availableIndexes.Remove(pickedIndex);
            }
            return foundIndexes;
        }

        private void setUpStage()
        {
            int buttonCount = 0;
            List<KeyValuePair<string, SolidColorBrush>> colorSet = new List<KeyValuePair<string, SolidColorBrush>>();
            List<int> chosenColorsIndexes = new List<int>();
            List<Button> affectedButtons = new List<Button>();

            switch (stage)
            {
                case 1:
                    buttonCount = 4;
                    colorSet = notRetardedColors;
                    break;

                case 2:
                    buttonCount = 12;
                    colorSet = mediumDifficultyColors;
                    break;

                case 3:
                    buttonCount = 50;
                    colorSet = FUColors;
                    break;
            }
            for (int i = 0; i < buttonCount; i++)
            {
                affectedButtons.Add(colorButtons[i]);
            }

            chosenColorsIndexes = getXIndexesFromRange((colorSet.Count - 1), buttonCount);
            foreach (Button colButton in affectedButtons)
            {
                colButton.Background = colorSet[chosenColorsIndexes[0]].Value;
                colButton.Tag = colorSet[chosenColorsIndexes[0]].Key;
                colButton.Content = "";
#if DEBUG
                colButton.Content = colorSet[chosenColorsIndexes[0]].Key;
#endif
                chosenColorsIndexes.RemoveAt(0);
            }
            answer = affectedButtons[random.Next(affectedButtons.Count)].Tag.ToString();
            colorLabel.Content = answer;
            rearrangeButtons();
        }

        private void colorButton_Click(object sender, RoutedEventArgs e)
        {
            Button Sender = (Button)sender;
            if (Sender.Tag.ToString() == answer)
            {
                stage++;
            }
            if (stage < 4) setUpStage();
            else
            {
                titleLabel.Content = "You did it, surprisingly";
                OnStageWin?.Invoke();
            }
        }
    }
}
