using System;
using Xamarin.Forms;

namespace rtnews
{
    public class ImageNews : TextNews
    {
        public void RunInit()
        {
            var uconfig = UConfig.Instance();
            mImageUrl = uconfig.ApiUrl;
            mImageUrl += "Upload/ImageNews/";
            mImageUrl += Name;
            mImageUrl += "/page_i.png";
        }

        public string ImageUrl
        {
            get
            {
                return mImageUrl;
            }
        }
        
        public event EventHandler ImageClickEvent;
        public void OnImageClicked()
        {
            ImageClickEvent?.Invoke(this, EventArgs.Empty);
        }

        public Command ImageClick
        {
            get
            {
                return mImageClick;
            }
        }

        public ImageNews()
        {
            mImageClick = new Command(
                () => OnImageClicked()
                );
        }

        Command mImageClick;
        string mImageUrl;
    }
}
