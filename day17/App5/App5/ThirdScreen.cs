using Foundation;
using System;
using UIKit;

namespace App5
{
    public partial class ThirdScreen : UIViewController
    {
        public ThirdScreen (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            btn.TouchUpInside += (sender, obj) =>
            {
                
                if (txt.Text=="123")
                    this.NavigationController.PushViewController(this.Storyboard.InstantiateViewController("FourthScreen"), true);
            };
            
        }

       
    }
}