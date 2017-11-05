using rtnews.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rtnews
{
    public class News0Model : NewsModel
    {
        public override string InfoTitle
        {
            get
            {
                return StringTable.News1;
            }
        }

        public override void RunLoading()
        {
            Device.BeginInvokeOnMainThread(() => {
                var news0Rep = News0Rep.Instance();
                var count = TextNewsList.Count;
                var textNews = news0Rep.Get(count, 15);
                foreach (var i in textNews)
                {
                    TextNewsList.Add(i);
                }
            });
        }

        public override void OnAppearing()
        {
            base.OnAppearing();

            var news0Rep = News0Rep.Instance();
            if (news0Rep.NeedRefresh())
            {
                news0Rep.RunRefreshValue();
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
            TextNewsList.Clear();

            var news0Rep = News0Rep.Instance();
            var news = news0Rep.Get(0, 15);
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
            var news0Rep = News0Rep.Instance();
            news0Rep.RunUpdateRead(nId);
        }

        public override void RunLoadCommand(object sender)
        {
            var news0Rep = News0Rep.Instance();
            news0Rep.RunLoadNews(TextNewsList.Count);
        }

        public News0Model()
        {
            var news0Rep = News0Rep.Instance();
            news0Rep.SetDataModel(this);

            this.RunRefreshNews();
        }
    }
}
