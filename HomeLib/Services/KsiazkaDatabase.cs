using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLib.Models;
using SQLite;
using Microsoft.EntityFrameworkCore;


namespace HomeLib.Services
{
    public class KsiazkaDatabase
    {
        public KsiazkaDatabase()
        {
            using var db = new KsiazkaContext();
            db.Database.EnsureCreated();
        }

        public async Task<List<Ksiazka>> GetKsiazkiAsync()
        {
            using var db = new KsiazkaContext();
            return await db.Ksiazki.ToListAsync();
        }

        public async Task SaveKsiazkaAsync(Ksiazka ksiazka)
        {
            using var db = new KsiazkaContext();
            if (ksiazka.Id != 0)
                db.Ksiazki.Update(ksiazka);
            else
                db.Ksiazki.Add(ksiazka);

            await db.SaveChangesAsync();
        }

        public async Task DeleteKsiazkaAsync(Ksiazka ksiazka)
        {
            using var db = new KsiazkaContext();
            db.Ksiazki.Remove(ksiazka);
            await db.SaveChangesAsync();
        }
    }
}
