using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Точка входа приложения.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("Game \"Medieval Tale\"");
            Console.WriteLine();

            bool isEnd = false;
            while (!isEnd)
            {
                Console.WriteLine("Choose game mode:");
                Console.WriteLine("1. Heroes have standart amount of lifes.");
                Console.WriteLine("2. Set amount of lifes manually.");

                int choice = 0;
                string answer = "";
                while ((choice != 1) && (choice != 2))
                {
                    answer = Console.ReadLine();
                    if (answer != "")
                        choice = Convert.ToInt32(answer);
                    else
                        choice = 0;
                }

                Mage mage;
                Warrior warrior;
                Archer archer;

                Console.WriteLine();
                if (choice == 1)
                {
                    mage = new Mage(rnd.Next(1200, 1501));
                    warrior = new Warrior(rnd.Next(2800, 3001));
                    archer = new Archer(rnd.Next(1800, 2201));
                }
                else
                {
                    int mageHP;
                    int warriorHP;
                    int archerHP;
                    Console.WriteLine("Mage's lifes:");
                    mageHP = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Warrior's lifes:");
                    warriorHP = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Archer's lifes:");
                    archerHP = Convert.ToInt32(Console.ReadLine());

                    mage = new Mage(mageHP);
                    warrior = new Warrior(warriorHP);
                    archer = new Archer(archerHP);
                }

                Console.WriteLine();

                Game gi = new Game();

                while (!gi.IsEnd(ref mage, ref warrior, ref archer))
                {
                    gi.CurHealth(ref mage, ref warrior, ref archer);
                    gi.Step(ref mage, ref warrior, ref archer);
                    Console.ReadKey();
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("1. Yes.");
                Console.WriteLine("2. No.");

                choice = 0;
                answer = "";
                while ((choice != 1) && (choice != 2))
                {
                    answer = Console.ReadLine();
                    if (answer != "")
                        choice = Convert.ToInt32(answer);
                    else
                        choice = 0;
                }

                Console.WriteLine();
                if (choice == 2)
                    isEnd = true;
            }
        }
    }
}
