using DrawDiagram.Models;
using NeocortexApi.SdrDrawerLib.Models;
using System.Text.RegularExpressions;

namespace NeocortexApi.SdrDrawerLib
{
    public static class SdrHelper
    {
        /// <summary>
        /// Generates an SDR plot based on the provided SdValueModel instance.
        /// </summary>
        /// <param name="model">The SdValueModel instance containing the data for the plot.</param>
        public static void newgeneratesdr(SdValueModel model)
        {
            try
            {
                // Initializing list for datasets.
                List<HashSet<int>> dataSets = new List<HashSet<int>>();
                // Initializing list for all cells.
                List<int> allCells = new List<int>();

                // Assuming the fileContent contains the CSV data for the SDR plot.
                string fileContent = model.fileData;
                string[] lines = fileContent.Split('\n');
				
				// Processing each line of the CSV data.
				foreach (var line in lines)
                {
					var values = line.Split(',');
                    // Initializing HashSet for each line.
                    HashSet<int> cellSet = new HashSet<int>();
                    foreach (var value in values)
                    {
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            // Parsing cell value to integer.
                            int cellValue = int.Parse(value.Trim());
                            cellSet.Add(cellValue);
                            allCells.Add(cellValue);
                        }
                    }

                    dataSets.Add(cellSet);
                }

                // Extracting additional parameters from the model.
                string graphName = model.graphname;
                string axis = model.axis;
                int maxCell = allCells.Max() + 100;
                int minCell = allCells.Min() - 100;
                int maxCycles = model.maxCycles;
                int highlightTouch = model.hightouch;
                string yAxisTitle = model.yaxis;
                string xAxisTitle = model.xaxis;
                string subPlotTitle = model.subplottitle;
                string figureName = model.textfile;

                // Setting the current SD in the Filedatahelper.
                Filedatahelper.setcurrentSD(model);

                // Plotting the activity vertically and horizontally.
                SdrDrawer.PlotActivityVertically(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName, model.datapath);
                SdrDrawer.PlotActivityHorizontally(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName, model.datapath);
            }
            catch (Exception ex)
            {
                // Exception handling if any error occurs during the plot generation.
            }
        }

    }
}
