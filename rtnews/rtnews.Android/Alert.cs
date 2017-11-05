using Android.Widget;
using Android.App;
using rtnews.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AlertAndroid))]
namespace rtnews.Droid
{
	public class AlertAndroid : IAlert
	{
        public void ShowLong(string nMessage)
        {
            Toast.MakeText(Application.Context, nMessage, ToastLength.Long).Show();
        }

        public void ShowShort(string nMessage)
        {
            Toast.MakeText(Application.Context, nMessage, ToastLength.Short).Show();
        }
    }
}
