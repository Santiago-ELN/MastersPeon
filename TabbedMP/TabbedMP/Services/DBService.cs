using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabbedMP.Models;
using SQLitePCL;
using SQLite;
using Xamarin.Essentials;
using System.IO;
using System.Diagnostics;

namespace TabbedMP.Services
{
    public class DBService : IDBService<Entity>
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            var databasepath = Path.Combine(FileSystem.AppDataDirectory, "MastersPeon.db");
            db = new SQLiteAsyncConnection(databasepath);
            await db.CreateTableAsync<Entity>().ContinueWith((results) =>
            {
                Debug.WriteLine("table created");
            });
        }

        public async Task<int> AddItemAsync(string name, string klass, int level, int exp, int con, int dex, int str, int wis, int cha, int intel, int hp_temp, int hp_max, string hp_dice, int speed, int armor_class, int prof, eTag tag, string race)
        {
            await Init();
            Entity newent = new Entity()
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

        public async Task<int> UpdateItemAsync(Entity item)
        {
            await Init();
            var results = await db.UpdateAsync(item);
            return results;
        }

        public async Task<int> DeleteItemAsync(int id)
        {
            await Init();

            return await db.DeleteAsync<Entity>(id);
        }

        public async Task<Entity> GetItemAsync(int id)
        {
            await Init();
            var results = await db.FindAsync<Entity>(id);
            return results;
        }

        public async Task<IEnumerable<Entity>> GetItemsAsync(bool forceRefresh = false)
        {
            await Init();
            return await db.Table<Entity>().ToListAsync();
        }
    }
}