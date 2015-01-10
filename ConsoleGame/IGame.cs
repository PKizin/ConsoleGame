using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Интерфейс самой игры.
    /// </summary>
    interface IGame
    {
        /// <summary>
        /// Закончилась ли игра?
        /// </summary>
        /// <param name="mage">маг</param>
        /// <param name="warrior">воин</param>
        /// <param name="archer">лучник</param>
        /// <returns>true=конец</returns>
        bool IsEnd(ref Mage mage, ref Warrior warrior, ref Archer archer);


        /// <summary>
        /// Шаг игры.
        /// </summary>
        /// <param name="mage">маг</param>
        /// <param name="warrior">воин</param>
        /// <param name="archer">лучник</param>
        void Step(ref Mage mage, ref Warrior warrior, ref Archer archer);


        /// <summary>
        /// Анализ текущих жизней.
        /// </summary>
        /// <param name="mage">маг</param>
        /// <param name="warrior">воин</param>
        /// <param name="archer">лучник</param>
        void CurHealth(ref Mage mage, ref Warrior warrior, ref Archer archer);
    }
}
