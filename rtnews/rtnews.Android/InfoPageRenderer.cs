using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using ActionBar = Android.Support.V7.App.ActionBar;

using rtnews;
using rtnews.Droid;
using System.Threading.Tasks;

[assembly: ExportRenderer(typeof(InfoPage), typeof(InfoPageRenderer))] // NON APPCOMP

namespace rtnews.Droid
{
    public class InfoPageRenderer : PageRenderer
    {
        public InfoPageRenderer() : base()
        {
        }

        protected override void OnAttachedToWindow()
        {
            IInfoPage page = (IInfoPage)this.Element;
            var infoTitle = page.InfoTitle;

            var mainActivity = (MainActivity)Context;
            mainActivity.SetTextView(infoTitle);

            base.OnAttachedToWindow();
        }

        protected override void OnDetachedFromWindow()
        {
            var mainActivity = (MainActivity)Context;
            mainActivity.ResetTextView();

            base.OnDetachedFromWindow();
        }
    }
}
