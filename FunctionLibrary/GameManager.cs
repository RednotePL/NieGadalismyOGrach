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
        /// List holding all game levels, used to close any lingering windows
        /// </summary>
        private List<IGameStage> allLevels = new List<IGameStage>();

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
        /// Adds a level to queue
        /// </summary>
        /// <param name="gameStage"></param>
        public void EnqueueLevel(IGameStage gameStage)
        {
            levels.Enqueue(gameStage);
            allLevels.Add(gameStage);
        }

        /// <summary>
        /// Get amount of levels
        /// </summary>
        public int GetLevelCount => levels.Count;

        /// <summary>
        /// Sets up a new level
        /// </summary>
        private void SetupLevel()
        {
            currentLevel = levels.Dequeue();

            currentLevel.OnStageWin += OnStageWin;
            currentLevel.OnStageLose += OnStageLose;

            ((Window)currentLevel).Show();
            ((Window)currentLevel).Title = currentLevel.StageName;

            currentLevel.OnStageStart();
        }

        /// <summary>
        /// Called on stage lose
        /// </summary>
        private void OnStageLose()
        {
            MessageBox.Show("U BAD");

            //if you fail, add failed level back to queue
            levels.Enqueue(currentLevel);

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
        /// Clean up stage
        /// </summary>
        private void CleanupLevel()
        {
            currentLevel.OnStageEnd();

            currentLevel.OnStageLose -= OnStageLose;
            currentLevel.OnStageWin -= OnStageWin;

            ((Window)currentLevel).Hide();
        }

        /// <summary>
        /// Called when all levels have been played
        /// </summary>
        public void GameEnd()
        {
            //Show some win screen
            MessageBox.Show("CONGRATULATIONS U WON ZE GAME!1!!oneONE");
            Environment.Exit(0);
        }

        /// <summary>
        /// Called on stage win
        /// </summary>
        private void OnStageWin()
        {
            MessageBox.Show("CONGRATULATIONS");
            StageEnd();
        }

        /// <summary>
        /// Close all levels
        /// </summary>
        public void ForceCloseAllLLevels()
        {
            for (int i = 0; i < allLevels.Count; i++)
            {
                ((Window)allLevels[i]).Close();
            }
        }

        /// <summary>
        /// Completely remove any leftover levels
        /// </summary>
        public void ClearAllLevels()
        {
            levels.Clear();
            ForceCloseAllLLevels();
            allLevels.Clear();
        }
    }

    public static class GameManagerEX
    {
        /// <summary>
        /// Dequeues a level from list, and then shuffle it to randomize
        /// </summary>
        /// <returns>GameStage</returns>
        public static IGameStage Dequeue(this List<IGameStage> list)
        {
            if (!list.Any())
            {
                return null;
            }
            else
            {
                IGameStage result = list.First();
                list.Remove(result);

                list.Shuffle();

                return result;
            }
        }

        /// <summary>
        /// Adds a level to the queue and shuffles the order
        /// </summary>
        /// <param name="list">List of levels</param>
        /// <param name="stage">level to add to list</param>
        public static void Enqueue(this List<IGameStage> list, IGameStage stage)
        {
            list.Add(stage);
            list.Shuffle();
        }
    }
}
