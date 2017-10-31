using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class News0Model : NewsModel
    {
        void LoadValues()
        {
            var homeRep = News0Rep.Instance();
            var values = homeRep.Get(mImageNewsList.Count, 15);
            foreach (var i in values)
            {
                mImageNewsList.Add(i);
            }
        }

        public News0Model()
        {
            this.LoadValues();
        }
    }
}
