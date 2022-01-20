using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MastersPeon.Models;
using SQLitePCL;
using SQLite;
using Xamarin.Essentials;
using System.IO;
using System.Diagnostics;

namespace MastersPeon.Services
{
    public class DBService : IDataStore<eBase>
    {
        static SQLiteAsyncConnection db;
        /// <summary>
        /// DONE
        /// </summary>
        /// <returns></returns>
        static async Task Init()
        {
            var databasepath = Path.Combine(FileSystem.AppDataDirectory, "MastersPeon.db");
            db = new SQLiteAsyncConnection(databasepath);

            await db.CreateTableAsync<eBase>().ContinueWith((results) =>
            {
                Debug.WriteLine("Table created");
            });
        }
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
        /// <summary>
        /// DONE
        /// </summary>
        /// <param name="name"></param>
        /// <param name="klass"></param>
        /// <param name="level"></param>
        /// <param name="exp"></param>
        /// <param name="con"></param>
        /// <param name="dex"></param>
        /// <param name="str"></param>
        /// <param name="wis"></param>
        /// <param name="cha"></param>
        /// <param name="intel"></param>
        /// <param name="hp_temp"></param>
        /// <param name="hp_max"></param>
        /// <param name="hp_dice"></param>
        /// <param name="speed"></param>
        /// <param name="armor_class"></param>
        /// <param name="prof"></param>
        /// <param name="tag"></param>
        /// <param name="race"></param>
        /// <returns></returns>
        public async Task<int> AddItemAsync(string name, string klass, int level, int exp, int con, int dex, int str, int wis, int cha, int intel, int hp_temp, int hp_max, string hp_dice, int speed, int armor_class, int prof, eTag tag, string race)
        {
            await Init();
            eBase newent = new eBase()
            {
                Name = name,
                Klass = klass,
                Level = level,
                EXP = exp,
                CON = con,
                DEX = dex,
                STR = str,
                WIS = wis,
                CHA = cha,
                INTEL = intel,
                HP_temp = hp_temp,
                HP_max = hp_max,
                HP_curr = hp_max,
                HP_dice = hp_dice,
                Speed = speed,
                Armor_class = armor_class,
                Proff_bonus = prof,
                Tag = tag,
                Race = race,
            };

            return await db.InsertAsync(newent);
        }
        /// <summary>
        /// DONE
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> UpdateItemAsync(eBase item)
        {
            await Init();
            return await db.UpdateAsync(item);
        }
        /// <summary>
        /// DONE
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> DeleteItemAsync(eBase item)
        {
            return await db.DeleteAsync(item);
        }

        public async Task<eBase> GetItemAsync(int id)
        {
            return await db.FindAsync<eBase>(id);
        }

        public async Task<IEnumerable<eBase>> GetItemsAsync(bool forceRefresh = false)
        {
            return await db.Table<eBase>().ToListAsync();
        }
    }
}