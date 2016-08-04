using Foundation;
using System;
using UIKit;

namespace App5
{
    public partial class FourthScreen : UIViewController
    {
        public FourthScreen(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           /* btnModal.TouchUpInside += (sender, obj) =>
            {
                var newVC = new Modal()
                {
                    ModalPresentationStyle = UIModalPresentationStyle.FormSheet,
                    ModalTransitionStyle = UIModalTransitionStyle.CoverVertical
                };
                PresentViewController(newVC, animated: true);
            };*/
        }
    }

}