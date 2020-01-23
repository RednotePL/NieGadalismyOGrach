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
            new KeyValuePair<string, SolidColorBrush>("Red", Brushes.Red),
            new KeyValuePair<string, SolidColorBrush>("Yellow", Brushes.Yellow),
            new KeyValuePair<string, SolidColorBrush>("Green", Brushes.Green),
            new KeyValuePair<string, SolidColorBrush>("Blue", Brushes.Blue),
            new KeyValuePair<string, SolidColorBrush>("White", Brushes.White),
            new KeyValuePair<string, SolidColorBrush>("Gray", Brushes.Gray),
            new KeyValuePair<string, SolidColorBrush>("Black", Brushes.Black),
        };

        private List<KeyValuePair<string, SolidColorBrush>> mediumDifficultyColors = new List<KeyValuePair<string, SolidColorBrush>>
        {
            new KeyValuePair<string, SolidColorBrush>("Red", Brushes.Red),
            new KeyValuePair<string, SolidColorBrush>("Orange", Brushes.Orange),
            new KeyValuePair<string, SolidColorBrush>("Yellow", Brushes.Yellow),
            new KeyValuePair<string, SolidColorBrush>("Green", Brushes.Green),
            new KeyValuePair<string, SolidColorBrush>("Turquoise", Brushes.Turquoise),
            new KeyValuePair<string, SolidColorBrush>("Blue", Brushes.Blue),
            new KeyValuePair<string, SolidColorBrush>("Purple", Brushes.Purple),
            new KeyValuePair<string, SolidColorBrush>("Pink", Brushes.Pink),
            new KeyValuePair<string, SolidColorBrush>("Brown", Brushes.Brown),
            new KeyValuePair<string, SolidColorBrush>("White", Brushes.White),
            new KeyValuePair<string, SolidColorBrush>("Gray", Brushes.Gray),
            new KeyValuePair<string, SolidColorBrush>("Black", Brushes.Black),
            new KeyValuePair<string, SolidColorBrush>("Neon Green (lime)", Brushes.Lime),
            new KeyValuePair<string, SolidColorBrush>("Neon Blue (cyan)", Brushes.Cyan),
            new KeyValuePair<string, SolidColorBrush>("Dark Blue (navy)", Brushes.Navy),
            new KeyValuePair<string, SolidColorBrush>("Gold", Brushes.Gold),
        };

        private List<KeyValuePair<string, SolidColorBrush>> FUColors = new List<KeyValuePair<string, SolidColorBrush>>
        {
            new KeyValuePair<string, SolidColorBrush>("Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFC0CB"))),
            new KeyValuePair<string, SolidColorBrush>("Light Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB6C1"))),
            new KeyValuePair<string, SolidColorBrush>("Hot Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF69B4"))),
            new KeyValuePair<string, SolidColorBrush>("Deep Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF1493"))),
            new KeyValuePair<string, SolidColorBrush>("Champagne Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F1DDCF"))),
            new KeyValuePair<string, SolidColorBrush>("Pink Lace", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDF4"))),
            new KeyValuePair<string, SolidColorBrush>("Piggy Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FDDDE6"))),
            new KeyValuePair<string, SolidColorBrush>("Pale Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F9CCCA"))),
            new KeyValuePair<string, SolidColorBrush>("Baby Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F4C2C2"))),
            new KeyValuePair<string, SolidColorBrush>("Spanish pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F7BFBE"))),
            new KeyValuePair<string, SolidColorBrush>("Cameo Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#EFBBCC"))),
            new KeyValuePair<string, SolidColorBrush>("Orchid Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F2BDCD"))),
            new KeyValuePair<string, SolidColorBrush>("Fairy Tale", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F2C1D1"))),
            new KeyValuePair<string, SolidColorBrush>("Cherry Blossom Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB7C5"))),
            new KeyValuePair<string, SolidColorBrush>("Light Hot Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB3DE"))),
            new KeyValuePair<string, SolidColorBrush>("Lavender pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FBAED2"))),
            new KeyValuePair<string, SolidColorBrush>("Cotton Candy", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFBCD9"))),
            new KeyValuePair<string, SolidColorBrush>("Carnation Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA6C9"))),
            new KeyValuePair<string, SolidColorBrush>("Baker-Miller Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF91AF"))),
            new KeyValuePair<string, SolidColorBrush>("Tickle Me Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FC89AC"))),
            new KeyValuePair<string, SolidColorBrush>("Amaranth Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F19CBB"))),
            new KeyValuePair<string, SolidColorBrush>("Charm pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#E68FAC"))),
            new KeyValuePair<string, SolidColorBrush>("China Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#DE6FA1"))),
            new KeyValuePair<string, SolidColorBrush>("Mimi Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDAE9"))),
            new KeyValuePair<string, SolidColorBrush>("Tango Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#E4717A"))),
            new KeyValuePair<string, SolidColorBrush>("Coral Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F88379"))),
            new KeyValuePair<string, SolidColorBrush>("Pastel Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#DEA5A4"))),
            new KeyValuePair<string, SolidColorBrush>("New York Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#D7837F"))),
            new KeyValuePair<string, SolidColorBrush>("Solid pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#893843"))),
            new KeyValuePair<string, SolidColorBrush>("Silver Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#C4AEAD"))),
            new KeyValuePair<string, SolidColorBrush>("Queen Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8CCD7"))),
            new KeyValuePair<string, SolidColorBrush>("Pink Lavender", (SolidColorBrush)(new BrushConverter().ConvertFrom("#DBB2D1"))),
            new KeyValuePair<string, SolidColorBrush>("Mountbatten pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#997A8D"))),
            new KeyValuePair<string, SolidColorBrush>("Chilean Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#E8C3BA"))),
            new KeyValuePair<string, SolidColorBrush>("Pale Dogwood", (SolidColorBrush)(new BrushConverter().ConvertFrom("#EDCDC2"))),
            new KeyValuePair<string, SolidColorBrush>("Pink U", (SolidColorBrush)(new BrushConverter().ConvertFrom("#D74894"))),
            new KeyValuePair<string, SolidColorBrush>("Mexican pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#E4007C"))),
            new KeyValuePair<string, SolidColorBrush>("Barbie pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#DA1884"))),
            new KeyValuePair<string, SolidColorBrush>("Fandango pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#DE5285"))),
            new KeyValuePair<string, SolidColorBrush>("Paradise pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#E63E62"))),
            new KeyValuePair<string, SolidColorBrush>("Brink pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FB607F"))),
            new KeyValuePair<string, SolidColorBrush>("French pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FD6C9E"))),
            new KeyValuePair<string, SolidColorBrush>("Bright pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF007F"))),
            new KeyValuePair<string, SolidColorBrush>("Persian Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#F77FBE"))),
            new KeyValuePair<string, SolidColorBrush>("Rose pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF66CC"))),
            new KeyValuePair<string, SolidColorBrush>("Light Deep Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF5CCD"))),
            new KeyValuePair<string, SolidColorBrush>("Ultra Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF6FFF"))),
            new KeyValuePair<string, SolidColorBrush>("Shocking Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#FC0FC0"))),
            new KeyValuePair<string, SolidColorBrush>("Super Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#CF6BA9"))),
            new KeyValuePair<string, SolidColorBrush>("Rose Pompadour", (SolidColorBrush)(new BrushConverter().ConvertFrom("#ED7A9B"))),
            new KeyValuePair<string, SolidColorBrush>("Steel Pink", (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC33CC")))
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
