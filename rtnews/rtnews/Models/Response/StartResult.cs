using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class StartResult
    {
        public void Serialize(ISerialize nSerialize)
        {
            nSerialize.RunStream(mImageNewsList, "HomeList", "ImageNews");
            nSerialize.RunStream(mImageNews0List, "News0List", "ImageNews");
            nSerialize.RunStream(mImageNews1List, "News1List", "ImageNews");

            nSerialize.RunStream(mDpartList, "Dparts", "Dpart");
        }

        public void RunInit()
        {
            var homeRep = HomeRep.Instance();
            homeRep.RunInit(mImageNewsList);

            var news0Rep = News0Rep.Instance();
            news0Rep.RunInit(mImageNews0List);

            var news1Rep = News1Rep.Instance();
            news1Rep.RunInit(mImageNews1List);

            var dutyRep = DutyRep.Instance();
            dutyRep.RunInit(mDpartList);
        }

        List<ImageNews> mImageNewsList = new List<ImageNews>();
        List<ImageNews> mImageNews0List = new List<ImageNews>();
        List<ImageNews> mImageNews1List = new List<ImageNews>();

        List<Dpart> mDpartList = new List<Dpart>();
    }
}
