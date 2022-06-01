using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class EquipmentInvolvedInStage
    {
        public int IdEquipment { get; set; }
        public int IdStage { get; set; }
        public int NumberOfUnits { get; set; }

        public virtual Equipment IdEquipmentNavigation { get; set; } = null!;
        public virtual Stage IdStageNavigation { get; set; } = null!;
    }
}
