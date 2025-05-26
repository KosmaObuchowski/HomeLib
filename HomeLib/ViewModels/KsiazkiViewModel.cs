using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using HomeLib.Models;
using HomeLib.Services;
using System.Collections.ObjectModel;


namespace HomeLib.ViewModels
{
    public class KsiazkiViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Ksiazka> Ksiazki { get; set; } = new();
        KsiazkaDatabase _db;

        public ICommand OdswiezCommand { get; }

        public KsiazkiViewModel()
        {
            _db = new KsiazkaDatabase();
            OdswiezCommand = new Command(async () => await ZaladujKsiazki());
            ZaladujKsiazki().Wait();
        }

        public async Task ZaladujKsiazki()
        {
            var lista = await _db.GetKsiazkiAsync();
            Ksiazki.Clear();
            foreach (var ks in lista)
                Ksiazki.Add(ks);
        }

        // dod i usun.
    }

}
