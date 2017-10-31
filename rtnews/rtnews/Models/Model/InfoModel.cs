using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rtnews
{
    public class InfoModel : ObservableObject
    {
        void LoadValues(ImageNews nImageNews)
        {
            var uconfig = UConfig.Instance();
            string path = uconfig.ApiUrl + "Upload/ImageNews/";
            path += nImageNews.Name; path += "/page_";
            for (int i = 0; i < nImageNews.Count; i++)
            {
                string imageUrl = path + i;
                imageUrl += ".png";
                mImageUrls.Add(imageUrl);
            }
        }

        public List<string> ImageUrls
        {
            get
            {
                return mImageUrls;
            }
        }

        public InfoModel(ImageNews nImageNews)
        {
            this.LoadValues(nImageNews);
        }

        List<string> mImageUrls = new List<string>();
        protected INavigation mNavigation;
    }
}
