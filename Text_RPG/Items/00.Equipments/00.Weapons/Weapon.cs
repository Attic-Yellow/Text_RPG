using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items.Equipments;

namespace Text_RPG.Items.Equipments.Weapons
{
    internal class Weapon : Equipment
    {
        public Weapon()
        {
            equipType = EquipmentTypes.Weapon;
        }



        protected int m_attackPower;
        protected int m_criticalPower;

    }
}
