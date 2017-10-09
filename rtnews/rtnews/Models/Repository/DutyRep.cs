using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class DutyRep : Repository<DutyRep>
    {
        public override void Serialize(ISerialize nSerialize)
        {
            base.Serialize(nSerialize);

            nSerialize.RunStream(mDutyInfo, "DutyInfo");
        }

        public override string StreamName()
        {
            return "DutyRep.json";
        }

        protected override string GetUrl()
        {
            return "api/news/GetDutyRep";
        }

        public void RunInit(DutyInfo nDutyInfo)
        {
            mDutyInfo = nDutyInfo;

            mUpdateTime = DateTime.Now;

            this.RunSave();
        }

        public DutyInfo DutyInfo
        {
            get
            {
                return mDutyInfo;
            }
        }

        DutyInfo mDutyInfo = new DutyInfo();
    }
}
