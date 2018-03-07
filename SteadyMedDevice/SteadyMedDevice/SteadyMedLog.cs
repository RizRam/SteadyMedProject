using System;
using System.Collections.Generic;
using System.Text;

namespace SteadyMedDevice
{
    /// <summary>
    /// Object that represents a log of a SteadyMed event
    /// </summary>
    class SteadyMedLog
    {
        //Time of log creation/event
        public DateTime DateTime { get; set; }
        //Log message
        public string Message { get; set; }
    }
}
