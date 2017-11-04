using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class StartRep : Repository<StartRep>
    {
        public override void Serialize(ISerialize nSerialize)
        {
            var startResult = new StartResult();
            startResult.Serialize(nSerialize);
            startResult.RunInit();
        }

        public override void RunInit()
        {
            var homeRep = HomeRep.Instance();
            homeRep.RunInit();

            var news0Rep = News0Rep.Instance();
            news0Rep.RunInit();

            var news1Rep = News1Rep.Instance();
            news1Rep.RunInit();

            var dutyRep = DutyRep.Instance();
            dutyRep.RunInit();

            if (homeRep.NeedRefresh() || news0Rep.NeedRefresh()
                || news1Rep.NeedRefresh() || dutyRep.NeedRefresh())
            {
                //this.RunRefreshValue();
            }
        }

        protected override string GetUrl()
        {
            return "api/news/GetStartRep";
        }

        public override string StreamName()
        {
            return "StartRep.json";
        }
    }
}
