using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class ProjectManager:Handler
    {
        public override void ProcessLeave(LeaveSettings leaveSettings)
        {
            if (leaveSettings.CountOfDays > 3 && leaveSettings.CountOfDays<=10)
                Console.WriteLine("Leave has been aproved by Project Manager");
            else
                _nextHandler.ProcessLeave(leaveSettings);
        }
    }
}
