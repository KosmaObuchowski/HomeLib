using Microsoft.Maui.Controls;
using HomeLib.Views;

namespace HomeLib;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }
}

