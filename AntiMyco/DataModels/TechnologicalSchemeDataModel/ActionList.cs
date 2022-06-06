using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels.TechnologicalSchemeDataModel
{
    public partial class ActionList
    {
        public int IdOperation { get; set; }
        public int IdAction { get; set; }
        public int SerialNumber { get; set; }

        public virtual Action IdActionNavigation { get; set; } = null!;
        public virtual Operation IdOperationNavigation { get; set; } = null!;
    }
}
