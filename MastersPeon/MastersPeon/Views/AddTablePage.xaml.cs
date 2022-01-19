using MastersPeon.Models;
using MastersPeon.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MastersPeon.Views
{
    public partial class AddTablePage : ContentPage
    {
        public eBase Item { get; set; }

        public AddTablePage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}