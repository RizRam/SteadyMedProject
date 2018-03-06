using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This log class would be used in the final device to maintain a history of the
/// device and its usage that could be reported to the web interface as the device
/// itself does not have a built in interface.
/// </summary>

namespace SteadyMedDevice
{
    class SteadyMedMessageLogs
    {
        private SortedSet<SteadyMedLog> _logs;

        public SteadyMedMessageLogs()
        {
            _logs = new SortedSet<SteadyMedLog>();
        }

        public void AddLog(SteadyMedLog log)
        {
            _logs.Add(log);
        }

        public List<SteadyMedLog> GetLogs()
        {
            List<SteadyMedLog> result = new List<SteadyMedLog>();

            foreach(var log in _logs)
            {
                result.Add(log);
            }

            return result;
        }
    }
}
