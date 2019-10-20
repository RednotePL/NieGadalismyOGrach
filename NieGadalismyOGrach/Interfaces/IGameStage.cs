using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NieGadalismyOGrach.Interfaces
{
    internal interface IGameStage
    {
        string StageName { get; set; }
        Action OnStageWin { get; set; }
        Action OnStageLose { get; set; }

        void OnStageStart();

        void OnStageEnd();
    }
}