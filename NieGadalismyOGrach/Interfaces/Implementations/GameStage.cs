using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NieGadalismyOGrach.Interfaces.Implementations
{
    internal class GameStage : Window, IGameStage
    {
        public string StageName { get; set; }

        public Action OnStageWin { get; set; }

        public Action OnStageLose { get; set; }

        public virtual void OnStageStart()
        { }

        public virtual void OnStageEnd()
        { }
    }
}
