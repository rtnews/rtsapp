using System;
using Xamarin.Forms;

namespace rtnews
{
	public class AlertEngine : Singleton<AlertEngine>
    {
		public void ShowLong(string nMessage)
		{
			DependencyService.Get<IAlert>().ShowLong(nMessage);
		}

		public void ShowShort(string nMessage)
		{
			DependencyService.Get<IAlert>().ShowShort(nMessage);
		}
	}
}
