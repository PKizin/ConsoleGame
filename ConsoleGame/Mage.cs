using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Способности мага.
    /// </summary>
    enum MageSkills { fireball, thunderbolt, blizzard, heal, transform }


    /// <summary>
    /// Класс маг, потомок юнита.
    /// </summary>
    class Mage : Unit
    {


        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Mage() : base() { }


        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="hp">жизни мага</param>
        public Mage(int hp) : base(hp) { }


        /// <summary>
        /// Действие мага.
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
            if (order == 0)      // Маг делает ход первым.
            {
                if (CurHP < MaxHP)
                    skill = rnd.Next(0, 4);
                else
                    skill = rnd.Next(0, 3);
            }
            else                // Маг делает ход вторым.
            {
                if (enemy == TypeOfUnit.warrior)
                    skill = rnd.Next(0, 5);
                else
                    skill = rnd.Next(0, 4);
            }
            if (CurHP < MaxHP / 2)  // Лечимся, если осталось меньше 1/2 hp.
                skill = 3;
            int result;
            switch (skill)
            {
                case 0: 
                    result = Fireball();
                    return new KeyValuePair<TypeOfUnit,int>(enemy, result);
                case 1: 
                    result = Thunderbolt(); 
                    return new KeyValuePair<TypeOfUnit,int>(enemy, result);
                case 2: 
                    result = Blizzard();  
                    return new KeyValuePair<TypeOfUnit,int>(enemy, result);
                case 3: 
                    result = Heal();
                    return new KeyValuePair<TypeOfUnit,int>(TypeOfUnit.mage, result);
                case 4:
                    result = Transform(damage);
                    return new KeyValuePair<TypeOfUnit, int>(TypeOfUnit.mage, result); 
            }
            return new KeyValuePair<TypeOfUnit,int>(enemy, 0);
        }


        /// <summary>
        /// Способность "огненный шар".
        /// </summary>
        /// <returns>урон</returns>
        public int Fireball()
        {
            Random rnd = new Random();
            int damage = rnd.Next(200,301);
            Console.WriteLine("Mage \"Fire Ball\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "удар молнии".
        /// </summary>
        /// <returns>урон</returns>
        public int Thunderbolt()
        {
            Random rnd = new Random();
            int damage = rnd.Next(100,501);
            Console.WriteLine("Mage \"Thunderbolt\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "снежная буря".
        /// </summary>
        /// <returns>урон</returns>
        public int Blizzard()
        {
            Random rnd = new Random();
            int damage = rnd.Next(500,801);
            Console.WriteLine("Mage \"Blizzard\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "лечение".
        /// </summary>
        /// <returns>кол-во восстановленных жизней</returns>
        public int Heal()
        {
            Random rnd = new Random();
            int healt = rnd.Next(350,381);
            Console.WriteLine("Mage \"Heal\" +" + healt.ToString());
            return healt;
        }


        /// <summary>
        /// Способность "перевоплощение".
        /// </summary>
        /// <param name="damage">полученный урон</param>
        /// <returns>кол-во восстановленных жизней</returns>
        public int Transform(int damage)
        {
            Random rnd = new Random();
            Console.WriteLine("Mage \"Transformation into Warrior\"");
            return (new Warrior()).Defence(TypeOfUnit.mage, damage);
        }
    }
}
