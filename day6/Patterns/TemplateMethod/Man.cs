using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public abstract class Man: Human
    {
        public sealed override void StartFamily()
        {
            MeetGirl();
            InviteOnDate();
            LiveTogether();
            MakeProposal();
            GetMarried();
        }

        public abstract void MeetGirl();
        public abstract void InviteOnDate();
        public abstract void LiveTogether();
        public abstract void MakeProposal();
        public abstract void GetMarried();
    }
}
