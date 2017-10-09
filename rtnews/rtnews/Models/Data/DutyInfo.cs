using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class DutyInfo : IStream
    {
        public void Serialize(ISerialize nSerialize, string nName, sbyte nCount)
        {
            nSerialize.RunNumber(ref mDutyUrl, "DutyUrl");

            nSerialize.RunNumber(ref mLeaderId, "LeaderId");
            nSerialize.RunNumber(ref mLeaderName, "LeaderName");
            nSerialize.RunNumber(ref mLeaderPart, "LeaderPart");

            nSerialize.RunNumber(ref mDutyPart, "DutyPart");
            nSerialize.RunNumber(ref mDutyName, "DutyName");
            nSerialize.RunNumber(ref mDutyId, "DutyId");
        }

        public bool IsDefault()
        {
            return ((0 == mDutyId) || ("" == mDutyName));
        }

        public string DutyUrl
        {
            get
            {
                return mDutyUrl;
            }
        }

        public string LeaderId
        {
            get
            {
                return mLeaderId;
            }
        }

        public string LeaderName
        {
            get
            {
                return mLeaderName;
            }
        }

        public string LeaderPart
        {
            get
            {
                return mLeaderPart;
            }
        }

        public int DutyId
        {
            get
            {
                return mDutyId;
            }
        }

        public string DutyName
        {
            get
            {
                return mDutyName;
            }
        }

        public string DutyPart
        {
            get
            {
                return mDutyPart;
            }
        }

        string mDutyUrl;

        string mLeaderId;
        string mLeaderName;
        string mLeaderPart;

        string mDutyName;
        string mDutyPart;
        int mDutyId;
    }
}
