using System.ComponentModel;
using System.Threading.Tasks;
using TabbedMP.ViewModels;
using Xamarin.Forms;

namespace TabbedMP.Views
{
    [QueryProperty("ItemID", "Name")]
    public partial class TableDetailsPage : ContentPage
    {
        public TableDetailsPage()
        {
            InitializeComponent();
            
            BindingContext = new TableDetailsViewModel();
        }
    }
}