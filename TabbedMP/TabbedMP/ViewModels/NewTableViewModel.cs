using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TabbedMP.Models;
using Xamarin.Forms;

namespace TabbedMP.ViewModels
{
    public class NewTableViewModel : BaseViewModel
    {
        private string name;

        public NewTableViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Race { get; set; }
        public string Klass { get; set; }
        public int Level { get; set; }
        public int EXP { get; set; }
        public int CON { get; set; }
        public int DEX { get; set; }
        public int STR { get; set; }
        public int WIS { get; set; }
        public int CHA { get; set; }
        public int INTEL { get; set; }
        public int HP_temp { get; set; }
        public int HP_max { get; set; }
        public string HP_dice { get; set; }
        public int Speed { get; set; }
        public int Armor_class { get; set; }
        public int Proff_bonus { get; set; }
        public eTag Tag { get; set; }
        //public List<Tests> ID_tests { get; set; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Tag = eTag.Player;
            await DataStore.AddItemAsync(name, Klass, Level, EXP, CON, DEX, STR, WIS, CHA, INTEL, HP_temp, HP_max, HP_dice, Speed, Armor_class, Proff_bonus, Tag, Race);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
