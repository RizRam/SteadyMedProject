using System;
using System.Collections.Generic;
using System.Text;

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
