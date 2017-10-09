using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace rtnews
{
    public class NewsModel
    {
        async void RunSelected(TextNews nTextNews)
        {
            var infoPage = new InfoPage(nTextNews);
            var navPage = new NavigationPage(infoPage);
            await mNavigation.PushModalAsync(navPage);
        }

        public TextNews SelectedValue
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
        TextNews mTextNews;

        public List<TextNews> TextNewsList
        {
            get
            {
                return mTextNewsList;
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
            mTextNewsList = new List<TextNews>();
        }

        protected List<TextNews> mTextNewsList;
        protected INavigation mNavigation;
    }
}
