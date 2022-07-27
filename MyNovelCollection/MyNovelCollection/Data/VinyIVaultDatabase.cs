using MyNovelCollection.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyNovelCollection.Data
{
    public class VinyIVaultDatabase
    {
        //readonly means only once can assign value to database variable inside constructor
        readonly SQLiteAsyncConnection database;

        public VinyIVaultDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<NovelModel>().Wait();
        }

        public async Task<List<NovelModel>> GetNovelsAsync()
        {
            return await database.Table<NovelModel>().ToListAsync();
        }

        public async Task<int> InsertNovel(NovelModel nm)
        {
            await database.InsertAsync(nm);
            int ret = 1;
            return ret;
        }

        public async Task<int> DeleteNovel(NovelModel nm)
        {
            await database.ExecuteScalarAsync<NovelModel>("DELETE FROM [NovelModel] WHERE TITLE = ?", nm.Title);
            int ret = 1;
            return ret;

        }

        public async Task<int> UpdateNovel(NovelModel nm) 
        {
            await database.ExecuteScalarAsync<NovelModel>("UPDATE [NovelModel] SET AUTHOR = ?, THUMB = ?, DESCRIPTION = ?, LOCATION = ? WHERE TITLE = ?", nm.Author, nm.Thumb, nm.Description, nm.Location,nm.Title);
            int ret = 1;
            return ret;

        }

        public async Task<int> ClearNovels()
        {
            await database.ExecuteScalarAsync<NovelModel>("DELETE FROM [NovelModel]");
            int ret = 1;
            return ret;
        }
        public async Task<int> Count()
        {
           
              return  await database.Table<NovelModel>().CountAsync();
           
        }
    }
}
