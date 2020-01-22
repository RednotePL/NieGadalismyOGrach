using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NieGadalismyOGrach
{
    public static class Extensions
    {
        #region Fisher-Yates shuffle

        private static Random rng = new Random();

        /// <summary>
        /// Shuffle List using Fisher-Yates algorithm
        /// </summary>
        /// <typeparam name="T">Type of List</typeparam>
        /// <param name="list">List to shuffle</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion Fisher-Yates shuffle
    }
}
