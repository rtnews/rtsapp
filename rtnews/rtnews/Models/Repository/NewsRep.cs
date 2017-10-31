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

        public override void Serialize(ISerialize nSerialize)
        {
            nSerialize.RunStream(mImageNewsList, "ImageNewsList", "ImageNews");
        }

        public virtual void RunInit(List<ImageNews> nImageNewsList)
        {
            mImageNewsList.Clear();

            foreach (var i in nImageNewsList)
            {
                mImageNewsList.Add(i);
            }
            mUpdateTime = DateTime.Now;

            //this.RunSave();
        }

        protected List<ImageNews> mImageNewsList = new List<ImageNews>();
    }
}
