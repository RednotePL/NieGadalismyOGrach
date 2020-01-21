using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NieGadalismyOGrach.Interfaces.Implementations
{
    internal class GameStage : IGameStage
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