using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CommandLine;
using NeoCortexApi;
using Plotly;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Maui_App1;

class MauiProgram
{
    static void Main(string[] args)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        config.TrimOptions = TrimOptions.Trim;

        var parser = new Parser();
        parser.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                var filename = options.Filename;
                var graphName = options.GraphName;
                var maxCycles = options.MaxCycles;
                var highlightTouch = options.HighlightTouch;
                var yAxisTitle = options.YAxisTitle;
                var xAxisTitle = options.XAxisTitle;
                var minCellRange = options.MinCellRange;
                var maxCellRange = options.MaxCellRange;
                var subPlotTitle = options.SubPlotTitle;
                var figureName = options.FigureName;

                Console.WriteLine(filename);

                var dataSets = new List<HashSet<int>>();
                var allCells = new List<int>();
                var cell = new List<int>();

                using (var reader = new StreamReader(filename))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Configuration.HasHeaderRecord = false;

                    while (csv.Read())
                    {
                        cell.Clear();

                        for (int i = 0; i < csv.Context.Record.Length; i++)
                        {
                            var cellValue = csv.GetField<int>(i);
                            cell.Add(cellValue);
                            allCells.Add(cellValue);
                        }

                        dataSets.Add(new HashSet<int>(cell));
                    }
                }

                var maxCell = allCells.Max() + 100;
                var minCell = allCells.Min() - 100;

                if (options.Axis == "x")
                {
                    PlotActivityHorizontally(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName);
                }
                else
                {
                    PlotActivityVertically(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName);
                }
            });

        static void PlotActivityVertically(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName)
        {
            var numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
            var numColumns = activeCellsColumn[0].Count;

            var fig = new Plotly.subplots.Figure();

            var data = new Graph.Scatter()
            {
                x = new List<object>(),
                y = new List<object>()
            };

            var shapes = new List<object>();

            for (int t = 0; t < numTouches; t++)
            {
                for (int c = 0; c < numColumns; c++)
                {
                    foreach (var cell in activeCellsColumn[t][c])
                    {
                        shapes.Add(new
                        {
                            type = "rect",
                            xref = $"x{c + 1}",
                            yref = "y1",
                            x0 = t,
                            x1 = t + 0.6,
                            y0 = cell,
                            y1 = cell + 1,
                            line = new
                            {
                                width = 2
                            }
                        });
                    }

                    if (t == highlightTouch)
                    {
                        shapes.Add(new
                        {
                            type = "rect",
                            xref = $"x{c + 1}",
                            x0 = t,
                            x1 = t + 0.6,
                            y0 = -95,
                            y1 = 4100,
                            line = new
                            {
                                color = "rgba(255, 0, 0, 0.5)",
                                width = 3
                            }
                        });
                    }
                }
            }

        }
    }
}
   

    