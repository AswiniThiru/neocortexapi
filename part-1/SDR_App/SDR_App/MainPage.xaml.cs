namespace SDR_App;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGoToNextPageButtonClick(object sender, EventArgs e)
    {
        // Navigate to the next page
        Navigation.PushAsync(new Page1());
    }

}
