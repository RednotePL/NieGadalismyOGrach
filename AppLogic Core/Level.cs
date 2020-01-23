using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AppLogic_Core
{
    public abstract class Level
    {
        public string LevelElement = "ClickEscapingButton";
        /// <summary>
        /// 0 is unplayed
        /// 1 is current level
        /// 2 is finished
        /// </summary>
        public int Level_Status;
        public static Action<string> BringToTop;
        public void PrepareLevel()
        {
            BringToTop(LevelElement);
        }
    }
}
