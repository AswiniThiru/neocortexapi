using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeocortexApi.SdrDrawerLib;

namespace NeocortexApi.SdrDrawerLib.Models
{
    public class SdrDrawer
    {
        // This method plots the activity vertically based on the provided parameters.
        public static string PlotActivityVertically(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName, string path)
        {
            // Initialize outputdata to empty string
            Filedatahelper.Sdvalue.outputdatavertical = "";

            // Calculate the number of touches and columns
            int numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;

            // Create a new plot model with the provided figure name
            var model = new PlotModel { Title = subPlotTitle };

            // Set default and border colors for the RectangleBarSeries
            var defaultSeriesColor = OxyColor.FromRgb(64,224,208);
            var borderSeriesColor = OxyColor.FromRgb(0,0,0); 

            // Iterate over columns and add series to the plot model
            for (int c = 0; c < numColumns; c++)
            {
                var series = new RectangleBarSeries { Title = $"Column {c + 1}", FillColor = defaultSeriesColor, StrokeColor = borderSeriesColor }; // Set fill color to  and border color to orange

                // Add items to the series for each touch and cell
                for (int t = 0; t < activeCellsColumn.Count; t++)
                {
                    if (t == highlightTouch)
                    {
                        series.Items.Add(new RectangleBarItem(t - 0.5, -95, t + 0.5, 4100)); // Highlight the touch
                    }

                    foreach (var cell in activeCellsColumn[t])
                    {
                        series.Items.Add(new RectangleBarItem(t, cell, t + 0.6, cell + 1)); // Add cell to the series
                    }
                }

                model.Series.Add(series); // Add the series to the plot model
            }

            // Add axes to the plot model
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = xAxisTitle, Minimum = 0, Maximum = numTouches });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = yAxisTitle, Minimum = minCell, Maximum = maxCell });

            // Calculate and append graph values for each cycle to the outputdatavertical
            for (int i = 0; i < numTouches; i++)
            {
                double xValue = i;
                double yValue = (double)i / numTouches * (maxCell - minCell) + minCell;
                Filedatahelper.Sdvalue.outputdatavertical += $"Cycle {i + 1}: X={xValue}, Y={yValue}<br/>";
            }

            // Set plot background and border colors
            model.PlotAreaBackground = OxyColor.FromRgb(227, 253, 215);
            model.PlotAreaBorderColor = OxyColor.FromRgb(227, 253, 215);

            // Specify the directory where the SVG file will be saved
            string directory = $"C:\\svgimages";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string svgFilePath = Path.Combine(directory, $"VerticalPlot.svg");

            // Export the plot model to an SVG file
            var exporter = new SvgExporter { Width = 400, Height = 500 };
            using (var stream = new FileStream(svgFilePath, FileMode.Create))
            {
                exporter.Export(model, stream);
            }

            Filedatahelper.setimagepath(directory); // Set the image path in Filedatahelper
            return Path.GetFullPath(directory); // Return the full path of the generated SVG file
        }



        // This method plots the activity horizontally based on the provided parameters.
        public static string PlotActivityHorizontally(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName, string path)
        {
            // Initialize outputdata to empty string
            Filedatahelper.Sdvalue.outputdatahorizontal = "";

            // Calculate the number of touches and columns
            int numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;

            // Create a new plot model with the provided figure name
            var model = new PlotModel { Title = subPlotTitle };

            // Set default and border colors for the RectangleBarSeries
            var defaultSeriesColor = OxyColor.FromRgb(64, 224, 208);    
            var borderSeriesColor = OxyColor.FromRgb(0,0,0); // black for border

            // Iterate over columns and add series to the plot model
            for (int c = 0; c < numColumns; c++)
            {
                var series = new RectangleBarSeries { Title = $"Column {c + 1}", FillColor = defaultSeriesColor, StrokeColor = borderSeriesColor }; // Set fill color to blue and border color to orange

                // Add items to the series for each touch and cell
                for (int t = 0; t < activeCellsColumn.Count && t <= numTouches; t++)
                {
                    if (t == highlightTouch)
                    {
                        series.Items.Add(new RectangleBarItem(-95, t - 0.5, 4100, t + 0.5)); // Highlight the touch
                    }

                    foreach (var cell in activeCellsColumn[t])
                    {
                        series.Items.Add(new RectangleBarItem(cell, t, cell + 1, t + 0.6)); // Add cell to the series
                    }
                }

                model.Series.Add(series); // Add the series to the plot model
            }

            // Add axes to the plot model
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = xAxisTitle, Minimum = minCell, Maximum = maxCell });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = yAxisTitle, Minimum = 0, Maximum = numTouches });

            // Calculate and append graph values for each cycle to the outputdatahorizontal
            for (int i = 0; i < numTouches; i++)
            {
                double xValue = i;
                double yValue = (double)i / numTouches * (maxCell - minCell) + minCell;
                Filedatahelper.Sdvalue.outputdatahorizontal += $"Cycle {i + 1}: X={xValue}, Y={yValue}<br/>";
            }

            // Set plot background and border colors
            model.PlotAreaBackground = OxyColor.FromRgb(227, 253, 215);
            model.PlotAreaBorderColor = OxyColor.FromRgb(227, 253, 215);

            // Specify the directory where the SVG file will be saved
            string directory = $"C:\\svgimages";
            if (!Directory.Exists(directory))
			{ Directory.CreateDirectory(directory); }
                

            string svgFilePath = Path.Combine(directory, $"HorizontalPlot.svg");

            var exporter = new SvgExporter { Width = 400, Height = 500 };
			using (var stream = new FileStream(svgFilePath, FileMode.Create))
			{
				exporter.Export(model, stream);
			}

            // Set Image directory as static 
            Filedatahelper.setimagepath(directory);
            // Return the full path of the generated SVG file
            return Path.GetFullPath(directory);
		}

    }
}
