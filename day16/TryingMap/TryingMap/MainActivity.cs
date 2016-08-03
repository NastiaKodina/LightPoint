using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using static Android.Gms.Maps.GoogleMap;

namespace TryingMap
{
    [Activity(Label = "TryingMap", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity,IOnMapReadyCallback, ILocationListener,IInfoWindowAdapter
    {
        private GoogleMap mMap;

        Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;
        MarkerOptions _marker;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            Button btnNormal = FindViewById<Button>(Resource.Id.btnNormal);
            Button btnSatellite = FindViewById<Button>(Resource.Id.btnSatellite);
            Button btnTerrain = FindViewById<Button>(Resource.Id.btnTerrain);
            Button btnHybrid = FindViewById<Button>(Resource.Id.btnHybrid);

            btnNormal.Click += delegate { mMap.MapType = GoogleMap.MapTypeNormal; };
            btnSatellite.Click += delegate { mMap.MapType = GoogleMap.MapTypeSatellite; };
            btnTerrain.Click += delegate { mMap.MapType = GoogleMap.MapTypeTerrain; };
            btnHybrid.Click += delegate { mMap.MapType = GoogleMap.MapTypeHybrid; };

            InitializeLocationManager();

            SetUpMap();

        }

        

        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
            OnLocationChanged(_locationManager.GetLastKnownLocation(_locationProvider));
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        }

        private void SetUpMap()
        {
            if (mMap==null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            if (_currentLocation != null)
            {
                LatLng position = new LatLng(_currentLocation.Latitude, _currentLocation.Longitude);
                CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(position, 10);
                mMap.MoveCamera(camera);

                _marker = new MarkerOptions()
               .SetPosition(position)
               .Draggable(true);

                mMap.AddMarker(_marker);
                mMap.SetInfoWindowAdapter(this);
                geo(_currentLocation.Latitude, _currentLocation.Longitude);
            }
            mMap.MarkerClick += mMap_MarkerClick;
            mMap.MarkerDragEnd += mMap_DragEnd;
            mMap.MapClick += mMap_Click;
        }

        private void mMap_Click(object sender, GoogleMap.MapClickEventArgs e)
        {
            LatLng position = e.Point;
            LatLng latlng = new LatLng(position.Latitude, position.Longitude);
            mMap.Clear();
            MarkerOptions newMarker = new MarkerOptions()
                    .SetPosition(latlng)
                    .Draggable(true);
            
            mMap.AddMarker(newMarker);
            geo(position.Latitude, position.Longitude);
          
           // Toast.MakeText(this, "Could not reverse geo-code the location", ToastLength.Short).Show();
        }
        private void mMap_MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            LatLng position = e.Marker.Position;
            mMap.AnimateCamera(CameraUpdateFactory.NewLatLngZoom(position,10));
            mMap.SetInfoWindowAdapter(this);


        }

        private void mMap_DragEnd(object sender, GoogleMap.MarkerDragEndEventArgs e)
        {
            LatLng position = e.Marker.Position;
            Console.WriteLine(position.ToString());
        }

        public async void geo(double lat, double lon)
        {
            Geocoder geocdr = new Geocoder(this);
            Task<IList<Address>> getAddressTask = geocdr.GetFromLocationAsync(lat, lon, 5);
            IList<Address> addresses = await getAddressTask;

            if (addresses.Any())
            {
                Address addr = addresses.First();
                Toast.MakeText(this, addr.Thoroughfare+"\n"+addr.AdminArea + ", " + addr.CountryName, ToastLength.Short).Show();
            } 
            else
            {
                Toast.MakeText(this, "Could not reverse geo-code the location", ToastLength.Short).Show();
            }
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;
           /* Geocoder geocdr = new Geocoder(this);
            Task<IList<Address>> getAddressTask = geocdr.GetFromLocationAsync(location.Latitude, location.Longitude, 5);
            IList<Address> addresses = await getAddressTask;

            if (addresses.Any())
            {
                Address addr = addresses.First();
                Toast.MakeText(this, "shjds", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Could not reverse geo-code the location", ToastLength.Short).Show();
            }*/
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }

        public View GetInfoContents(Marker marker)
        {
            return null;
        } 

        public View GetInfoWindow(Marker marker)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.info_window,null,false);
            return view;
        }
    }
}

