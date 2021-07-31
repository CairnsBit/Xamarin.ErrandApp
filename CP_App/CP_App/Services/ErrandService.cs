using CP_App.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CP_App.Services
{
    public static class ErrandService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Errand>();
        }

        public static async Task AddErrand(string name, string description, string category)
        {
            await Init();

            var image = "https://image.pngaaa.com/962/680962-small.png";

            var errand = new Errand 
            {
                Name = name,
                Description = description,
                Category = category,
                Image = image
            };
            var id = await db.InsertAsync(errand);
        }

        public static async Task RemoveErrand(int id)
        {
            await Init();
            await db.DeleteAsync<Errand>(id);
        }

        public static async Task<IEnumerable<Errand>> GetErrand()
        {
            await Init();
            var errand = await db.Table<Errand>().ToListAsync();
            return errand;
        }
    }
}
