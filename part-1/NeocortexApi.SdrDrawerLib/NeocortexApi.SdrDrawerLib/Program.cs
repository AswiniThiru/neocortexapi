using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Text;
using System.Threading.Tasks;
using NeocortexApi.SdrDrawerLib.Models;

namespace NeocortexApi.SdrDrawerLib
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var filename = "../../sampleOne.txt";

            List<HashSet<int>> dataSets = new List<HashSet<int>>(); // Initializing list for datasets.
            List<int> allCells = new List<int>(); // Initializing list for all cells.

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
            string graphname = args[1];
            string axis = args[10];

            int maxCell = allCells.Max() + 100; // Calculating the maximum cell value.
            int minCell = allCells.Min() - 100; // Calculating the minimum cell value.

            int maxCycles = int.Parse(args[2]); ; // Assuming max cycles is passed as the third argument.
            int highlightTouch = int.Parse(args[3]); // Assuming highlight touch is passed as the fourth argument.

            string yAxisTitle = args[4]; // Assuming y-axis title is passed as the fifth argument.
            string xAxisTitle = args[5]; // Assuming x-axis title is passed as the sixth argument.
            string subPlotTitle = args[8]; // Assuming subplot title is passed as the eighth argument.
            string figureName = args[9]; // Assuming figure name is passed as the ninth argument.

            if (axis == "x") // Checking if the axis is 'x'.
            {
                SdrDrawer.PlotActivityHorizontally(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName);
            }
            else
            {
                SdrDrawer.PlotActivityVertically(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName);
            }
        }
    }
}
