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
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.App;

namespace rtnews.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            UDirectory.RunInit(Assets);

            Task startupWork = new Task(
                () => {
                    SimulateStartup();
                } );
            startupWork.Start();
        }

        void SimulateStartup()
        {
            var startup = Startup.Instance();
            startup.RunInit();

            StartActivity( new Intent(
                Application.Context, typeof(MainActivity)
                ));
        }
    }
}
