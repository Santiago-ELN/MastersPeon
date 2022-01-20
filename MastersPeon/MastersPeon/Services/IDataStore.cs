using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MastersPeon.Models;

namespace MastersPeon.Services
{
    public interface IDataStore<T>
    {
        Task<int> AddItemAsync(string name, string klass, int level, int exp, int con, int dex, int str, int wis, int cha, int intel, int hp_temp, int hp_max, string hp_dice, int speed, int armor_class, int prof, eTag tag, string race);
        Task<int> UpdateItemAsync(T item);
        Task<int> DeleteItemAsync(T item);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
