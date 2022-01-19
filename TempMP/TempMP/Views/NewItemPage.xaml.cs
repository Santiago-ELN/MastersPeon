using System;
using System.Collections.Generic;
using System.ComponentModel;
using TempMP.Models;
using TempMP.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempMP.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}