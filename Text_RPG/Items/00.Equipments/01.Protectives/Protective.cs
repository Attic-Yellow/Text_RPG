using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_RPG.Items.Equipments;

namespace Text_RPG.Items.Equipments.Protectives
{
    internal abstract class Protective : Equipment
    {
        public enum ProtectiveTypes {Hat, Armor, Shoes,End }
        public Protective()
        {
           equipType = EquipmentTypes.Protective;
        }

        protected ProtectiveTypes protectiveType;
    
    }
}
