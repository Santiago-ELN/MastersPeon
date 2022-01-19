using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TabbedMP.Models;
using TabbedMP.Views;
using Xamarin.Forms;

namespace TabbedMP.ViewModels
{
    [QueryProperty(nameof(ItemId),nameof(Name))]
    public class TableDetailsViewModel : BaseViewModel
    {
        public Command Del { get; }
        public TableDetailsViewModel()
        {
            Del = new Command(Delete);
        }
        private int itemId;
        private string text;
        public string Name
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
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
        public int modCON { get; set; }
        public int modDEX { get; set; }
        public int modSTR { get; set; }
        public int modWIS { get; set; }
        public int modCHAR { get; set; }
        public int modINTEL { get; set; }
        public int HP_temp { get; set; }
        public int HP_max { get; set; }
        public int HP_curr { get; set; }
        public string HP_dice { get; set; }
        public int Speed { get; set; }
        public int Armor_class { get; set; }
        public int Proff_bonus { get; set; }
        public eTag Tag { get; set; }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                itemId = item.ID;
                Name = item.Name;
                Race = item.Race;
                Klass = item.Klass;
                Level = item.Level;
                EXP = item.EXP;
                CON = item.CON;
                DEX = item.DEX;
                STR = item.STR;
                CHA = item.CHA;
                WIS = item.WIS;
                INTEL = item.INTEL;
                HP_curr = item.HP_curr;
                HP_max = item.HP_max;
                Speed = item.Speed;
                Armor_class = item.Armor_class;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void Delete()
        {
            int conf = await DataStore.DeleteItemAsync(itemId);

            if (conf != 0)
            {
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                Delete();
            }
        }

    }
}
