using DrawDiagram.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NeocortexApi.SdrDrawerLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawDiagram.Components.Pages
{
	public partial class OutputPage
	{
        private bool isVerticalPlotEnabled { get; set; }
        private bool isHorizontalPlotEnabled { get; set; }
        private bool isBothPlotsEnabled { get; set; }

        public bool isAutomaticScreenshotEnabled = false; // Flag to indicate if automatic screenshot is enabled
        private double referenceMin = 0; // Minimum reference value for scaling
        private double referenceMax = Filedatahelper.Sdvalue.maxCycles; // Maximum reference value for scaling
        double ratio = 0; // Ratio for scaling
        public string svgPath_H = ""; // Path to the SVG image for horizontal
        public string svgPath_V = ""; // Path to the SVG image for vertical
        double currentval = 0; // Current value for progress bar
        double progressValues = 100; // Total progress values
        private int minValue = 0; // Minimum value for progress bar
        private int maxValue = 100; // Maximum value for progress bar

        // Method called when the component is initialized
        protected override async Task OnInitializedAsync()
        {

            isVerticalPlotEnabled = true;
        }

        // Asynchronously fetches SVG path from a file here this function not using you can now remove 
        public static async Task<string> SVGPathAsync()
        {
            try
            {
                var filename = "sampleOne.txt";

                List<HashSet<int>> dataSets = new List<HashSet<int>>(); // List to store datasets
                List<int> allCells = new List<int>(); // List to store all cells

                // Read file and populate dataSets and allCells
                using (var reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        HashSet<int> cellSet = new HashSet<int>();
                        foreach (var value in values)
                        {
                            if (!string.IsNullOrWhiteSpace(value))
                            {
                                int cellValue = int.Parse(value.Trim());
                                cellSet.Add(cellValue);
                                allCells.Add(cellValue);
                            }
                        }
                        dataSets.Add(cellSet);
                    }
                }

                string svg = "";
                if (SdrValues.axis == "x")
                {
                    svg = NeocortexApi.SdrDrawerLib.Models.SdrDrawer.PlotActivityHorizontally(dataSets, SdrValues.hightouch, SdrValues.maxCycles, SdrValues.minrange, SdrValues.maxrange, SdrValues.yaxis, SdrValues.xaxis, SdrValues.subplottitle, SdrValues.fname, "");
                }
                else
                {
                    svg = NeocortexApi.SdrDrawerLib.Models.SdrDrawer.PlotActivityVertically(dataSets, SdrValues.hightouch, SdrValues.maxCycles, SdrValues.minrange, SdrValues.maxrange, SdrValues.yaxis, SdrValues.xaxis, SdrValues.subplottitle, SdrValues.fname, "");
                }
                return svg;
            }
            catch (Exception ex)
            {
                return string.Empty; // Return empty string if an exception occurs
            }
        }

        // Toggles the automatic screenshot option
        protected async Task ToggleScreenshotOption()
        {
            isAutomaticScreenshotEnabled = !isAutomaticScreenshotEnabled; // Toggle the flag
            if (isAutomaticScreenshotEnabled)
            {
                SdrValues.axis = "y"; // Set axis value
                StateHasChanged(); // Update the component
                                   //svgPath = await SVGPathAsync(); // Load SVG path asynchronously
            }
        }

        // Converts an SVG file to base64 string
        public string GetBase64Image(string filePath)
        {
            byte[] imageBytes = File.ReadAllBytes(filePath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

       
       
        private async Task onchangefilename(ChangeEventArgs e)
        {
          
            Filedatahelper.Sdvalue.fname = e.Value.ToString();
            SdrHelper.newgeneratesdr(Filedatahelper.Sdvalue); // Generate graph
            StateHasChanged(); // Update the component
        }

        // Generates a graph
        private void HandleInput(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int value))
            {
                progressValues = value;
                Filedatahelper.Sdvalue.maxCycles =Convert.ToInt32((referenceMax/100)*progressValues); // Update maxCycles in SdValueModel
                SdrHelper.newgeneratesdr(Filedatahelper.Sdvalue); // Generate graph
                StateHasChanged(); // Update the component
            }
        }

        private async Task DownloadImage()
        {
            await jsruntime.InvokeVoidAsync("downloadImage", $"data:image/svg+xml;base64,{GetBase64Image(svgPath_H)}", "horizontal.svg");
            await jsruntime.InvokeVoidAsync("downloadImage", $"data:image/svg+xml;base64,{GetBase64Image(svgPath_V)}", "vertical.svg");
            await jsruntime.InvokeVoidAsync("alert", "Download complete!");
        }
    }
}
