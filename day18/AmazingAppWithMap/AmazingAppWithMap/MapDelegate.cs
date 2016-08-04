using CoreAudioKit;
using CoreLocation;
using MapKit;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace AmazingAppWithMap
{
    class MapDelegate : MKMapViewDelegate
    {
        protected string annotationIdentifier = "BasicAnnotation";
        UIButton detailButton;
        MapController parent;

        public MapDelegate(MapController parent)
        {
            this.parent = parent;
        }

        /// <summary>
        /// This is very much like the GetCell method on the table delegate
        /// </summary>
        public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {

            // try and dequeue the annotation view
            MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);

            // if we couldn't dequeue one, create a new one
            if (annotationView == null)
                annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
            else // if we did dequeue one for reuse, assign the annotation to it
                annotationView.Annotation = annotation;

            // configure our annotation view properties
            annotationView.CanShowCallout = true;
            (annotationView as MKPinAnnotationView).AnimatesDrop = true;
            (annotationView as MKPinAnnotationView).PinColor = MKPinAnnotationColor.Green;
            annotationView.Selected = true;

            // you can add an accessory view, in this case, we'll add a button on the right, and an image on the left
            detailButton = UIButton.FromType(UIButtonType.DetailDisclosure);

            detailButton.TouchUpInside += (s, e) => {
                Console.WriteLine("Clicked");
                List<CLLocationCoordinate2D> list = new List<CLLocationCoordinate2D>();
                for (int i = 0; i < parent.DoubleMap.Annotations.Length; i++)
                {
                    list.Add(parent.DoubleMap.Annotations[i].Coordinate);
                }

                var ctrl = ((TableController)parent.Storyboard.InstantiateViewController("TableController"));
                ctrl.TableItems = list;
                parent.NavigationController.PushViewController(ctrl, true);
                //parent.NavigationController.PopToViewController

            };
            annotationView.RightCalloutAccessoryView = detailButton;

            return annotationView;
        }



        // as an optimization, you should override this method to add or remove annotations as the 
        // map zooms in or out.
        public override void RegionChanged(MKMapView mapView, bool animated) { }
    }
}
