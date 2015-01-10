using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Способности воина.
    /// </summary>
    enum WarriorSkills {powerStrike, lunge, shieldStrike, defence}


    /// <summary>
    /// Класс воина, потомок юнита.
    /// </summary>
    class Warrior : Unit
    {


        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Warrior() : base() { }


        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="hp">жизни воина</param>
        public Warrior(int hp) : base(hp) { }


        /// <summary>
        /// Действие воина.
        /// </summary>
        /// <param name="info">пара "тип цели : урон"</param>
        /// <param name="order">очередь игрока</param>
        /// <returns>пара "тип цели : эффект"</returns>
        /// <returns></returns>
        public override KeyValuePair<TypeOfUnit, int> UnitAction(KeyValuePair<TypeOfUnit, int> info, int order)
        {
            Random rnd = new Random();
            TypeOfUnit enemy = info.Key;
            int damage = Math.Abs(info.Value);
            int skill;
            if (order == 0)     // Воин делает ход первым.
            {
                skill = rnd.Next(0, 3);
            }
            else                // Воин делает ход вторым.
            {
                if (info.Value >= 0)
                    skill = rnd.Next(0, 3);
                else
                    skill = rnd.Next(0, 4);
            }
            int result;
            switch (skill)
            {
                case 0:
                    result = PowerStrike();
                    return new KeyValuePair<TypeOfUnit,int>(enemy, result);
                case 1:
                    result = Lunge(); 
                    return new KeyValuePair<TypeOfUnit,int>(enemy, result);
                case 2:
                    result = ShieldStrike();  
                    return new KeyValuePair<TypeOfUnit,int>(enemy, result);
                case 3:
                    result = Defence(TypeOfUnit.warrior, damage);
                    return new KeyValuePair<TypeOfUnit,int>(TypeOfUnit.warrior, result);
            }
            return new KeyValuePair<TypeOfUnit,int>(enemy, 0);
        }


        /// <summary>
        /// Способность "сильный удар".
        /// </summary>
        /// <returns>урон</returns>
        public int PowerStrike()
        {
            Random rnd = new Random();
            int damage = rnd.Next(300,401);
            Console.WriteLine("Warrior \"Power Strike\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "выпад".
        /// </summary>
        /// <returns>урон</returns>
        public int Lunge()
        {
            Random rnd = new Random();
            int damage = rnd.Next(250,281);
            Console.WriteLine("Warrior \"Lunge\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "удар щитом".
        /// </summary>
        /// <returns>урон</returns>
        public int ShieldStrike()
        {
            Random rnd = new Random();
            int damage = rnd.Next(350,381);
            Console.WriteLine("Warrior \"Shield Strike\" " + damage.ToString());
            return -damage;
        }


        /// <summary>
        /// Способность "уменьшение урона в 2 раза".
        /// </summary>
        /// <param name="seft">тип юнита, использующего способность</param>
        /// <param name="damage">полученный урон</param>
        /// <returns>кол-во восстановленных жизней</returns>
        public int Defence(TypeOfUnit seft, int damage)
        {
            Random rnd = new Random();
            int healt = damage / 2;
            switch (seft)
            {
                case TypeOfUnit.warrior:
                    Console.WriteLine("Warrior \"Reduce damage by 2\" -" + healt.ToString());
                    break;
                case TypeOfUnit.mage:
                    Console.WriteLine("Mage \"Reduce damage by 2\" -" + healt.ToString());
                    break;
            }
            return healt;
        }
    }
}
