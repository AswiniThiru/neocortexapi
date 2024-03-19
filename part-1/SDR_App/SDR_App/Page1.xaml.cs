using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace SDR_App;

public partial class Page1 : ContentPage
{
	public Page1()
	{
		InitializeComponent();
        InitializeUI();
    }

    private void InitializeUI()
    {
        // Create Text Entry for Filename
        var filenameEntry = new Entry();
        filenameEntry.Placeholder = "Enter Filename";
        filenameEntry.TextChanged += (sender, e) =>
        {
            // Do something with the text entered
        };

        // Create Text Entry for Graph Name
        var graphNameEntry = new Entry();
        graphNameEntry.Placeholder = "Enter Graph Name";
        graphNameEntry.TextChanged += (sender, e) =>
        {
            // Do something with the text entered
        };

        // Create Dropdown for Max Cycle
        var maxCycleDropdown = new Picker();
        List<int> maxCycleOptions = new List<int>() { 100, 200, 300, 400, 500 }; // Example options
        foreach (var option in maxCycleOptions)
        {
            maxCycleDropdown.Items.Add(option.ToString());
        }
        maxCycleDropdown.SelectedIndexChanged += (sender, e) =>
        {
            // Do something with the selected item
        };

        // Add buttons to the layout
        var stackLayout = new StackLayout();
        stackLayout.Children.Add(new Label() { Text = "Filename:" });
        stackLayout.Children.Add(filenameEntry);
        stackLayout.Children.Add(new Label() { Text = "Graph Name:" });
        stackLayout.Children.Add(graphNameEntry);
        stackLayout.Children.Add(new Label() { Text = "Max Cycle:" });
        stackLayout.Children.Add(maxCycleDropdown);


        Content = stackLayout;
    }
}

