using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace SDR_App;

public partial class Page1 : ContentPage
{
	public Page1()
	{
        InitializeComponent();
    }

    private void InitializeDropdowns()
    {
        // Populate Max Cycle dropdown
        List<int> maxCycleOptions = new List<int>() { 100, 200, 300, 400, 500 };
        foreach (var option in maxCycleOptions)
        {
            maxCycleDropdown.Items.Add(option.ToString());
        }

        // Populate Min Cell dropdown
        List<int> minCellOptions = new List<int>() { 1, 2, 3, 4, 5 };
        foreach (var option in minCellOptions)
        {
            minCellDropdown.Items.Add(option.ToString());
        }

        // Populate Max Cell dropdown
        List<int> maxCellOptions = new List<int>() { 6, 7, 8, 9, 10 };
        foreach (var option in maxCellOptions)
        {
            maxCellDropdown.Items.Add(option.ToString());
        }
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Handle text changed event for text entries
        // For simplicity, you can perform a common action here or differentiate based on the sender's Name property
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Handle selected index changed event for dropdowns
        // For simplicity, you can perform a common action here or differentiate based on the sender's Name property
    }
}