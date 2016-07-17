using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class RichMan: Man
    {
        public override void MeetGirl()
        {
            Console.WriteLine("Meet a girl in an expensive restaurant");
        }

        public override void InviteOnDate()
        {
            Console.WriteLine("Invite the girl on a date in Paris");
        }

        public override void LiveTogether()
        {
            Console.WriteLine("Live together in a huge house with 7 rooms and a big swimming pool");
        }

        public override void MakeProposal()
        {
            Console.WriteLine("Buy a gold ring with a big diamond");
        }

        public override void GetMarried()
        {
            Console.WriteLine("Make a big wedding with 300 guests");
        }
    }
}
