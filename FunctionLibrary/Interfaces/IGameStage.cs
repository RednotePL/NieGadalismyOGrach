using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NieGadalismyOGrach.Interfaces
{
    public interface IGameStage
    {
        /// <summary>
        /// Game stage name.
        /// </summary>
        string StageName { get; }

        /// <summary>
        /// Action invoked on stage win.
        /// </summary>
        Action OnStageWin { get; set; }
        /// <summary>
        /// Action invoked on stage lose.
        /// </summary>
        Action OnStageLose { get; set; }
        /// <summary>
        /// Function that will prepare level before start.
        /// </summary>
        void OnStageStart();
        /// <summary>
        /// Function called on stage end.
        /// </summary>
        void OnStageEnd();
    }
}
