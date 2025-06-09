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

        private List<Ksiazka> _wszystkieKsiazki = new();
        public ObservableCollection<Ksiazka> Ksiazki { get; set; } = new();
        KsiazkaDatabase _db;

        //
        private string _szukajTekst = string.Empty;
        public string SzukajTekst
        {
            get => _szukajTekst;
            set
            {
                if (_szukajTekst != value)
                {
                    _szukajTekst = value;
                    OnPropertyChanged(nameof(SzukajTekst));
                    FiltrujKsiazki();
                }
            }
        }


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
            _wszystkieKsiazki = (await _db.GetKsiazkiAsync()).ToList();

            FiltrujKsiazki();
        }


        private void FiltrujKsiazki()
        {
            var filtr = SzukajTekst?.ToLower() ?? "";
            Ksiazki.Clear();
            var filtrowane = _wszystkieKsiazki
            .Where(ks => ks.Tytul.ToLower().Contains(filtr) || ks.Autor.ToLower().Contains(filtr));

            foreach (var ks in filtrowane)
            {
                Ksiazki.Add(ks);
            }
        }



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
                Ksiazki.Remove(ksiazka);
            }
        }

        public async Task DodajLubZaktualizujKsiazke(Ksiazka staraKsiazka, string tytul, string autor, int rok)
        {
            if (staraKsiazka == null)
            {
                await DodajKsiazke(tytul, autor, rok);
            }
            else
            {
                staraKsiazka.Tytul = tytul;
                staraKsiazka.Autor = autor;
                staraKsiazka.RokWydania = rok;
                await _db.SaveKsiazkaAsync(staraKsiazka);
                await ZaladujKsiazki();
            }
        }






    }
}
