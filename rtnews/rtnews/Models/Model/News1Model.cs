using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class News1Model : NewsModel
    {
        void LoadValues()
        {
            var homeRep = News1Rep.Instance();
            var values = homeRep.Get(mImageNewsList.Count, 15);
            foreach (var i in values)
            {
                mImageNewsList.Add(i);
            }
        }

        public News1Model()
        {
            this.LoadValues();
        }
    }
}
