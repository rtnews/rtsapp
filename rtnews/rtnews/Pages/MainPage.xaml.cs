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
        public MainPage()
        {
            InitializeComponent();

            var homeModel = new HomeModel();
            homeModel.Navigation = Navigation;
            mHomePage.BindingContext = homeModel;

            var new0Model = new News0Model();
            new0Model.Navigation = Navigation;
            mNewPage0.BindingContext = new0Model;

            var new1Model = new News1Model();
            new1Model.Navigation = Navigation;
            mNewPage1.BindingContext = new1Model;

            var dutyModel = new DutyModel();
            dutyModel.Navigation = Navigation;
            mDutyPage.BindingContext = dutyModel;
        }
    }
}
