using rtnews.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rtnews
{
    public class News1Model : NewsModel
    {
        public override string InfoTitle
        {
            get
            {
                return StringTable.News2;
            }
        }

        public override void RunSave()
        {
            var news1Rep = News1Rep.Instance();
            news1Rep.RunSave();
        }

        public override void RunLoading()
        {
            Device.BeginInvokeOnMainThread(() => {
                var news1Rep = News1Rep.Instance();
                var count = TextNewsList.Count;
                var textNews = news1Rep.Get(count, 15);
                foreach (var i in textNews)
                {
                    TextNewsList.Add(i);
                }
            });
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            var news1Rep = News1Rep.Instance();
            if (news1Rep.NeedRefresh())
            {
                news1Rep.RunRefreshValue();
            }
            else
            {
                if (IsRefreshing)
                {
                    IsRefreshing = false;
                }
            }
        }

        protected override void RunRefreshNews()
        {
            var news1Rep = News1Rep.Instance();
            var news = news1Rep.Get(0, 15);
            foreach (var i in news)
            {
                TextNewsList.Add(i);
            }

            if (TextNewsList.Count < 1)
            {
                IsShow = false;
            }
            else
            {
                IsShow = true;
            }
        }

        public override void RunUpdateRead(string nId)
        {
            var news1Rep = News1Rep.Instance();
            news1Rep.RunUpdateRead(nId);
        }

        public override void RunLoadCommand(object sender)
        {
            var news1Rep = News1Rep.Instance();
            news1Rep.RunLoadNews(TextNewsList.Count);
        }

        public News1Model()
        {
            var news1Rep = News1Rep.Instance();
            news1Rep.SetDataModel(this);

            this.RunRefreshNews();
        }
    }
}
