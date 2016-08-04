// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AmazingAppWithMap
{
    [Register ("MapController")]
    partial class MapController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView mMap { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (mMap != null) {
                mMap.Dispose ();
                mMap = null;
            }
        }
    }
}