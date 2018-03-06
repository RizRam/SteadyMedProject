using System;
using System.Collections.Generic;
using System.Text;

namespace SteadyMedDevice
{
    /// <summary>
    /// Abstract data type to hold SteadyMed logs in memory
    /// </summary>
    class SteadyMedMessageLogs
    {
        //Data structure to hold logs
        private SortedSet<SteadyMedLog> _logs;

        /// <summary>
        /// Constructor
        /// </summary>
        public SteadyMedMessageLogs()
        {
            _logs = new SortedSet<SteadyMedLog>();
        }

        /// <summary>
        /// Add a SteadyMedLog to collection
        /// </summary>
        /// <param name="log"></param>
        public void AddLog(SteadyMedLog log)
        {
            _logs.Add(log);
        }

        /// <summary>
        /// Get all logs in collection
        /// </summary>
        /// <returns>A list of all SteadyMed logs in the collection</returns>
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
