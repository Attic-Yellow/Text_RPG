using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items.Equipments;

namespace Text_RPG.Items.Equipments.Protectives
{
    internal class Protective : Equipment
    {
        public enum ProtectiveType { None, Hat, Armor, Shoes }
        public Protective()
        {
            m_equipType = EquipmentType.Protective;
        }

        protected ProtectiveType m_protectiveType;
        protected int m_defensivePower;
    }
}
