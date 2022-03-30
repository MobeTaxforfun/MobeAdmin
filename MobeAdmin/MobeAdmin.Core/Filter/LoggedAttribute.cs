using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Core.Filter
{
    public class LoggedAttribute : Attribute
    {
        public LogEvent Event { get; set; }
        public string ControllerTag { get; set; }

        public string ActionTag { get; set; }

        public LoggedAttribute(string ct, string at, LogEvent ev = LogEvent.None)
        {
            Event = ev;
            ControllerTag = ct;
            ActionTag = at;
        }
    }

    public enum LogEvent
    {
        None,
        Transaction
    }
}
