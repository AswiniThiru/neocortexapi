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

    private async void OnAttachFileButtonClick(object sender, EventArgs e)
    {
        // Prompt the user to pick a CSV file
        var result = await FilePicker.PickAsync(options: new PickOptions { FileTypes = FilePickerFileType.Csv, PickerTitle = "Pick a CSV File" });

        if (result != null)
        {
            // Handle the selected CSV file (result.FullPath)
            // You can perform further processing or store the file path as needed
            DisplayAlert("File Selected", $"File selected: {result.FileName}", "OK");
        }
    }

}

