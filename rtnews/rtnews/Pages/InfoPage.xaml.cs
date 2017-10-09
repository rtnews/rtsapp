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
    public partial class InfoPage : ContentPage
    {
        public InfoPage(ImageNews nImageNews)
        {
            InitializeComponent();

            mListView.BindingContext = new InfoModel(nImageNews);
        }
    }
}