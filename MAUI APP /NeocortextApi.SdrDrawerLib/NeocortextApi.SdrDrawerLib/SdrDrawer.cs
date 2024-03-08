using Microsoft.Maui.Graphics; // Import the Microsoft.Maui.Graphics namespace
using System; // Import the System namespace for basic types
using System.Collections.Generic; // Import the System.Collections.Generic namespace for List<>
using System.IO; // Import the System.IO namespace for file operations
using System.Linq; // Import the System.Linq namespace for LINQ queries

namespace NeocortextApi.SdrDrawerLib // Define the namespace for the SdrDrawer class
{
    public class SdrDrawer // Define the SdrDrawer class
    {
        public string Filename { get; } // Define a property to store the filename
        public string GraphName { get; } // Define a property to store the graph name
        public int MaxCycles { get; } // Define a property to store the maximum cycles
        public int HighlightTouch { get; } // Define a property to store the highlight touch
        public string YAxisTitle { get; } // Define a property to store the Y-axis title
        public string XAxisTitle { get; } // Define a property to store the X-axis title
        public int? MinCellRange { get; } // Define a property to store the minimum cell range
        public int? MaxCellRange { get; } // Define a property to store the maximum cell range
        public string SubplotTitle { get; } // Define a property to store the subplot title
        public string FigureName { get; } // Define a property to store the figure name

        public SdrDrawer( // Constructor for the SdrDrawer class
            string filename, string graphName, int maxCycles, int highlightTouch, // Parameters for filename, graphName, maxCycles, highlightTouch
            string yAxisTitle, string xAxisTitle, int? minCellRange, int? maxCellRange, // Parameters for yAxisTitle, xAxisTitle, minCellRange, maxCellRange
            string subplotTitle, string figureName) // Parameters for subplotTitle, figureName
        {
            Filename = filename ?? throw new ArgumentNullException(nameof(filename)); // Initialize Filename property with filename parameter or throw ArgumentNullException
            GraphName = graphName ?? throw new ArgumentNullException(nameof(graphName)); // Initialize GraphName property with graphName parameter or throw ArgumentNullException
            MaxCycles = maxCycles; // Initialize MaxCycles property with maxCycles parameter
            HighlightTouch = highlightTouch; // Initialize HighlightTouch property with highlightTouch parameter
            YAxisTitle = yAxisTitle ?? throw new ArgumentNullException(nameof(yAxisTitle)); // Initialize YAxisTitle property with yAxisTitle parameter or throw ArgumentNullException
            XAxisTitle = xAxisTitle ?? throw new ArgumentNullException(nameof(xAxisTitle)); // Initialize XAxisTitle property with xAxisTitle parameter or throw ArgumentNullException
            MinCellRange = minCellRange; // Initialize MinCellRange property with minCellRange parameter
            MaxCellRange = maxCellRange; // Initialize MaxCellRange property with maxCellRange parameter
            SubplotTitle = subplotTitle ?? throw new ArgumentNullException(nameof(subplotTitle)); // Initialize SubplotTitle property with subplotTitle parameter or throw ArgumentNullException
            FigureName = figureName ?? throw new ArgumentNullException(nameof(figureName)); // Initialize FigureName property with figureName parameter or throw ArgumentNullException
        }

        public void PlotActivityVertically(List<List<int>> activeCellsColumn) // Method to plot activity vertically
        {
            // Implementation for plotting activity vertically using Microsoft.Maui.Graphics
            // Refer to the Microsoft.Maui.Graphics documentation for details
        }

        public void PlotActivityHorizontally(List<List<int>> activeCellsColumn) // Method to plot activity horizontally
        {
            // Implementation for plotting activity horizontally using Microsoft.Maui.Graphics
            // Refer to the Microsoft.Maui.Graphics documentation for details
        }

        public void PlotActivity(List<List<int>> activeCellsColumn) // Method to plot activity based on the axis
        {
            // Implementation for plotting activity based on the axis
            // Call either PlotActivityVertically or PlotActivityHorizontally based on requirements
        }

        public List<List<int>> ReadCsvData() // Method to read CSV data from the file
        {
            List<List<int>> dataSets = new List<List<int>>(); // Create a list to store the data sets

            using (var reader = new StreamReader(Filename)) // Open the file for reading
            {
                while (!reader.EndOfStream) // Read until the end of the file
                {
                    var line = reader.ReadLine(); // Read a line from the file
                    var values = line.Split(','); // Split the line by commas to get values

                    List<int> rowValues = values.Select(int.Parse).ToList(); // Convert string values to integers and add to rowValues list
                    dataSets.Add(rowValues); // Add the rowValues list to the dataSets list
                }
            }

            return dataSets; // Return the list of data sets
        }

        public void DrawFigure() // Method to draw the figure
        {
            var activeCellsColumn = ReadCsvData(); // Read the CSV data
            PlotActivity(activeCellsColumn); // Plot the activity based on the axis
        }
    }
}























////using System; // Importing the System namespace for basic functionalities
////using System.IO; // Importing the System.IO namespace for file-related operations
////using SkiaSharp; // Importing the SkiaSharp namespace for drawing graphics

////namespace NeocortexApi.SdrDrawerLib // Defining a namespace for the SDR drawer library
////{
////    public class SdrDrawer // Defining a class named SdrDrawer
////    {
////        // Declaring properties to store various parameters required for drawing SDR visualization
////        public string Filename { get; private set; } = "";
////        public string GraphName { get; private set; } = "";
////        public int MaxCycles { get; private set; }
////        public int HighlightTouch { get; private set; }
////        public string Axis { get; private set; } = "";
////        public string YAxisTitle { get; private set; } = "";
////        public string XAxisTitle { get; private set; } = "";
////        public int MinCellRange { get; private set; }
////        public int MaxCellRange { get; private set; }
////        public string SubplotTitle { get; private set; } = "";
////        public string FigureName { get; private set; } = "";

////        // Method to parse command-line arguments and initialize class properties
////        public void ParseCommandLineArguments(string[] args)
////        {
////            // Check if the correct number of command-line arguments are provided
////            if (args.Length != 11)
////            {
////                throw new ArgumentException("Invalid number of command line arguments.");
////            }

////            // Assign command-line arguments to corresponding properties
////            Filename = args[0];
////            GraphName = args[1];
////            MaxCycles = int.Parse(args[2]);
////            HighlightTouch = int.Parse(args[3]);
////            Axis = args[4];
////            YAxisTitle = args[5];
////            XAxisTitle = args[6];
////            MinCellRange = int.Parse(args[7]);
////            MaxCellRange = int.Parse(args[8]);
////            SubplotTitle = args[9];
////            FigureName = args[10];
////        }

////        // Method to read SDR data from a CSV file
////        public void ReadSDRDataFromCSV()
////        {
////            // Check if the specified file exists
////            if (!File.Exists(Filename))
////            {
////                throw new FileNotFoundException("SDR data file not found.", Filename);
////            }

////            // Read each line of the CSV file and print it to the console
////            Console.WriteLine($"Reading SDR data from {Filename}...");
////            using (StreamReader reader = new StreamReader(Filename))
////            {
////                while (!reader.EndOfStream)
////                {
////                    string line = reader.ReadLine()!;
////                    Console.WriteLine(line);
////                }
////            }
////        }

////        // Method to draw the SDR visualization
////        public void DrawSDRVisualization()
////        {
////            // Placeholder: Generate SDR visualization using Maui.Graphics
////            using (SKSurface surface = SKSurface.Create(new SKImageInfo(800, 600)))
////            {
////                SKCanvas canvas = surface.Canvas;

////                // Draw SDR visualization
////                canvas.Clear(SKColors.White);

////                // Example: Draw a rectangle
////                using (SKPaint paint = new SKPaint())
////                {
////                    paint.Color = SKColors.Blue;
////                    canvas.DrawRect(new SKRect(100, 100, 300, 300), paint);
////                }

////                // Save SDR image
////                using (SKImage image = surface.Snapshot())
////                using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
////                using (Stream stream = File.OpenWrite($"{FigureName}.png"))
////                {
////                    data.SaveTo(stream);
////                }
////            }

////            Console.WriteLine($"SDR visualization saved as {FigureName}.png");
////        }

////        // Method to encapsulate the entire process of generating SDR visualization
////        public void GenerateVisualization(string[] args)
////        {
////            try
////            {
////                // Parse command-line arguments
////                ParseCommandLineArguments(args);
////                // Read SDR data from CSV file
////                ReadSDRDataFromCSV();
////                // Draw SDR visualization
////                DrawSDRVisualization();
////            }
////            catch (Exception ex)
////            {
////                // Handle any exceptions that occur during the process and print error messages
////                Console.WriteLine($"An error occurred: {ex.Message}");
////            }
////        }
////    }
////}







////using System;
////using System.IO;
////using SkiaSharp;
////using SkiaSharp.Views.Desktop;

////namespace NeocortexApi.SdrDrawerLib
////{
////    public class SdrDrawer
////    {
////        public string Filename { get; private set; } = "";
////        public string GraphName { get; private set; } = "";
////        public int MaxCycles { get; private set; }
////        public int HighlightTouch { get; private set; }
////        public string Axis { get; private set; } = "";
////        public string YAxisTitle { get; private set; } = "";
////        public string XAxisTitle { get; private set; } = "";
////        public int MinCellRange { get; private set; }
////        public int MaxCellRange { get; private set; }
////        public string SubplotTitle { get; private set; } = "";
////        public string FigureName { get; private set; } = "";

////        public void ParseCommandLineArguments(string[] args)
////        {
////            if (args.Length != 11)
////            {
////                throw new ArgumentException("Invalid number of command line arguments.");
////            }

////            Filename = args[0];
////            GraphName = args[1];
////            MaxCycles = int.Parse(args[2]);
////            HighlightTouch = int.Parse(args[3]);
////            Axis = args[4];
////            YAxisTitle = args[5];
////            XAxisTitle = args[6];
////            MinCellRange = int.Parse(args[7]);
////            MaxCellRange = int.Parse(args[8]);
////            SubplotTitle = args[9];
////            FigureName = args[10];
////        }

////        public void ReadSDRDataFromCSV()
////        {
////    if (!File.Exists(Filename))
////    {
////        throw new FileNotFoundException("SDR data file not found.", Filename);
////    }

////    Console.WriteLine($"Reading SDR data from {Filename}...");
////    using (StreamReader reader = new StreamReader(Filename))
////    {
////        while (!reader.EndOfStream)
////        {
////            string line = reader.ReadLine()!;
////            Console.WriteLine(line);
////        }
////    }
////}

////public void DrawSDRVisualization()
////{
////    // Placeholder: Generate SDR visualization using Maui.Graphics
////    using (SKSurface surface = SKSurface.Create(new SKImageInfo(800, 600)))
////    {
////        SKCanvas canvas = surface.Canvas;

////        // Draw SDR visualization
////        canvas.Clear(SKColors.White);

////        // Example: Draw a rectangle
////        using (SKPaint paint = new SKPaint())
////        {
////            paint.Color = SKColors.Blue;
////            canvas.DrawRect(new SKRect(100, 100, 300, 300), paint);
////        }

////        // Save SDR image
////        using (SKImage image = surface.Snapshot())
////        using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
////        using (Stream stream = File.OpenWrite($"{FigureName}.png"))
////        {
////            data.SaveTo(stream);
////        }
////    }

////    Console.WriteLine($"SDR visualization saved as {FigureName}.png");
////        //}

////        public void GenerateVisualization(string[] args)
////        {
////            try
////            {
////                ParseCommandLineArguments(args);
////                ReadSDRDataFromCSV();
////                DrawSDRVisualization();
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine($"An error occurred: {ex.Message}");
////            }
////        }
////    }
////}




////using System;
////using System.IO;

////namespace NeocortexApi.SdrDrawerLib
////{
////    public class SdrDrawer
////    {
////        public string Filename { get; private set; } = "";
////        public string GraphName { get; private set; } = "";
////        public int MaxCycles { get; private set; }
////        public int HighlightTouch { get; private set; }
////        public string Axis { get; private set; } = "";
////        public string YAxisTitle { get; private set; } = "";
////        public string XAxisTitle { get; private set; } = "";
////        public int MinCellRange { get; private set; }
////        public int MaxCellRange { get; private set; }
////        public string SubplotTitle { get; private set; } = "";
////        public string FigureName { get; private set; } = "";

////        public void ParseCommandLineArguments(string[] args)
////        {
////            if (args.Length != 11)
////            {
////                throw new ArgumentException("Invalid number of command line arguments.");
////            }

////            Filename = args[0];
////            GraphName = args[1];
////            MaxCycles = int.Parse(args[2]);
////            HighlightTouch = int.Parse(args[3]);
////            Axis = args[4];
////            YAxisTitle = args[5];
////            XAxisTitle = args[6];
////            MinCellRange = int.Parse(args[7]);
////            MaxCellRange = int.Parse(args[8]);
////            SubplotTitle = args[9];
////            FigureName = args[10];
////        }

////        public void ReadSDRDataFromCSV()
////        {
////            if (!File.Exists(Filename))
////            {
////                throw new FileNotFoundException("SDR data file not found.", Filename);
////            }

////            Console.WriteLine($"Reading SDR data from {Filename}...");
////            using (StreamReader reader = new StreamReader(Filename))
////            {
////                while (!reader.EndOfStream)
////                {
////                    string line = reader.ReadLine()!;
////                    Console.WriteLine(line);
////                }
////            }
////        }

////        public void DrawSDRVisualization()
////        {
////            // Graphics code goes here
////            // Example code commented out due to lack of SKIASharp reference
////            // For demonstration purposes, let's just output a message
////            Console.WriteLine("SDR visualization generated.");
////        }

////        public void GenerateVisualization(string[] args)
////        {
////            try
////            {
////                ParseCommandLineArguments(args);
////                ReadSDRDataFromCSV();
////                DrawSDRVisualization();
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine($"An error occurred: {ex.Message}");
////            }
////        }
////    }
////}






































////using System;
////using System.Collections.Generic;
////using System.IO;
////using CsvHelper;

////namespace NeocortexApi.SdrDrawerLib
////{
////    public class SdrDrawer
////    {
////        public void DrawSDRFromCommandLineArgs(string[] args)
////        {
////            if (args.Length < 10)
////            {
////                Console.WriteLine("Insufficient command-line arguments.");
////                return;
////            }

////            string filename = args[0];
////            string graphName = args[1];
////            int maxCycles = int.Parse(args[2]);
////    int highlightTouch = int.Parse(args[3]);
////    string yAxisTitle = args[4];
////    string xAxisTitle = args[5];
////    string subPlotTitle = args[6]; // Define subPlotTitle variable
////    string figureName = args[7];    // Define figureName variable

////    // Parse other arguments as needed

////    // Call method to read data from CSV file
////    List<List<int>> sdrData = ReadSDRDataFromCSV(filename);

////    // Call method to generate SDR visualization
////    // Implement SDR visualization logic based on Plotly or other libraries
////    GenerateSDRVisualization(sdrData, maxCycles, highlightTouch, yAxisTitle, xAxisTitle, subPlotTitle, figureName);
////}

////private List<List<int>> ReadSDRDataFromCSV(string filename)
////{
////    List<List<int>> sdrData = new List<List<int>>();

////    try
////    {
////        // Read data from CSV file
////        using (var reader = new StreamReader(filename))
////        using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
////        {
////            while (csv.Read())
////            {
////                var record = new List<int>();
////                var fields = csv.GetRecord<string[]>();
////                foreach (var field in fields)
////                {
////                    record.Add(int.Parse(field));
////                }
////                sdrData.Add(record);
////                    }
////                }
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine($"Error reading data from CSV file: {ex.Message}");
////            }

////            return sdrData;
////        }

////        private void GenerateSDRVisualization(List<List<int>> sdrData, int maxCycles, int highlightTouch, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName)
////        {
////            // Implement SDR visualization logic here
////            // Use a plotting library like Plotly to generate SDR visualization
////            // Example:
////            Console.WriteLine("Generating SDR visualization...");
////            Console.WriteLine($"Filename: {figureName}");
////            // Add code to generate Plotly visualization based on sdrData and other parameters
////        }
////    }

////    public class Program
////    {
////        public static void Main(string[] args)
////        {
////            var sdrDrawer = new SdrDrawer();
////            sdrDrawer.DrawSDRFromCommandLineArgs(args);
////        }
////    }
////}











////using System;
////using System.IO;
////using System.Collections.Generic;
////using CsvHelper;

////namespace NeocortexApi.SdrDrawerLib
////{
////    public class SdrDrawer
////    {
////        public void DrawSDRFromCommandLineArgs(string[] args)
////        {
////            // Parse command-line arguments
////            // Implement your logic to parse command-line arguments similar to Python's argparse

////            // Example: 
////            string filename = args[0];
////            string graphName = args[1];
////            int maxCycles = int.Parse(args[2]);
////            int highlightTouch = int.Parse(args[3]);
////            string yAxisTitle = args[4];
////            string xAxisTitle = args[5];
////            int? minCellRange = null;
////            if (args.Length > 6 && args[6] == "-min")
////                minCellRange = int.Parse(args[7]);
////            int? maxCellRange = null;
////            if (args.Length > 8 && args[8] == "-max")
////                maxCellRange = int.Parse(args[9]);
////            string subPlotTitle = args[args.Length - 3];
////            string figureName = args[args.Length - 1];

////            // Call method to read data from CSV file
////            List<List<int>> sdrData = ReadSDRDataFromCSV(filename);

////            // Call method to generate SDR visualization
////            // Implement SDR visualization logic based on Plotly or other libraries
////            GenerateSDRVisualization(sdrData, maxCycles, highlightTouch, yAxisTitle, xAxisTitle, minCellRange, maxCellRange, subPlotTitle, figureName);
////        }

////        private List<List<int>> ReadSDRDataFromCSV(string filename)
////        {
////            List<List<int>> sdrData = new List<List<int>>();

////            try
////            {
////                // Read data from CSV file
////                using (var reader = new StreamReader(filename))
////                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
////                {
////                    while (csv.Read())
////                    {
////                        var record = new List<int>();
////                        var fields = csv.GetRecord<string[]>();
////                        foreach (var field in fields)
////                        {
////                            record.Add(int.Parse(field));
////                        }
////                        sdrData.Add(record);
////                    }
////                }
////            }
////            catch (Exception ex)
////            {
////                Console.WriteLine($"Error reading data from CSV file: {ex.Message}");
////            }

////            return sdrData;
////        }

////        private void GenerateSDRVisualization(List<List<int>> sdrData, int maxCycles, int highlightTouch, string yAxisTitle, string xAxisTitle, int? minCellRange, int? maxCellRange, string subPlotTitle, string figureName)
////        {
////            // Implement SDR visualization logic here
////            // Use a plotting library like Plotly to generate SDR visualization
////            // Example:
////            Console.WriteLine("Generating SDR visualization...");
////            Console.WriteLine($"Filename: {figureName}");
////            // Add code to generate Plotly visualization based on sdrData and other parameters
////        }
////    }
////}









































////////namespace NeocortextApi.SdrDrawerLib
////////{
////////	public class SdrDrawer
////////	{
////////		public SdrDrawer()
////////		{
////////		}
////////	}
////////}

