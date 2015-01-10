using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Способности лучника.
    /// </summary>
    enum ArcherSkills { powerShot, aimedShot, dodge }

    
    /// <summary>
    /// Класс лучника, наследник юнита.
    /// </summary>
    class Archer : Unit
    {


        /// <summary>
        /// Конструкторы.
        /// </summary>
        public Archer() : base() { }
        public Archer(int hp) : base(hp) { }


        /// <summary>
        /// Действие лучника.
        /// </summary>
        /// <param name="info">пара "тип цели : урон"</param>
        /// <param name="order">очередь игрока</param>
        /// <returns>пара "тип цели : эффект"</returns>
        public override KeyValuePair<TypeOfUnit, int> UnitAction(KeyValuePair<TypeOfUnit, int> info, int order)
        {
            Random rnd = new Random();
            TypeOfUnit enemy = info.Key;
            int damage = Math.Abs(info.Value);
            int skill;
            if (order == 0)     // Лучник делает ход первым.
            {
                skill = rnd.Next(0, 2);
            }
            else                // Лучник делает ход вторым.
            {
                if (info.Value >= 0)
                    skill = rnd.Next(0, 2);
                else
                    skill = rnd.Next(0, 3);
            }
            int result;
            switch (skill)
            {
                case 0:
                    result = PowerShot();
                    return new KeyValuePair<TypeOfUnit, int>(enemy, result);
                case 1:
                    result = AimedShot();
                    return new KeyValuePair<TypeOfUnit, int>(enemy, result);
                case 2:
                    result = Dodge(damage);
                    return new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.archer, result);
            }
            return new KeyValuePair<TypeOfUnit, int>(enemy, 0);
        }


        /// <summary>
        /// Способность "мощный выстрел".
        /// </summary>
        /// <returns>урон</returns>
        public int PowerShot()
        {
            Random rnd = new Random();
            int damage = rnd.Next(200, 401);
            Console.WriteLine("Archer \"Power Shot\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "прицельный выстрел".
        /// </summary>
        /// <returns>урон</returns>
        public int AimedShot()
        {
            Random rnd = new Random();
            int damage = rnd.Next(500, 601);
            Console.WriteLine("Archer \"Aimed Shot\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "уворот".
        /// </summary>
        /// <param name="damage">урон врага</param>
        /// <returns>кол-во урона, от которого увернулись</returns>
        public int Dodge(int damage)
        {
            Random rnd = new Random();
            int healt = damage;
            Console.WriteLine("Archer \"Dodge\" -" + healt.ToString());
            return healt;
        }
    }
}
