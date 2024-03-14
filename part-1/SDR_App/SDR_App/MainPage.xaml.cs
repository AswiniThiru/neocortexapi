using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace SDR_App;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnNextPageButtonClicked(object sender, EventArgs e)
    {
        // Navigate to the next page
        await Navigation.PushAsync(new Page1());
    }
}
