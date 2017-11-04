using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public abstract class NewsRep<T> : Repository<T> where T : new()
    {
        public IEnumerable<ImageNews> Get(int skip, int take)
        {
            return mImageNewsList.Skip(skip).Take(take);
        }

        public abstract string GetReadUrl();

        public void RunUpdateRead(string nId)
        {
            var url = this.GetReadUrl();
            var body = string.Format("{0}{1}{2}", "{\"Id\":\"", nId, "\"}");
            this.RunLoadValue(url, body, 2);
        }

        public abstract string GetLoadUrl();

        public void RunLoadNews(int nCount)
        {
            var count = mImageNewsList.Count - nCount;
            if (count <= 15)
            {
                var url = this.GetLoadUrl();
                var pageId = mImageNewsList.Count / 3;
                var body = string.Format("{0}{1}{2}", "{\"PageId\":", pageId, "}");
                this.RunLoadValue(url, body, 1);
            }
            if (null != mDataModel)
            {
                mDataModel.RunLoading();
            }
        }

        public override void Serialize(ISerialize nSerialize)
        {
            if (SerializeType.Loading == LoadType)
            {
                var newsList = new List<ImageNews>();
                nSerialize.RunStream(newsList, "ImageNewsList", "ImageNews");
                foreach (var i in newsList)
                {
                    mImageNewsList.Add(i);
                }
            }
            else
            {
                nSerialize.RunStream(mImageNewsList, "ImageNewsList", "ImageNews");
            }
            base.Serialize(nSerialize);
        }

        public void RunInit(List<ImageNews> nImageNewsList)
        {
            mImageNewsList.Clear();

            foreach (var i in nImageNewsList)
            {
                mImageNewsList.Add(i);
            }
            mUpdateTime = DateTime.Now;

            this.RunSave();
        }

        List<ImageNews> mImageNewsList = new List<ImageNews>();
    }
}
