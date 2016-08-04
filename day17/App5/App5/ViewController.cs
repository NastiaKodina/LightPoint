using System;

using UIKit;

namespace App5
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            /*btn.TouchUpInside += (object sender, EventArgs e) =>
            {
                string str = txt.Text;
                if (str == "123")
                {

                    FourthScreen callHistory = this.Storyboard.InstantiateViewController("FourthScreen") as FourthScreen;
                    if (callHistory != null)
                    {
                        this.NavigationController.PushViewController(callHistory, true);

                    }
                }
            };*/
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}