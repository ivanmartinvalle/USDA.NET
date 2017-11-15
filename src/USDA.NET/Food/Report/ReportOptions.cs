using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace USDA.NET.Food.Report
{
    public class ReportOptions
    {
        /// <summary>
        /// Up to 50 NDB Numbers
        /// </summary>
        public List<string> NDBNumbers { get; set; } = new List<string>();

        /// <summary>
        /// Report Type: defaults to Full
        /// </summary>
        public ReportType Type { get; set; } = ReportType.Full;
    }

    public enum ReportType
    {
        [Description("b")]
        Basic,
        [Description("f")]
        Full,
        [Description("s")]
        Stats
    }
}
