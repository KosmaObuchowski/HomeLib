using Microsoft.Maui.Controls;
using HomeLib.Views;
using HomeLib.ViewModels;

namespace HomeLib;



public partial class MainPage : ContentPage
{

    private KsiazkiViewModel _viewModel = new KsiazkiViewModel();

    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnKsiazkiClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DodajKsiazkePage(_viewModel));
    }

    private async void OnDodajKsiazkeClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new KsiazkiPage());
    }
}
