using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class EquipmentParameter
    {
        public int IdParameter { get; set; }
        public int IdEquipment { get; set; }
        public float Value { get; set; }

        public virtual Equipment IdEquipmentNavigation { get; set; } = null!;
        public virtual Parameter IdParameterNavigation { get; set; } = null!;
    }
}
