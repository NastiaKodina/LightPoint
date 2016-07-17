using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class PoorMan:Man
    {
        public override void MeetGirl()
        {
            Console.WriteLine("Meet a girl in a small cafe");
        }

        public override void InviteOnDate()
        {
            Console.WriteLine("Invite the girl on a date in the park");
        }

        public override void LiveTogether()
        {
            Console.WriteLine("Live together in a small flat with 2 rooms");
        }

        public override void MakeProposal()
        {
            Console.WriteLine("Buy a gold ring with small diamond");
        }

        public override void GetMarried()
        {
            Console.WriteLine("Make a small wedding with 50 guests");
        }
    }
}
