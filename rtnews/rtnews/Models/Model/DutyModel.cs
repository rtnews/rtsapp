using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rtnews
{
    public class DutyModel : ObservableObject
    {
        void LoadValues()
        {
            var dutyRep = DutyRep.Instance();
            var leader = dutyRep.GetLeader();
            var dpart = dutyRep.GetDpart();
            if (null != leader)
            {
                var config = UConfig.Instance();
                mDutyUrl = config.ApiUrl + "Upload/Clerk/";
                mDutyUrl += leader.Icon;
                mDutyUrl += ".png";

                mLeaderId = leader.ClerkId;
                mLeaderName = leader.Name;
                mLeaderPart = leader.Depart;
                mLeaderPhone = leader.Phone;
            }
            if (dpart != null)
            {
                mDutyId = dpart.ClerkId;
                mDutyName = dpart.Name;
                mDutyPart = dpart.Depart;
                mDutyPhone = dpart.Phone;
            }
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

        public string LeaderPhone
        {
            get
            {
                return mLeaderPhone;
            }
        }

        public string DutyId
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

        public string DutyPhone
        {
            get
            {
                return mDutyPhone;
            }
        }

        public INavigation Navigation
        {
            get
            {
                return mNavigation;
            }
            set
            {
                mNavigation = value;
            }
        }

        public DutyModel()
        {
            this.LoadValues();
        }

        INavigation mNavigation;

        string mDutyUrl;

        string mLeaderId;
        string mLeaderName;
        string mLeaderPart;
        string mLeaderPhone;

        string mDutyName;
        string mDutyPart;
        string mDutyId;
        string mDutyPhone;
    }
}
