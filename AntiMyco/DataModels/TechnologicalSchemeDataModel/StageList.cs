using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class StageList
    {
        public int IdScheme { get; set; }
        public int IdStage { get; set; }
        public int SerialNumber { get; set; }

        public virtual ProductionScheme IdSchemeNavigation { get; set; } = null!;
        public virtual Stage IdStageNavigation { get; set; } = null!;
    }
}
