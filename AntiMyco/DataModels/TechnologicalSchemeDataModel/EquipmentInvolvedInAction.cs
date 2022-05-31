using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class EquipmentInvolvedInAction
    {
        public int IdEquipment { get; set; }
        public int IdAction { get; set; }
        public int? Amount { get; set; }

        public virtual Action IdActionNavigation { get; set; } = null!;
        public virtual Equipment IdEquipmentNavigation { get; set; } = null!;
    }
}
