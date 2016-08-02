using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinHomawork
{
    public class Frag : Fragment
    {
        string specialText;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.FragLayout, container, false);
            TextView textView = view.FindViewById<TextView>(Resource.Id.txt);
            textView.Text = specialText;
            return view;
        }

        public string getSpecialText()
        {
            return specialText;
        }

        public void setSpecialText(string specialText)
        {
            this.specialText = specialText;
        }

        
        
    }
}