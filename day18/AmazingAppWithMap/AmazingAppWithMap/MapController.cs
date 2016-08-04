using Foundation;
using MapKit;
using System;
using UIKit;
using CoreLocation;

namespace AmazingAppWithMap
{
    public partial class MapController : UIViewController
    {
        public MKMapView DoubleMap
        { get
            {
                return mMap;
            }
        }
        public MapController (IntPtr handle) : base (handle)
        {
        }



        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            mMap.AddAnnotation(new MKPointAnnotation()
            {
                Title = "Москва",
                Coordinate = new CLLocationCoordinate2D(55.776952,37.389405)
            });
            var tapRecogniser = new UITapGestureRecognizer(this, new ObjCRuntime.Selector("MapTapSelector:"));
            mMap.AddGestureRecognizer(tapRecogniser);
          
        }

        [Export("MapTapSelector:")]
        protected void OnMapTapped(UIGestureRecognizer sender)
        {
            mMap.Delegate = new MapDelegate(this);
            CLLocationCoordinate2D tappedLocationCoord = mMap.ConvertPoint(sender.LocationInView(mMap), mMap);
            
            mMap.AddAnnotation(new MKPointAnnotation()
            {
                Title = "Москва " + Math.Round(tappedLocationCoord.Latitude, 2).ToString() + ", " + Math.Round(tappedLocationCoord.Longitude, 2).ToString(),
                Coordinate = tappedLocationCoord
            });
           
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}