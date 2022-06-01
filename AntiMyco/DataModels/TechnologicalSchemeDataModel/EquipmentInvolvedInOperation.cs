using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class EquipmentInvolvedInOperation
    {
        public int IdEquipment { get; set; }
        public int IdOperation { get; set; }
        public int NumberOfUnits { get; set; }

        public virtual Equipment IdEquipmentNavigation { get; set; } = null!;
        public virtual Operation IdOperationNavigation { get; set; } = null!;
    }
}
