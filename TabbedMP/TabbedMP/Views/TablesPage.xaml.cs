using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabbedMP.Models;
using TabbedMP.ViewModels;
using TabbedMP.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabbedMP.Views
{
    public partial class TablesPage : ContentPage
    {
        TablesViewModel _viewModel;

        public TablesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TablesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}