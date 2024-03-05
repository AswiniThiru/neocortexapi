using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Plotly;
using Plotly.Subplots;
using Plotly.GraphObjects;
using Plotly.PlotlyAPI;
using Plotly.ImageAPI;
using CsvHelper;

namespace CodeTranslationAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = args[0];
            string graphename = args[1];
            int maxcycles = int.Parse(args[2]);
            int highlighttouch = int.Parse(args[3]);
            string axis = args[4];
            string yaxistitle = args[5];
            string xaxistitle = args[6];
            int? mincellrange = args[7] != null ? int.Parse(args[7]) : null;
            int? maxcellrange = args[8] != null ? int.Parse(args[8]) : null;
            string subplottitle = args[9];
            string figurename = args[10];

            string plotlyUser = Environment.GetEnvironmentVariable("PLOTLY_USERNAME");
            string plotlyAPIKey = Environment.GetEnvironmentVariable("PLOTLY_API_KEY");
            if (plotlyAPIKey != null)
            {
                PlotlyChart.SetCredentials(plotlyUser, plotlyAPIKey);
            }

            int maxCell = 0;
            int minCell = 0;
            List<List<HashSet<int>>> dataSets = new List<List<HashSet<int>>>();
            List<int> allCells = new List<int>();
            List<int> cell = new List<int>();

            using (var reader = new StreamReader(filename))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.SkipEmptyRecords = false;
                csv.Configuration.Delimiter = ",";
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    for (int i = 0; i < csv.Context.Record.Length; i++)
                    {
                        string value = csv.GetField(i);
                        if (value == "")
                        {
                            continue;
                        }
                        int j = int.Parse(value.Trim());
                        cell.Add(j);
                        allCells.Add(j);
                    }
                    dataSets.Add(new List<HashSet<int>> { new HashSet<int>(cell) });
                    cell.Clear();
                }
            }

            maxCell = allCells.Max() + 100;
            minCell = allCells.Min() - 100;

            if (axis == "x")
            {
                PlotActivityHorizontally(dataSets, highlighttouch, maxcycles, graphename, yaxistitle, xaxistitle, mincellrange, maxcellrange, subplottitle, figurename, minCell, maxCell);
            }
            else
            {
                PlotActivityVertically(dataSets, highlighttouch, maxcycles, graphename, yaxistitle, xaxistitle, mincellrange, maxcellrange, subplottitle, figurename, minCell, maxCell);
            }
        }

        static void PlotActivityVertically(List<List<HashSet<int>>> activeCellsColumn, int highlightTouch, int maxcycles, string graphename, string yAxisTitle, string xAxisTitle, int? minCellRange, int? maxCellRange, string subPlotTitle, string figureName, int minCell, int maxCell)
        {
            int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;
            var fig = Subplots.MakeSubplots(rows: 1, cols: numColumns, sharedYAxes: true, subplotTitles: new List<string> { subPlotTitle, "Column 2", "Column 3" }.GetRange(0, numColumns));

            var data = new Scatter { x = new List<object>(), y = new List<object>() };
            var shapes = new List<Shape>();

            for (int t = 0; t < activeCellsColumn.Count; t++)
            {
                if (t <= numTouches)
                {
                    for (int c = 0; c < activeCellsColumn[t].Count; c++)
                    {
                        foreach (int cell in activeCellsColumn[t][c])
                        {
                            shapes.Add(new Shape
                            {
                                type = "rect",
                                xref = "x" + (c + 1),
                                yref = "y1",
                                x0 = t,
                                x1 = t + 0.6,
                                y0 = cell,
                                y1 = cell + 1,
                                line = new Line
                                {
                                    width = 2
                                }
                            });
                        }
                        if (t == highlightTouch)
                        {
                            shapes.Add(new Shape
                            {
                                type = "rect",
                                xref = "x" + (c + 1),
                                x0 = t,
                                x1 = t + 0.6,
                                y0 = -95,
                                y1 = 4100,
                                line = new Line
                                {
                                    color = "rgba(255, 0, 0, 0.5)",
                                    width = 3
                                }
                            });
                        }
                    }
                }
            }

            fig.layout.annotations.Add(new Annotation
            {
                font = new Font { size = 20 },
                xanchor = "center",
                yanchor = "bottom",
                text = xAxisTitle,
                xref = "paper",
                yref = "paper",
                x = 0.5,
                y = -0.15,
                showarrow = false
            });

            fig.layout.annotations.Add(new Annotation
            {
                font = new Font { size = 24 },
                xanchor = "center",
                yanchor = "bottom",
                text = numColumns == 1 ? new List<string> { "", figureName, "", "<b>Three cortical columns</b>" }[numColumns] : new List<string> { "", figureName, "", "<b>Three cortical columns</b>" }[numColumns],
                xref = "paper",
                yref = "paper",
                x = 0.5,
                y = 1.1,
                showarrow = false
            });

            var layout = new Layout
            {
                height = 600,
                font = new Font { size = 18 },
                yaxis = new Yaxis
                {
                    title = yAxisTitle,
                    range = new List<int> { minCell, maxCell },
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
                fig.AppendTrace(data, 1, c + 1);
                fig.layout.GetType().GetProperty("xaxis" + (c + 1)).SetValue(fig.layout, new Xaxis
                {
                    title = "",
                    range = new List<int> { 0, numTouches },
                    showgrid = false,
                    showticklabels = true
                });
            }

            fig.layout = layout;

            string basename = graphename + numColumns;
            PlotlyChart.SaveAs(fig, basename + ".html", true);

            if (plotlyAPIKey != null)
            {
                PlotlyChart.SaveAs(fig, basename + ".pdf", 4);
            }
        }

        static void PlotActivityHorizontally(List<List<HashSet<int>>> activeCellsColumn, int highlightTouch, int maxcycles, string graphename, string yAxisTitle, string xAxisTitle, int? minCellRange, int? maxCellRange, string subPlotTitle, string figureName, int minCell, int maxCell)
        {
            int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;
            var fig = Subplots.MakeSubplots(rows: 1, cols: numColumns, sharedYAxes: true, subplotTitles: new List<string> { subPlotTitle, "Column 2", "Column 3" }.GetRange(0, numColumns));

            var data = new Scatter { x = new List<object>(), y = new List<object>() };
            var shapes = new List<Shape>();

            for (int t = 0; t < activeCellsColumn.Count; t++)
            {
                if (t <= numTouches)
                {
                    for (int c = 0; c < activeCellsColumn[t].Count; c++)
                    {
                        foreach (int cell in activeCellsColumn[t][c])
                        {
                            shapes.Add(new Shape
                            {
                                type = "rect",
                                xref = "x1",
                                yref = "y" + (c + 1),
                                x0 = cell,
                                x1 = cell + 1,
                                y0 = t,
                                y1 = t + 0.6,
                                line = new Line
                                {
                                    width = 2
                                }
                            });
                        }
                        if (t == highlightTouch)
                        {
                            shapes.Add(new Shape
                            {
                                type = "rect",
                                yref = "y" + (c + 1),
                                x0 = -95,
                                x1 = 4100,
                                y0 = t,
                                y1 = t + 0.6,
                                line = new Line
                                {
                                    color = "rgba(255, 0, 0, 0.5)",
                                    width = 3
                                }
                            });
                        }
                    }
                }
            }

            fig.layout.annotations.Add(new Annotation
            {
                font = new Font { size = 24 },
                xanchor = "center",
                yanchor = "bottom",
                text = new List<string> { "", figureName, "", "<b>Three cortical columns</b>" }[numColumns],
                xref = "paper",
                yref = "paper",
                x = 0.5,
                y = 1.1,
                showarrow = false
            });

            fig.layout.annotations.Add(new Annotation
            {
                font = new Font { size = 20 },
                xanchor = "center",
                yanchor = "bottom",
                text = xAxisTitle,
                xref = "paper",
                yref = "paper",
                x = 0.5,
                y = -0.15,
                showarrow = false
            });

            var layout = new Layout
            {
                width = 600,
                font = new Font { size = 18 },
                yaxis = new Yaxis
                {
                    title = yAxisTitle,
                    range = new List<int> { 0, numTouches },
                    showgrid = false
                },
                shapes = shapes
            };

            if (numColumns == 1)
            {
                layout.height = 320;
            }
            else
            {
                layout.height = 700;
            }

            for (int c = 0; c < numColumns; c++)
            {
                fig.AppendTrace(data, 1, c + 1);
                fig.layout.GetType().GetProperty("yaxis" + (c + 1)).SetValue(fig.layout, new Yaxis
                {
                    title = "",
                    range = new List<int> { minCell, maxCell },
                    showgrid = false,
                    showticklabels = true
                });
            }

            fig.layout = layout;

            string basename = graphename + numColumns;
            PlotlyChart.SaveAs(fig, basename + ".html", true);

            if (plotlyAPIKey != null)
            {
                PlotlyChart.SaveAs(fig, basename + ".pdf", 4);
            }
        }
    }
}


