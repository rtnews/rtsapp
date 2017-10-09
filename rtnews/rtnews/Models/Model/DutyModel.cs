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

        string mDutyName;
        string mDutyPart;
        int mDutyId;
    }
}
