using System.ComponentModel;
using TempMP.ViewModels;
using Xamarin.Forms;

namespace TempMP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}