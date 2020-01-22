using NieGadalismyOGrach.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NieGadalismyOGrach
{
    public class GameManager
    {
        /// <summary>
        /// Queue to hold all level references
        /// </summary>
        private List<IGameStage> levels = new List<IGameStage>();

        /// <summary>
        /// Holds currently playing level
        /// </summary>
        private IGameStage currentLevel = null;

        /// <summary>
        /// Starts a new game
        /// </summary>
        public void StartGame()
        {
            if (!levels.Any())
            {
                throw new Exception("There are no levels in the game");
            }

            SetupLevel();
        }

        /// <summary>
        /// Sets up a new level
        /// </summary>
        private void SetupLevel()
        {
            currentLevel = Dequeue();

            currentLevel.OnStageWin += OnStageWin;
            currentLevel.OnStageLose += OnStageLose;

            ((Window)currentLevel).Show();
            currentLevel.OnStageStart();
        }

        /// <summary>
        /// Called on stage lose
        /// </summary>
        private void OnStageLose()
        {
            //if you fail, add failed level back to queue
            levels.Add(currentLevel);

            levels.Shuffle();

            StageEnd();
        }

        /// <summary>
        /// Called on stage end, cleanup methods
        /// </summary>
        private void StageEnd()
        {
            CleanupLevel();

            if (!levels.Any())
            {
                GameEnd();
            }
            else
            {
                SetupLevel();
            }
        }

        /// <summary>
        /// Dequeues a level from list, and then shuffle it to randomize
        /// </summary>
        /// <returns></returns>
        private IGameStage Dequeue()
        {
            if (!levels.Any())
            {
                return null;
            }
            else
            {
                IGameStage r = levels.First();
                levels.Remove(r);

                levels.Shuffle();

                return r;
            }
        }

        /// <summary>
        /// Clean up stage
        /// </summary>
        private void CleanupLevel()
        {
            currentLevel.OnStageEnd();

            currentLevel.OnStageLose -= OnStageLose;
            currentLevel.OnStageWin -= OnStageWin;

            ((Window)currentLevel).Close();
        }

        /// <summary>
        /// Called when all levels have been played
        /// </summary>
        private void GameEnd()
        {
            //Show some win screen
        }

        /// <summary>
        /// Called on stage win
        /// </summary>
        private void OnStageWin()
        {
            StageEnd();
        }
    }
}
