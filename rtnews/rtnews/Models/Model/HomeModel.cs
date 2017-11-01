using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace rtnews
{
    public class HomeModel
    {
        private void OnImageClick(object sender, EventArgs e)
        {
            this.RunSelectedNews(sender);
        }

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

        void LoadValues()
        {
            var homeRep = HomeRep.Instance();
            if (mImageNewsList.Count < 4)
            {
                mImageNewsList.Clear();

                var values = homeRep.Get(0, 4);
                foreach (var i in values)
                {
                    i.ImageClickEvent += OnImageClick;
                    mImageNewsList.Add(i);
                }
            }
            var values1 = homeRep.Get(mTextNewsList.Count + 4, 15);
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
