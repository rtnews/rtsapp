using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace rtnews
{
    public abstract class NewsModel : ObservableObject, IDataModel
    {
        public abstract string InfoTitle { get; }

        public void RunRefresh()
        {
            Device.BeginInvokeOnMainThread(() => {
                this.RunRefreshNews();
                if (IsRefreshing)
                {
                    IsRefreshing = false;
                }
            });
        }

        public abstract void RunLoading();

        public virtual void OnAppearing()
        {
            mTextNews = null;
        }

        public void RunRefreshCommand(object sender)
        {
            this.OnAppearing();
        }

        public ICommand RefreshNewsCommand { get; set; }

        protected abstract void RunRefreshNews();

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

        public abstract void RunUpdateRead(string nId);

        async void RunSelected(ImageNews nImageNews)
        {
            this.RunUpdateRead(nImageNews.ID);
            nImageNews.Read++;

            var infoPage = new InfoPage(nImageNews);
            infoPage.InfoTitle = this.InfoTitle;
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

        public abstract void RunLoadCommand(object sender);

        public ICommand LoadNewsCommand { get; set; }

        public ObservableCollection<ImageNews> TextNewsList
        {
            get;
            set;
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
            TextNewsList = new ObservableCollection<ImageNews>();

            IsRefreshing = false;

            IsShow = false;

            SelectedNewsCommand = new Command(RunSelectedCommand);
            LoadNewsCommand = new Command(RunLoadCommand);
            RefreshNewsCommand = new Command(RunRefreshCommand);
        }

        protected INavigation mNavigation;

        ImageNews mTextNews;
    }
}
