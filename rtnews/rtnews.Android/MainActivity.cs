using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CarouselView.FormsPlugin.Android;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Xamarin.Forms;

namespace rtnews.Droid
{
    [Activity(Label = "rtnews", Icon = "@drawable/icon", Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static TextView TextView = null;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            SupportActionBar.SetDisplayShowHomeEnabled(false);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
                        
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();

            LoadApplication(new App());
        }

        public void SetTextView(string nText)
        {
            if (null == TextView)
            {
                TextView = this.FindViewById<TextView>(Resource.Id.tooltitle);
            }
            TextView.Text = nText;
        }

        public void ResetTextView()
        {
            if (null == TextView)
            {
                TextView = this.FindViewById<TextView>(Resource.Id.tooltitle);
            }
            TextView.Text = GetString(Resource.String.app_name);
        }
    }
}

