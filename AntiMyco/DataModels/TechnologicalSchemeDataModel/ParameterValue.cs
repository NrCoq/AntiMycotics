using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class ParameterValue
    {
        public int IdAction { get; set; }
        public int IdParameter { get; set; }
        public float? MaxValue { get; set; }
        public float? MinValue { get; set; }

        public virtual Action IdActionNavigation { get; set; } = null!;
        public virtual ProcessParameter IdParameterNavigation { get; set; } = null!;
    }
}
