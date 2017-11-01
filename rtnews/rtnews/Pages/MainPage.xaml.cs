using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rtnews
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(INavigation navigation)
        {
            InitializeComponent();

            this.BarBackgroundColor = Color.White;
            this.BarTextColor = Color.FromHex("#004080");

            var homeModel = new HomeModel();
            homeModel.Navigation = navigation;
            mHomePage.BindingContext = homeModel;

            var new0Model = new News0Model();
            new0Model.Navigation = navigation;
            mNewPage0.BindingContext = new0Model;

            var new1Model = new News1Model();
            new1Model.Navigation = navigation;
            mNewPage1.BindingContext = new1Model;

            var dutyModel = new DutyModel();
            dutyModel.Navigation = navigation;
            mDutyPage.BindingContext = dutyModel;
        }
    }
}
