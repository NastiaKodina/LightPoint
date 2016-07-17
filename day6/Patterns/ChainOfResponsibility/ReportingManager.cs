using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class ReportingManager:Handler
    {
        public override void ProcessLeave(LeaveSettings leaveSettings)
        {
            if (leaveSettings.CountOfDays < 3)
                Console.WriteLine("Leave has been aproved by Repoting Manager");
            else
                _nextHandler.ProcessLeave(leaveSettings);
        }
    }
}
