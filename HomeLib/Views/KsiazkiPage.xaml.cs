using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeLib.ViewModels;

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


}
