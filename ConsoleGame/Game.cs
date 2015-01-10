using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Класс-реализация интерфейса IGame.
    /// </summary>
    class Game : IGame
    {
        public bool IsEnd(ref Mage mage, ref Warrior warrior, ref Archer archer)
        {
            if ((mage.CurHP > 0) && (warrior.CurHP <= 0) && (archer.CurHP <= 0))
            {
                Console.WriteLine("▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼");
                Console.WriteLine("Victory!");
                Console.WriteLine("Mage, the rest of lifes " + mage.CurHP);
                Console.WriteLine("▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲");
                return true;
            }
            else if ((mage.CurHP <= 0) && (warrior.CurHP > 0) && (archer.CurHP <= 0))
            {
                Console.WriteLine("▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼");
                Console.WriteLine("Victory!");
                Console.WriteLine("Warrior, the rest of lifes " + warrior.CurHP);
                Console.WriteLine("▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲");
                return true;
            }
            else if ((mage.CurHP <= 0) && (warrior.CurHP <= 0) && (archer.CurHP > 0))
            {
                Console.WriteLine("▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼");
                Console.WriteLine("Victory!");
                Console.WriteLine("Archer, the rest of lifes " + archer.CurHP);
                Console.WriteLine("▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲");
                return true;
            }
            else if ((mage.CurHP <= 0) && (warrior.CurHP <= 0) && (archer.CurHP <= 0))
            {
                Console.WriteLine("▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼");
                Console.WriteLine("Draw!");
                Console.WriteLine("There is no winner");
                Console.WriteLine("▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲");
                return true;
            }
            else
                return false;
        }


        public void Step(ref Mage mage, ref Warrior warrior, ref Archer archer)
        {
            Console.WriteLine("Attack!");
            Random rnd = new Random();
            int player1 = 0;
            int player2 = 0;
            if ((mage.CurHP > 0) && (warrior.CurHP > 0) && (archer.CurHP > 0))
            {
                while (player1 == player2)
                {
                    player1 = rnd.Next(0, 3);
                    player2 = rnd.Next(0, 3);
                }
            }
            else if (mage.CurHP <= 0)   // Если маг выбыл.
            {
                if (rnd.Next(0, 2) == 0)
                {
                    player1 = 1;
                    player2 = 2;
                }
                else
                {
                    player1 = 2;
                    player2 = 1;
                }
            }
            else if (warrior.CurHP <= 0)   // Если воин выбыл.
            {
                if (rnd.Next(0, 2) == 0)
                {
                    player1 = 0;
                    player2 = 2;
                }
                else
                {
                    player1 = 2;
                    player2 = 0;
                }
            }
            else if (archer.CurHP <= 0)   // Если лучник выбыл.
            {
                if (rnd.Next(0, 2) == 0)
                {
                    player1 = 0;
                    player2 = 1;
                }
                else
                {
                    player1 = 1;
                    player2 = 0;
                }
            }
            if ((player1 == 0) && (player2 == 1))               // Маг — воин.
            {
                Console.WriteLine("Mage — Warrior");
                KeyValuePair<TypeOfUnit, int> result1 = mage.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.warrior, 0), 0);
                int damage1 = result1.Value;
                KeyValuePair<TypeOfUnit, int> result2 = warrior.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.mage, damage1), 1);
                int damage2 = result2.Value;

                if (damage1 < 0)
                    warrior.CurHP += damage1;                       // Если маг нанес урон воину.
                else
                    mage.CurHP += damage1;                          // Если маг себя полечил.
                if (damage2 < 0)
                    mage.CurHP += damage2;                          // Если воин нанес урон магу.
                else
                    warrior.CurHP += damage2;                       // Если воин отразил часть урона мага.
            }
            else if ((player1 == 1) && (player2 == 0))          // Воин — маг.
            {
                Console.WriteLine("Warrior — Mage");
                KeyValuePair<TypeOfUnit, int> result1 = warrior.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.mage, 0), 0);
                int damage1 = result1.Value;
                KeyValuePair<TypeOfUnit, int> result2 = mage.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.warrior, damage1), 1);
                int damage2 = result2.Value;

                mage.CurHP += damage1;                              // Воин первым всегда атакует.
                if (damage2 < 0)
                    warrior.CurHP += damage2;                       // Если маг нанес урон воину.
                else
                    mage.CurHP += damage2;                          // Если маг себя полечил или превратился в воина
                                                                    // и отразил часть урона.
            }
            else if ((player1 == 0) && (player2 == 2))          // Маг — лучник.
            {
                Console.WriteLine("Mage — Archer");
                KeyValuePair<TypeOfUnit, int> result1 = mage.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.archer, 0), 0);
                int damage1 = result1.Value;
                KeyValuePair<TypeOfUnit, int> result2 = archer.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.mage, damage1), 1);
                int damage2 = result2.Value;

                if (damage1 < 0)    
                    archer.CurHP += damage1;                        // Если маг нанес урон лучнику.
                else
                    mage.CurHP += damage1;                          // Если маг себя полечил.
                if (damage2 < 0)
                    mage.CurHP += damage2;                          // Если лучник нанес урон магу.
                else
                    archer.CurHP += damage2;                        // Если лучник увернулся от атаки мага.
            }
            else if ((player1 == 2) && (player2 == 0))          // Лучник — маг.
            {
                Console.WriteLine("Archer — Mage");
                KeyValuePair<TypeOfUnit, int> result1 = archer.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.mage, 0), 0);
                int damage1 = result1.Value;
                KeyValuePair<TypeOfUnit, int> result2 = mage.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.archer, damage1), 1);
                int damage2 = result2.Value;

                mage.CurHP += damage1;                              // Лучник первым всегда атакует.
                if (damage2 < 0)
                    archer.CurHP += damage2;                        // Если маг ответил атакой лучнику.
                else
                    mage.CurHP += damage2;                          // Если маг полечился.
            }
            else if ((player1 == 1) && (player2 == 2))          // Воин — Лучник.
            {
                Console.WriteLine("Warrior — Archer");
                KeyValuePair<TypeOfUnit, int> result1 = warrior.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.archer, 0), 0);
                int damage1 = result1.Value;
                KeyValuePair<TypeOfUnit, int> result2 = archer.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.warrior, damage1), 1);
                int damage2 = result2.Value;

                archer.CurHP += damage1;                            // Воин первым атакует.
                if (damage2 < 0)
                    warrior.CurHP += damage2;                       // Лучник атакует в ответ.
                else
                    archer.CurHP += damage2;                        // Лучник уворачивается.
            }
            else if ((player1 == 2) && (player2 == 1))          // Лучник — Воин.
            {
                Console.WriteLine("Archer — Warrior");
                KeyValuePair<TypeOfUnit, int> result1 = archer.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.warrior, 0), 0);
                int damage1 = result1.Value;
                KeyValuePair<TypeOfUnit, int> result2 = warrior.UnitAction(new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.archer, damage1), 1);
                int damage2 = result2.Value;

                warrior.CurHP += damage1;                           // Лучник первым атакует.
                if (damage2 < 0)
                    archer.CurHP += damage2;                        // Воин атакует в ответ.
                else
                    warrior.CurHP += damage2;                       // Воин отражает часть урона.
            }
            Console.WriteLine();
        }


        public void CurHealth(ref Mage mage, ref Warrior warrior, ref Archer archer)
        {
            if (mage.CurHP < 0) 
                mage.CurHP = 0;
            if (warrior.CurHP < 0)
                warrior.CurHP = 0;
            if (archer.CurHP < 0)
                archer.CurHP = 0;
            Console.WriteLine("----------------------------------------------");
            Console.Write("Lifes: Mage — " + mage.CurHP.ToString());
            Console.Write(", Warrior — " + warrior.CurHP.ToString());
            Console.WriteLine(", Archer — " + archer.CurHP.ToString());
            Console.WriteLine();
        }
    }
}
