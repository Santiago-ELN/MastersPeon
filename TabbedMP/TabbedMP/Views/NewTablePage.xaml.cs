using System;
using System.Collections.Generic;
using System.ComponentModel;
using TabbedMP.Models;
using TabbedMP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMP.Views
{
    public partial class NewTablePage : ContentPage
    {
        public Entity Item { get; set; }

        public NewTablePage()
        {
            InitializeComponent();
            BindingContext = new NewTableViewModel();
        }
    }
}