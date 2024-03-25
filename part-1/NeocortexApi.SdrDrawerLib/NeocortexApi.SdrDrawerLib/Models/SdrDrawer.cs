using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeocortexApi.SdrDrawerLib.Models
{
    public class SdrDrawer
    {
        public static string PlotActivityVertically(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName)
        {
            int numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;

            var model = new PlotModel { Title = figureName }; // Remove background color

			// Set default color of RectangleBarSeries
			var defaultSeriesColor = OxyColor.FromRgb(0, 0, 0);
			var borderSeriesColor = OxyColor.FromRgb(160, 82, 45); // Orange for border

			for (int c = 0; c < numColumns; c++)
            {
                var series = new RectangleBarSeries { Title = $"Column {c + 1}", FillColor = defaultSeriesColor, StrokeColor = borderSeriesColor }; // Set the fill color to blue and border color to orange

                for (int t = 0; t < activeCellsColumn.Count; t++)
                {
                    if (t == highlightTouch)
                    {
                        series.Items.Add(new RectangleBarItem(t - 0.5, -95, t + 0.5, 4100));
                    }

                    foreach (var cell in activeCellsColumn[t])
                    {
                        series.Items.Add(new RectangleBarItem(t, cell, t + 0.6, cell + 1));
                    }
                }

                model.Series.Add(series);
            }

            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = xAxisTitle, Minimum = 0, Maximum = numTouches });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = yAxisTitle, Minimum = minCell, Maximum = maxCell });

			// Set plot background color
			model.PlotAreaBackground = OxyColor.FromRgb(255, 235, 205);

			// Set plot border color
			model.PlotAreaBorderColor = OxyColor.FromRgb(0, 0, 0);

			// Specify the directory where the SVG file will be saved
			string directory = "SVGFiles";
			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			string svgFilePath = Path.Combine(directory, $"VerticalPlot.svg");

			var exporter = new SvgExporter { Width = 300, Height = 400 };
			using (var stream = new FileStream(svgFilePath, FileMode.Create))
			{
				exporter.Export(model, stream);
			}

			// Return the full path of the generated SVG file
			return Path.GetFullPath(svgFilePath);
		}





		public static string PlotActivityHorizontally(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName)
		{
			int numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
			int numColumns = activeCellsColumn[0].Count;

			var model = new PlotModel { Title = figureName }; // Set background color to gray

			// Set default color of RectangleBarSeries
			var defaultSeriesColor = OxyColor.FromRgb(0, 0, 0);
			var borderSeriesColor = OxyColor.FromRgb(160, 82, 45); // Orange for border

			for (int c = 0; c < numColumns; c++)
			{
				var series = new RectangleBarSeries { Title = $"Column {c + 1}", FillColor = defaultSeriesColor, StrokeColor = borderSeriesColor }; // Set the fill color to blue and border color to orange

				for (int t = 0; t < activeCellsColumn.Count && t <= numTouches; t++)
				{
					if (t == highlightTouch)
					{
						series.Items.Add(new RectangleBarItem(-95, t - 0.5, 4100, t + 0.5));
					}

					foreach (var cell in activeCellsColumn[t])
					{
						series.Items.Add(new RectangleBarItem(cell, t, cell + 1, t + 0.6));
					}
				}

				model.Series.Add(series);
			}

			model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = xAxisTitle, Minimum = minCell, Maximum = maxCell });
			model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = yAxisTitle, Minimum = 0, Maximum = numTouches });

			// Set plot background color
			model.PlotAreaBackground = OxyColor.FromRgb(255, 235, 205);

			// Set plot border color
			model.PlotAreaBorderColor = OxyColor.FromRgb(0, 0, 0);

			// Specify the directory where the SVG file will be saved
			string directory = "SVGFiles";
			if (!Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			string svgFilePath = Path.Combine(directory, $"HorizontalPlot.svg");

			var exporter = new SvgExporter { Width = 300, Height = 400 };
			using (var stream = new FileStream(svgFilePath, FileMode.Create))
			{
				exporter.Export(model, stream);
			}

			// Return the full path of the generated SVG file
			return Path.GetFullPath(svgFilePath);
		}
	}
}
