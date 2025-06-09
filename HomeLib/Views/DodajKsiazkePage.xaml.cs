using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLib.Models;
using HomeLib.ViewModels;
using Microsoft.Maui.Controls;

namespace HomeLib.Views
{
    public partial class DodajKsiazkePage : ContentPage
    {
        KsiazkiViewModel _viewModel;
        private Ksiazka? _edytowanaKsiazka;


        public DodajKsiazkePage(KsiazkiViewModel viewModel, Ksiazka ksiazka = null)
        {
            InitializeComponent();
            _viewModel = viewModel;

            if (ksiazka != null)
            {
                _edytowanaKsiazka = ksiazka;
                TytulEntry.Text = _edytowanaKsiazka.Tytul;
                AutorEntry.Text = _edytowanaKsiazka.Autor;
                RokEntry.Text = _edytowanaKsiazka.RokWydania.ToString();
            }
        }

        private async void OnZapiszClicked(object sender, EventArgs e)
        {
            string tytul = TytulEntry.Text?.Trim();
            string autor = AutorEntry.Text?.Trim();
            bool rokOK = int.TryParse(RokEntry.Text, out int rok);

            if (string.IsNullOrWhiteSpace(tytul) || string.IsNullOrWhiteSpace(autor) || !rokOK)
            {
                await DisplayAlert("Błąd", "Uzupełnij wszystkie pola poprawnie.", "OK");
                return;
            }

            await _viewModel.DodajLubZaktualizujKsiazke(_edytowanaKsiazka, tytul, autor, rok);
            //await _viewModel.DodajKsiazke(tytul, autor, rok);
            await Navigation.PopAsync();
        }

        public DodajKsiazkePage() : this(new KsiazkiViewModel())
        {
        }

        private async void OnAnulujClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}