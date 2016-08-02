using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Util;

namespace XamarinHomawork
{
    [Activity(Label = "", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            if (bundle != null)
            {
                count = bundle.GetInt("frag_count", 0);
            }

            Button buttonAdd = FindViewById<Button>(Resource.Id.buttonAdd);
            Button buttonRemove = FindViewById<Button>(Resource.Id.buttonRemove);

            buttonAdd.Click += delegate 
            {
                var myFrag = new Frag();
                var manager= FragmentManager.BeginTransaction();
                myFrag.setSpecialText("Frag time:  " + DateTime.Now.ToLongTimeString().ToString());
                manager.Add(Resource.Id.fragment_container, myFrag, count.ToString());
                manager.Commit();
                count++;         
            };

            buttonRemove.Click += delegate
            {
                if (count > 0)
                {
                    var manager = FragmentManager.BeginTransaction();
                    var lastFrag = FragmentManager.FindFragmentByTag((count - 1).ToString());
                    manager.Remove(lastFrag);
                    manager.Commit();
                    count--;
                }
            };
           

        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("frag_count", count);
            base.OnSaveInstanceState(outState);
        }



    }
}

