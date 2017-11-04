using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rtnews
{
    public class DutyModel : ObservableObject, IDataModel
    {
        public void RunRefresh()
        {
            Device.BeginInvokeOnMainThread(() => {
                this.RunRefreshDutys();
            });
        }

        public void RunLoading()
        {
        }

        public void OnAppearing()
        {
            var dutyRep = DutyRep.Instance();
            dutyRep.RunRefreshValue();
        }

        private void RunRefreshDutys()
        {
            var dutyRep = DutyRep.Instance();
            Leader = dutyRep.GetLeader();
            Duty = dutyRep.GetDpart();
            if (null != Leader)
            {
                var config = UConfig.Instance();
                mDutyUrl = config.ApiUrl + "Upload/Clerk/";
                mDutyUrl += Leader.Icon;
                mDutyUrl += ".png";
                this.OnPropertyChanged("DutyUrl");
            }

            if ((null != Leader) 
                && (null != Duty))
            {
                IsShow = true;

                this.OnPropertyChanged("Leader");
                this.OnPropertyChanged("Duty");
            }
            else
            {
                IsShow = false;
            }
        }

        public bool IsShow
        {
            get
            {
                return mIsShow;
            }
            set
            {
                if (mIsShow == value)
                {
                    return;
                }
                mIsShow = value;
                this.OnPropertyChanged("IsHide");
                this.OnPropertyChanged("IsShow");
            }
        }
        public bool IsHide
        {
            get
            {
                return (!mIsShow);
            }
        }
        bool mIsShow = false;

        public string DutyUrl
        {
            get
            {
                return mDutyUrl;
            }
        }

        public Dpart Leader
        {
            get;
            set;
        }

        public Dpart Duty
        {
            get;
            set;
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
            var dutyRep = DutyRep.Instance();
            dutyRep.SetDataModel(this);

            this.RunRefreshDutys();
        }

        INavigation mNavigation;

        string mDutyUrl;
    }
}
