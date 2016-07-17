using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Management:Handler
    {
        public override void ProcessLeave(LeaveSettings leaveSettings)
        {
            if (leaveSettings.CountOfDays > 10)
                Console.WriteLine("Leave has been aproved by Management");
        }
    }
}
