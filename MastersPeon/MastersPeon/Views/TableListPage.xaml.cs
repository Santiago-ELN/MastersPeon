using MastersPeon.Models;
using MastersPeon.ViewModels;
using MastersPeon.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MastersPeon.Views
{
    public partial class TableListPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public TableListPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}