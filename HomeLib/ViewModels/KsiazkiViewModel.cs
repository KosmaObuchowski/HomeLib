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
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Ksiazka> Ksiazki { get; set; } = new();
        KsiazkaDatabase _db;

        public ICommand OdswiezCommand { get; }
        public ICommand UsunCommand { get; }

        public KsiazkiViewModel()
        {
            _db = new KsiazkaDatabase();
            OdswiezCommand = new Command(async () => await ZaladujKsiazki());
            UsunCommand = new Command<Ksiazka>(async (ks) => await UsunKsiazke(ks));
            ZaladujKsiazki().Wait();
        }

        public async Task ZaladujKsiazki()
        {
            var lista = await _db.GetKsiazkiAsync();
            Ksiazki.Clear();
            foreach (var ks in lista)
                Ksiazki.Add(ks);
        }

        // dodawanie / usuwanie
        public async Task DodajKsiazke(string tytul, string autor, int rok)
        {
            var nowa = new Ksiazka { Tytul = tytul, Autor = autor, RokWydania = rok };
            await _db.SaveKsiazkaAsync(nowa);
            await ZaladujKsiazki();
        }

        public async Task UsunKsiazke(Ksiazka ksiazka)
        {
            if (ksiazka != null)
            {
                await _db.DeleteKsiazkaAsync(ksiazka);
                Ksiazki.Remove(ksiazka); // opcjonalne, ale przyspiesza UI
                // lub await ZaladujKsiazki(); jeśli chcesz zawsze pełne odświeżenie
            }
        }

    }
}
