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
            if (SerializeType.Refresh == LoadType)
            {
                mDpartList.Clear();
                var dpartList = new List<Dpart>();
                nSerialize.RunStream(dpartList, "Dparts", "Dpart");
                mDpartList.AddRange(dpartList);
            }
            else
            {
                nSerialize.RunStream(mDpartList, "Dparts", "Dpart");
            }
            base.Serialize(nSerialize);
        }

        public override string StreamName()
        {
            return "DutyRep.json";
        }

        protected override string GetUrl()
        {
            return "api/dpart/GetDutyRep";
        }

        public Dpart GetLeader()
        {
            if (mDpartList.Count < 1)
            {
                return null;
            }
            return mDpartList[0];
        }

        public Dpart GetDpart()
        {
            if (mDpartList.Count < 2)
            {
                return null;
            }
            return mDpartList[1];
        }

        public void RunInit(List<Dpart> nDeparts)
        {
            mDpartList.Clear();

            foreach (var i in nDeparts)
            {
                mDpartList.Add(i);
            }
            mUpdateTime = DateTime.Now;

            //this.RunSave();
        }

        List<Dpart> mDpartList = new List<Dpart>();
    }
}
