using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TabbedMP.Models;
using TabbedMP.Views;
using Xamarin.Forms;

namespace TabbedMP.ViewModels
{
    public class TablesViewModel : BaseViewModel
    {
        private Entity _selectedItem;

        public ObservableCollection<Entity> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Entity> ItemTapped { get; }

        public TablesViewModel()
        {
            Title = "Fichas";
            Items = new ObservableCollection<Entity>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Entity>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Entity SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTablePage));
        }

        async void OnItemSelected(Entity item)
        {
            if (item == null)
                return;

            // This will push the TableDetailsPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(TableDetailsPage)}?{nameof(TableDetailsViewModel.ItemId)}={item.ID}");
        }
    }
}