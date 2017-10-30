using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace rtnews
{
    public class NewsModel
    {
        async void RunSelected(ImageNews nImageNews)
        {
            var infoPage = new InfoPage(nImageNews);
            var navPage = new NavigationPage(infoPage);
            await mNavigation.PushModalAsync(navPage);
        }

        public ImageNews SelectedValue
        {
            get
            {
                return mTextNews;
            }
            set
            {
                if (null == value)
                {
                    return;
                }
                mTextNews = value;
                this.RunSelected(mTextNews);
            }
        }
        ImageNews mTextNews;

        public List<ImageNews> TextNewsList
        {
            get
            {
                return mImageNewsList;
            }
        }

        public INavigation Navigation
        {
            get
            {
                return mNavigation;
            }
            set
            {
                mNavigation = value;
            }
        }

        public NewsModel()
        {
            mImageNewsList = new List<ImageNews>();
        }

        protected List<ImageNews> mImageNewsList;
        protected INavigation mNavigation;
    }
}
