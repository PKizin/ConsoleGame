using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame
{
    /// <summary>
    /// Перечисления типа юнита.
    /// </summary>
    enum TypeOfUnit {unknown, mage, warrior, archer}


    /// <summary>
    /// Класс-родитель "юнит".
    /// Остальные классы (маги,
    /// войны и лучники) наследуются
    /// от него.
    /// </summary>
    class Unit
    {


        /// <summary>
        /// Поля класса-родителя.
        /// </summary>
        private TypeOfUnit mType;
        private int mCurHP;
        private int mMaxHP;


        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public Unit()
        {
            CurHP = 0;
            MaxHP = 0;
        }


        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="hp">жизни юнита</param>
        public Unit(int hp)
        {
            CurHP = hp;
            MaxHP = hp;
        }


        /// <summary>
        /// Абстрактная функция действия
        /// юнита (будет переопределена в
        /// соответствующих классах-потомках.
        /// </summary>
        /// <returns>пара "тип цели : урон"</returns>
        public virtual KeyValuePair<TypeOfUnit, int> UnitAction(KeyValuePair<TypeOfUnit, int> info, int order) 
        {
            return new KeyValuePair<TypeOfUnit,int>(TypeOfUnit.unknown, 0);    
        }


        /// <summary>
        /// Свойства класса-родителя.
        /// </summary>
        public TypeOfUnit Type
        {
            get { return mType; }
            set { mType = value; }
        }
        public int CurHP
        {
            get { return mCurHP; }
            set { mCurHP = value; }
        }
        public int MaxHP
        {
            get { return mMaxHP; }
            set { mMaxHP = value; }
        }
    }
}
