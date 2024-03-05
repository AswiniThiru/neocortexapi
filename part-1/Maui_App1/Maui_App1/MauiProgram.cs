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
    private static int f;

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



                var layout = new
                {
                    height = 600,
                    font = new { size = 18 },
                    yaxis = new
                    {
                        title = yAxisTitle,
                        range = new[] { minCell, maxCell },
                        showgrid = false
                    },
                    shapes = shapes
                };

                if (numColumns == 1)
                {
                    layout.width = 320;
                }
                else
                {
                    layout.width = 700;
                }

                for (int c = 0; c < numColumns; c++)
                {
                    fig.add_trace(data, 1, c + 1);
                    fig.layout[f"xaxis{c + 1 }"].update(new
                    {
                        title = "",
                        range = new[] { 0, numTouches },
                        showgrid = false,
                        showticklabels = true
                    });
                }


                fig.layout.Update(layout);

                // Save plots as HTM and/or PDF
                var basename = $"{figureName}{numColumns}";
                Plotly.offline.plot(fig, filename: $"{basename}.html", auto_open: true);

                // Can't save image files in offline mode
                // if (plotlyAPIKey is not None):
                //    plotly.plotly.image.save_as(fig, filename=basename + '.pdf', scale=4);
            }
        }
    }

    public class Options
    {
        [Option("filename", Required = true, HelpText = "Filename from which data is supposed to be read")]
        public string Filename { get; set; }

        [Option("graphename", Required = true, HelpText = "Graphname where data is supposed to be plot")]
        public string GraphName { get; set; }

        [Option("maxcycles", Required = true, HelpText = "Number of maximum touches/iterations")]
        public int MaxCycles { get; set; }

        [Option("highlighttouch", Required = true, HelpText = "Number of highlight touches")]
        public int HighlightTouch { get; set; }

        [Option("axis", Default = null, HelpText = "Cells are placed on desired x or y axis, enter x or y")]
        public string Axis { get; set; }

        [Option("yaxistitle", Required = true, HelpText = "The title of the y-axis")]
        public string YAxisTitle { get; set; }

        [Option("xaxistitle", Required = true, HelpText = "The title of the x-axis")]
        public string XAxisTitle { get; set; }

        [Option("mincellrange", HelpText = "Minimun range of the cells")]
        public int? MinCellRange { get; set; }

        [Option("maxcellrange", HelpText = "Maximum range of the cells")]
        public int? MaxCellRange { get; set; }

        [Option("subplottitle", Required = true, HelpText = "The title of the subplot")]
        public string SubPlotTitle { get; set; }

        [Option("figurename", Required = true, HelpText = "The name of the figure")]
        public string FigureName { get; set; }
    }

   