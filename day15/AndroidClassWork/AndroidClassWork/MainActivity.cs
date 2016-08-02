using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidClassWork
{
    [Activity(Label = "AndroidClassWork", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            Button buttonMain = FindViewById<Button>(Resource.Id.buttonMain);
            Button btnFirstFrag = FindViewById<Button>(Resource.Id.btnFirstFrag);
            Button btnSecondFrag = FindViewById<Button>(Resource.Id.btnSecondFrag);

            buttonMain.Click += delegate { StartActivity(typeof(SecondActivity)); };

            var firstFragment = new FirstFragment();
            var secondFragment = new SecondFragment();
            var ft = FragmentManager.BeginTransaction();
            ft.Add(Resource.Id.fragment_container, firstFragment);
            ft.Commit();

            btnFirstFrag.Click += delegate
            {

                var manager = FragmentManager.BeginTransaction();
                manager.Replace(Resource.Id.fragment_container, firstFragment);
                manager.Commit();
            };
            btnSecondFrag.Click += delegate
            {
                var manager = FragmentManager.BeginTransaction();
                manager.Replace(Resource.Id.fragment_container, secondFragment);
                manager.Commit();
            };
        }
    }
}

