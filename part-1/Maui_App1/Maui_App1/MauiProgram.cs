using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using NeoCortexApi;
using Plotly;
using Microsoft.Extensions.Logging;

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
    }
}
   

    