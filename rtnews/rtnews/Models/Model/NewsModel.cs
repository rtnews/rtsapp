using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace rtnews
{
    public class NewsModel
    {
        async void RunSelected(ImageNews nImageNews)
        {
            var infoPage = new InfoPage(nImageNews);
            await mNavigation.PushAsync(infoPage);
        }

        public ICommand SelectedNewsCommand { get; set; }

        public void RunSelectedNews(object nSelectItem)
        {
            if (null == nSelectItem) return;
            if (mTextNews == nSelectItem) return;
            mTextNews = (ImageNews)nSelectItem;
            this.RunSelected(mTextNews);
        }

        public void ResetSelectNews()
        {
            mTextNews = null;
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

            SelectedNewsCommand = new Command(RunSelectedNews);
        }

        protected List<ImageNews> mImageNewsList;
        protected INavigation mNavigation;
    }
}
