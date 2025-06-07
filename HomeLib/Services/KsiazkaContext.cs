using HomeLib.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace HomeLib.Services
{
    public class KsiazkaContext : DbContext
    {
        public DbSet<Ksiazka> Ksiazki { get; set; }

        private static string dbPath =>
            //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "biblioteka.db");
            Path.Combine(FileSystem.AppDataDirectory, "HomeLib.db");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Filename={dbPath}");
        }
    }
}