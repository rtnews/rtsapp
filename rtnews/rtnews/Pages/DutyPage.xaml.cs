﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace rtnews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DutyPage : ContentPage
    {
        public DutyPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            DutyModel dutyModel = (DutyModel)BindingContext;
            dutyModel.OnAppearing();

            base.OnAppearing();
        }
    }
}