using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace rtnews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            NewsModel newsModel = (NewsModel)BindingContext;
            newsModel.ResetSelectNews();

            base.OnAppearing();
        }
    }
}
