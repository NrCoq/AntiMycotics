using System;
using System.Collections.Generic;

namespace AntiMyco.DataModels
{
    public partial class ProcessParameter
    {
        public ProcessParameter()
        {
            ParameterValues = new HashSet<ParameterValue>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Unit { get; set; }

        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
    }
}
