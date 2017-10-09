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

            nSerialize.RunStream(mDutyInfo, "DutyInfo");
        }

        public void RunInit()
        {
            var homeRep = HomeRep.Instance();
            homeRep.RunInit(mImageNewsList);

            var news0Rep = News0Rep.Instance();
            news0Rep.RunInit(mImageNews0List);

            var news1Rep = News0Rep.Instance();
            news1Rep.RunInit(mImageNews1List);

            var dutyRep = DutyRep.Instance();
            dutyRep.RunInit(mDutyInfo);
        }

        List<ImageNews> mImageNewsList = new List<ImageNews>();
        List<ImageNews> mImageNews0List = new List<ImageNews>();
        List<ImageNews> mImageNews1List = new List<ImageNews>();

        DutyInfo mDutyInfo = new DutyInfo();
    }
}
