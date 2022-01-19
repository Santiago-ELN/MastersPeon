using MastersPeon.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MastersPeon.Views
{
    public partial class TableDetailsPage : ContentPage
    {
        public TableDetailsPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}