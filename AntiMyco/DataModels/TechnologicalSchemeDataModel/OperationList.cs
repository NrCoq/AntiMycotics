using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class OperationList
    {
        public int IdOperation { get; set; }
        public int IdStage { get; set; }
        public int SerialNumber { get; set; }

        public virtual Operation IdOperationNavigation { get; set; } = null!;
        public virtual Stage IdStageNavigation { get; set; } = null!;
    }
}
