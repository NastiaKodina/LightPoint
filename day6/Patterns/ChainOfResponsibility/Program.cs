using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportingManager reportManager = new ReportingManager();
            ProjectManager projectManager = new ProjectManager();
            Management management = new Management();

            reportManager.SetNextHandler(projectManager);
            projectManager.SetNextHandler(management);

            Console.WriteLine("If count of days < 3");
            LeaveSettings leave = new LeaveSettings();
            leave.CountOfDays = 2;
            reportManager.ProcessLeave(leave);

            Console.WriteLine("\nIf count of days > 3 and < 10");
            leave.CountOfDays = 5;
            reportManager.ProcessLeave(leave);

            Console.WriteLine("\nIf count of days > 10");
            leave.CountOfDays = 12;
            reportManager.ProcessLeave(leave);

            Console.ReadLine();


        }
    }
}
