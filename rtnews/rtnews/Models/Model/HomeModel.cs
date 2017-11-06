using rtnews.Strings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace rtnews
{
    public class HomeModel : ObservableObject, IDataModel
    {
        private void OnImageClick(object sender, EventArgs e)
        {
            this.RunSelectedCommand(sender);
        }

        public void RunRefresh(bool nRefresh)
        {
            Device.BeginInvokeOnMainThread(() => {
                if (!nRefresh)
                {
                    var error = StringTable.RefreshError;
                    AlertEngine.Instance().ShowShort(error);
                }
                else
                {
                    var homeRep = HomeRep.Instance();
                    homeRep.RunSave();

                    this.RunRefreshNews();
                }
                if (IsRefreshing)
                {
                    IsRefreshing = false;
                }
            });
        }

        public void RunLoading()
        {
            Device.BeginInvokeOnMainThread(() => {
                var homeRep = HomeRep.Instance();
                var count = ImageNewsList.Count;
                count += TextNewsList.Count;
                var textNews = homeRep.Get(count, 15);
                foreach (var i in textNews)
                {
                    TextNewsList.Add(i);
                }
            });
        }

        public void OnAppearing()
        {
            mTextNews = null;

            var homeRep = HomeRep.Instance();
            if (homeRep.NeedRefresh())
            {
                homeRep.RunRefreshValue();
            }
            else
            {
                if (IsRefreshing)
                {
                    IsRefreshing = false;
                }
            }
        }

        public void RunRefreshCommand(object sender)
        {
            this.OnAppearing();
        }

        private void RunRefreshNews()
        {
            foreach (var i in ImageNewsList)
            {
                i.ImageClickEvent -= OnImageClick;
            }

            ImageNewsList.Clear();
            TextNewsList.Clear();

            var homeRep = HomeRep.Instance();
            var imageNews = homeRep.Get(0, 5);
            foreach (var i in imageNews)
            {
                i.RunInit();
                i.ImageClickEvent += OnImageClick;
                ImageNewsList.Add(i);
            }

            var textNews = homeRep.Get(5, 10);
            foreach (var i in textNews)
            {
                TextNewsList.Add(i);
            }

            if (ImageNewsList.Count < 1)
            {
                IsShow = false;
            }
            else
            {
                IsShow = true;
            }
        }

        public bool IsShow
        {
            get
            {
                return mIsShow;
            }
            set
            {
                if (mIsShow == value)
                {
                    return;
                }
                mIsShow = value;
                this.OnPropertyChanged("IsHide");
                this.OnPropertyChanged("IsShow");
            }
        }
        public bool IsHide
        {
            get
            {
                return (!mIsShow);
            }
        }
        bool mIsShow = false;

        public bool IsRefreshing
        {
            get
            {
                return mIsRefreshing;
            }
            set
            {
                if (mIsRefreshing == value)
                {
                    return;
                }
                mIsRefreshing = value;
                this.OnPropertyChanged("IsRefreshing");
            }
        }
        bool mIsRefreshing = false;

        public ICommand RefreshNewsCommand { get; set; }

        async void RunSelected(ImageNews nImageNews)
        {
            var homeRep = HomeRep.Instance();
            homeRep.RunUpdateRead(nImageNews.ID);
            nImageNews.Read++;

            var infoPage = new InfoPage(nImageNews);
            infoPage.InfoTitle = StringTable.News0;
            await mNavigation.PushAsync(infoPage);
        }

        public void RunSelectedCommand(object nSelectItem)
        {
            if (null == nSelectItem) return;
            if (mTextNews == nSelectItem) return;
            mTextNews = (ImageNews)nSelectItem;
            this.RunSelected(mTextNews);
        }

        public ICommand SelectedNewsCommand { get; set; }

        public void RunLoadCommand(object sender)
        {
            var homeRep = HomeRep.Instance();
            var count = ImageNewsList.Count;
            count += TextNewsList.Count;
            homeRep.RunLoadNews(count);
        }

        public ICommand LoadNewsCommand { get; set; }

        public ObservableCollection<ImageNews> ImageNewsList
        {
            get;set;
        }

        public ObservableCollection<ImageNews> TextNewsList
        {
            get; set;
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
            ImageNewsList = new ObservableCollection<ImageNews>();
            TextNewsList = new ObservableCollection<ImageNews>();

            IsRefreshing = false;

            IsShow = false;

            SelectedNewsCommand = new Command(RunSelectedCommand);
            LoadNewsCommand = new Command(RunLoadCommand);
            RefreshNewsCommand = new Command(RunRefreshCommand);

            var homeRep = HomeRep.Instance();
            homeRep.SetDataModel(this);

            this.RunRefreshNews();
        }

        INavigation mNavigation;

        ImageNews mTextNews;
    }
}
