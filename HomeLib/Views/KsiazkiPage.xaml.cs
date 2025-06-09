using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLib.ViewModels;
using HomeLib.Models;


namespace HomeLib.Views;

public partial class KsiazkiPage : ContentPage
{
    public KsiazkiPage()
    {
        InitializeComponent();
        BindingContext = new KsiazkiViewModel();
    }

    private async void OnDodajKsiazkeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DodajKsiazkePage());
    }

    private async void OnDodajClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DodajKsiazkePage((KsiazkiViewModel)BindingContext));
    }

    private async void OnSzukajGoogleClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is string tytul)
        {
            var query = Uri.EscapeDataString(tytul);
            var url = $"https://www.google.com/search?q={query}";
            await Launcher.Default.OpenAsync(url);
        }
    }
    private async void OnEdytujClicked(object sender, EventArgs e)
    {
        var ksiazka = (sender as Button)?.CommandParameter as Ksiazka;
        if (ksiazka != null)
        {
            await Navigation.PushAsync(new DodajKsiazkePage((KsiazkiViewModel)BindingContext, ksiazka));
        }
    }

}
