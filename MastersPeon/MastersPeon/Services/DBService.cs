using MastersPeon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastersPeon.Services
{
    public class DBService : IDataStore<eBase>
    {
        readonly List<eBase> items;

        public DBService()
        {
            items = new List<eBase>()
            {
                new eBase { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new eBase { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new eBase { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new eBase { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new eBase { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new eBase { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(eBase item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(eBase item)
        {
            var oldItem = items.Where((eBase arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((eBase arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<eBase> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<eBase>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}