using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLib.Models;
using SQLite;



namespace HomeLib.Services
{
    public class KsiazkaDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public KsiazkaDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "biblioteka.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Ksiazka>().Wait();
        }

        public Task<List<Ksiazka>> GetKsiazkiAsync()
        {
            return _database.Table<Ksiazka>().ToListAsync();
        }

        public Task<int> SaveKsiazkaAsync(Ksiazka ksiazka)
        {
            if (ksiazka.Id != 0)
                return _database.UpdateAsync(ksiazka);
            else
                return _database.InsertAsync(ksiazka);
        }

        public Task<int> DeleteKsiazkaAsync(Ksiazka ksiazka)
        {
            return _database.DeleteAsync(ksiazka);
        }
    }
}
