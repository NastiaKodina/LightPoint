using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    abstract class Handler
    {
        protected Handler _nextHandler;
        public abstract void ProcessLeave(LeaveSettings leaveSettings);
        public void SetNextHandler(Handler nextHandler)
        {
            _nextHandler = nextHandler;
        }
    }
}
