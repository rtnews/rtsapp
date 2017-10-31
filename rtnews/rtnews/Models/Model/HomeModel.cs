using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace rtnews
{
    public class HomeModel
    {
        async void RunSelected(ImageNews nImageNews)
        {
            var infoPage = new InfoPage(nImageNews);
            var navPage = new NavigationPage(infoPage);
            await mNavigation.PushModalAsync(navPage);
        }

        public ICommand SelectedNewsCommand { get; set; }

        public void RunSelectedNews(object nSelectItem)
        {
            if (null == nSelectItem) return;
            mTextNews = (ImageNews)nSelectItem;
            this.RunSelected(mTextNews);
        }
        ImageNews mTextNews;

        void LoadValues()
        {
            var homeRep = HomeRep.Instance();
            if (mImageNewsList.Count < 4)
            {
                mImageNewsList.Clear();

                var values = homeRep.Get(0, 4);
                foreach (var i in values)
                {
                    mImageNewsList.Add(i);
                }
            }
            var values1 = homeRep.Get(mTextNewsList.Count, 15);
            foreach (var i in values1)
            {
                mTextNewsList.Add(i);
            }
        }

        public List<ImageNews> ImageNewsList
        {
            get
            {
                return mImageNewsList;
            }
        }

        public List<ImageNews> TextNewsList
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

        public HomeModel()
        {
            mImageNewsList = new List<ImageNews>();
            mTextNewsList = new List<ImageNews>();

            SelectedNewsCommand = new Command(RunSelectedNews);

            this.LoadValues();
        }

        List<ImageNews> mImageNewsList;
        List<ImageNews> mTextNewsList;

        INavigation mNavigation;
    }
}
