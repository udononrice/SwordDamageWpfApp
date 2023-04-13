using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SwordDamageWpfApp
{
    class SwordDamage
    {
        /// <summary>
        /// Конструктор вычисляет повреждения для значений Magic и Flaming по умолчанию 
        /// и начального броска 3d6.
        /// </summary>
        /// <param name="startingRoll">Начальный бросок 3d6</param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }

        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        /// <summary>
        /// Содержит рассчитаный урон.
        /// </summary>
        public int Damage { get; private set; }

        private int roll;
        /// <summary>
        /// Содержит случайно сгенерированное число от 3 до 18.
        /// </summary>
        public int Roll
        {
            get { return roll; }
            set 
            { 
                roll = value;
                CalculateDamage();
            }
        }

        private bool magic;
        /// <summary>
        /// True если меч волшебный; False в противном случае.
        /// </summary>
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        private bool flaming;
        /// <summary>
        /// True если меч огненный; False в противном случае.
        /// </summary>
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }
}
