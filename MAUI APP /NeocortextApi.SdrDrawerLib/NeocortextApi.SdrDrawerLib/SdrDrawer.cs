//using System;
//using System.Collections.Generic;
//using System.IO;
//using CsvHelper;

//namespace NeocortexApi.SdrDrawerLib
//{
//    public class SdrDrawer
//    {
//        public void DrawSDRFromCommandLineArgs(string[] args)
//        {
//            if (args.Length < 10)
//            {
//                Console.WriteLine("Insufficient command-line arguments.");
//                return;
//            }

//            string filename = args[0];
//            string graphName = args[1];
//            int maxCycles = int.Parse(args[2]);
//    int highlightTouch = int.Parse(args[3]);
//    string yAxisTitle = args[4];
//    string xAxisTitle = args[5];
//    string subPlotTitle = args[6]; // Define subPlotTitle variable
//    string figureName = args[7];    // Define figureName variable

//    // Parse other arguments as needed

//    // Call method to read data from CSV file
//    List<List<int>> sdrData = ReadSDRDataFromCSV(filename);

//    // Call method to generate SDR visualization
//    // Implement SDR visualization logic based on Plotly or other libraries
//    GenerateSDRVisualization(sdrData, maxCycles, highlightTouch, yAxisTitle, xAxisTitle, subPlotTitle, figureName);
//}

//private List<List<int>> ReadSDRDataFromCSV(string filename)
//{
//    List<List<int>> sdrData = new List<List<int>>();

//    try
//    {
//        // Read data from CSV file
//        using (var reader = new StreamReader(filename))
//        using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
//        {
//            while (csv.Read())
//            {
//                var record = new List<int>();
//                var fields = csv.GetRecord<string[]>();
//                foreach (var field in fields)
//                {
//                    record.Add(int.Parse(field));
//                }
//                sdrData.Add(record);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error reading data from CSV file: {ex.Message}");
//            }

//            return sdrData;
//        }

//        private void GenerateSDRVisualization(List<List<int>> sdrData, int maxCycles, int highlightTouch, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName)
//        {
//            // Implement SDR visualization logic here
//            // Use a plotting library like Plotly to generate SDR visualization
//            // Example:
//            Console.WriteLine("Generating SDR visualization...");
//            Console.WriteLine($"Filename: {figureName}");
//            // Add code to generate Plotly visualization based on sdrData and other parameters
//        }
//    }

//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var sdrDrawer = new SdrDrawer();
//            sdrDrawer.DrawSDRFromCommandLineArgs(args);
//        }
//    }
//}











using System;
using System.IO;
using System.Collections.Generic;
using CsvHelper;

namespace NeocortexApi.SdrDrawerLib
{
    public class SdrDrawer
    {
        public void DrawSDRFromCommandLineArgs(string[] args)
        {
            // Parse command-line arguments
            // Implement your logic to parse command-line arguments similar to Python's argparse

            // Example: 
            string filename = args[0];
            string graphName = args[1];
            int maxCycles = int.Parse(args[2]);
            int highlightTouch = int.Parse(args[3]);
            string yAxisTitle = args[4];
            string xAxisTitle = args[5];
            int? minCellRange = null;
            if (args.Length > 6 && args[6] == "-min")
                minCellRange = int.Parse(args[7]);
            int? maxCellRange = null;
            if (args.Length > 8 && args[8] == "-max")
                maxCellRange = int.Parse(args[9]);
            string subPlotTitle = args[args.Length - 3];
            string figureName = args[args.Length - 1];

            // Call method to read data from CSV file
            List<List<int>> sdrData = ReadSDRDataFromCSV(filename);

            // Call method to generate SDR visualization
            // Implement SDR visualization logic based on Plotly or other libraries
            GenerateSDRVisualization(sdrData, maxCycles, highlightTouch, yAxisTitle, xAxisTitle, minCellRange, maxCellRange, subPlotTitle, figureName);
        }

        private List<List<int>> ReadSDRDataFromCSV(string filename)
        {
            List<List<int>> sdrData = new List<List<int>>();

            try
            {
                // Read data from CSV file
                using (var reader = new StreamReader(filename))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        var record = new List<int>();
                        var fields = csv.GetRecord<string[]>();
                        foreach (var field in fields)
                        {
                            record.Add(int.Parse(field));
                        }
                        sdrData.Add(record);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from CSV file: {ex.Message}");
            }

            return sdrData;
        }

        private void GenerateSDRVisualization(List<List<int>> sdrData, int maxCycles, int highlightTouch, string yAxisTitle, string xAxisTitle, int? minCellRange, int? maxCellRange, string subPlotTitle, string figureName)
        {
            // Implement SDR visualization logic here
            // Use a plotting library like Plotly to generate SDR visualization
            // Example:
            Console.WriteLine("Generating SDR visualization...");
            Console.WriteLine($"Filename: {figureName}");
            // Add code to generate Plotly visualization based on sdrData and other parameters
        }
    }
}









































//////namespace NeocortextApi.SdrDrawerLib
//////{
//////	public class SdrDrawer
//////	{
//////		public SdrDrawer()
//////		{
//////		}
//////	}
//////}

