//using System;
//using System.Collections.Generic;
//using SkiaSharp;
//using SkiaSharp.Views.Desktop;

//namespace SDRDrawer
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            if (args.Length < 11)
//            {
//                Console.WriteLine("Insufficient command line arguments.");
//                return;
//            }

//            string filename = args[0];
//            string graphename = args[1];
//            int maxcycles = int.Parse(args[2]);
//            int highlighttouch = int.Parse(args[3]);
//            string axis = args[4];
//            string yaxistitle = args[5];
//            string xaxistitle = args[6];
//            int? mincellrange = args[7] != null ? int.Parse(args[7]) : (int?)null;
//            int? maxcellrange = args[8] != null ? int.Parse(args[8]) : (int?)null;
//            string subplottitle = args[9];
//            string figurename = args[10];

//            string[] lines = System.IO.File.ReadAllLines(filename);
//            List<List<int>> dataSets = new List<List<int>>();

//            foreach (string line in lines)
//            {
//                string[] values = line.Split(',');
//                List<int> dataSet = new List<int>();

//                foreach (string value in values)
//                {
//                    dataSet.Add(int.Parse(value));
//                }

//                dataSets.Add(dataSet);
//            }

//            PlotActivity(dataSets, highlighttouch, xaxistitle, yaxistitle, graphename, maxcycles);

//            Console.WriteLine("SDR image generated successfully!");
//        }

//        static void PlotActivity(List<List<int>> activeCellsColumn, int highlightTouch, string xaxisTitle, string yaxisTitle, string graphename, int maxcycles)
//        {
//            int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
//            int numColumns = activeCellsColumn[0].Count;
//            int cellSize = 6;
//            int spacing = 4;
//            int imageSizeX = (numColumns * cellSize) + ((numColumns - 1) * spacing) + 100;
//            int imageSizeY = (numTouches * cellSize) + ((numTouches - 1) * spacing) + 100;

//            using (var surface = SKSurface.Create(imageSizeX, imageSizeY, SKColorType.Rgba8888, SKAlphaType.Premul))
//            {
//                SKCanvas canvas = surface.Canvas;
//                canvas.Clear(SKColors.White);

//                for (int t = 0; t < numTouches; t++)
//                {
//                    for (int c = 0; c < numColumns; c++)
//                    {
//                        int cell = activeCellsColumn[t][c];
//                        if (cell == 1)
//                        {
//                            SKPaint paint = new SKPaint
//                            {
//                                Color = SKColors.Black
//                            };
//                            SKRect rect = SKRect.Create((cellSize + spacing) * c, (cellSize + spacing) * t, cellSize, cellSize);
//                            canvas.DrawRect(rect, paint);
//                        }
//                    }
//                }

//                // Highlight touch
//                if (highlightTouch < numTouches)
//                {
//                    SKPaint highlightPaint = new SKPaint
//                    {
//                        Color = new SKColor(255, 0, 0, 128)
//                    };
//                    SKRect highlightRect = SKRect.Create(0, (cellSize + spacing) * highlightTouch, imageSizeX, cellSize);
//                    canvas.DrawRect(highlightRect, highlightPaint);
//                }

//                // Draw axis titles
//                SKPaint textPaint = new SKPaint
//                {
//                    Color = SKColors.Black,
//                    TextAlign = SKTextAlign.Center,
//                    TextSize = 20
//                };
//                canvas.DrawText(xaxisTitle, imageSizeX / 2, imageSizeY - 10, textPaint);
//                canvas.RotateDegrees(-90);
//                canvas.DrawText(yaxisTitle, -imageSizeY / 2, 20, textPaint);

//                // Save image
//                using (var image = surface.Snapshot())
//                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
//                using (var stream = System.IO.File.Create($"{graphename}.png"))
//                {
//                    data.SaveTo(stream);
//                }
//            }
//        }
//    }
//}





//CODE - 2 Better than 1, either generating xaxis or yaxsis



using System;
using System.Collections.Generic;
using System.IO;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace NeocortexApi.SdrDrawerLib
{
    class SdrDrawer
    {
        static void Main(string[] args)
        {
            if (args.Length < 11)
            {
                Console.WriteLine("Insufficient command line arguments.");
                return;
            }

            string filename = args[0];
            string graphename = args[1];
            int maxcycles = int.Parse(args[2]);
            int highlighttouch = int.Parse(args[3]);
            string axis = args[4];
            string yaxistitle = args[5];
            string xaxistitle = args[6];
            int? mincellrange = args[7] != null ? int.Parse(args[7]) : (int?)null;
            int? maxcellrange = args[8] != null ? int.Parse(args[8]) : (int?)null;
            string subplottitle = args[9];
            string figurename = args[10];

            List<List<HashSet<int>>> dataSets = new List<List<HashSet<int>>>();
            List<int> allCells = new List<int>();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    List<HashSet<int>> dataSet = new List<HashSet<int>>();

                    foreach (string value in values)
                    {
                        int cell = int.Parse(value.Trim());
                        allCells.Add(cell);
                        dataSet.Add(new HashSet<int>() { cell });
                    }

                    dataSets.Add(dataSet);
                }
            }

            int maxCell = allCells.Max() + 100;
            int minCell = allCells.Min() - 100;

            //if (axis == "x")
            //{
            //    PlotActivityHorizontally(dataSets, highlighttouch, maxcycles, graphename, xaxistitle, yaxistitle, figurename, minCell, maxCell);
            //}
            //else
            //{
            //    PlotActivityVertically(dataSets, highlighttouch, maxcycles, graphename, xaxistitle, yaxistitle, figurename, minCell, maxCell);
            //}
            if (axis == "x")
            {
                PlotActivityHorizontally(dataSets, highlighttouch, maxcycles, graphename, xaxistitle, yaxistitle, figurename, minCell, maxCell);
                PlotActivityVertically(dataSets, highlighttouch, maxcycles, graphename, xaxistitle, yaxistitle, figurename, minCell, maxCell);
            }
            else
            {
                PlotActivityVertically(dataSets, highlighttouch, maxcycles, graphename, xaxistitle, yaxistitle, figurename, minCell, maxCell);
                PlotActivityHorizontally(dataSets, highlighttouch, maxcycles, graphename, xaxistitle, yaxistitle, figurename, minCell, maxCell);
            }

            Console.WriteLine("SDR image generated successfully!");
        }

        static void PlotActivityVertically(List<List<HashSet<int>>> activeCellsColumn, int highlightTouch, int maxcycles, string graphename, string xaxistitle, string yaxistitle, string figurename, int minCell, int maxCell)
        {
            int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;
            int cellWidth = 6;
            int cellHeight = 6;
            int cellSpacing = 4;

            using (var surface = SKSurface.Create(new SKImageInfo(700, 600)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                for (int t = 0; t < activeCellsColumn.Count; t++)
                {
                    if (t < numTouches)
                    {
                        for (int c = 0; c < activeCellsColumn[t].Count; c++)
                        {
                            foreach (int cell in activeCellsColumn[t][c])
                            {
                                var paint = new SKPaint
                                {
                                    Color = SKColors.Black,
                                    IsStroke = false,
                                    Style = SKPaintStyle.Fill
                                };
                                var rect = SKRect.Create(
                                    c * (cellWidth + cellSpacing),
                                    t * (cellHeight + cellSpacing),
                                    cellWidth,
                                    cellHeight);
                                canvas.DrawRect(rect, paint);
                            }

                            if (t == highlightTouch)
                            {
                                var paint = new SKPaint
                                {
                                    Color = new SKColor(255, 0, 0, 128),
                                    IsStroke = true,
                                    StrokeWidth = 3
                                };
                                var rect = SKRect.Create(
                                    c * (cellWidth + cellSpacing),
                                    0,
                                    cellWidth,
                                    (numTouches + 1) * (cellHeight + cellSpacing)); // Adjust height to cover all touches
                                canvas.DrawRect(rect, paint);
                            }
                        }
                    }
                }

                using (var paint = new SKPaint())
                {
                    paint.TextSize = 20;
                    paint.Color = SKColors.Black;
                    canvas.DrawText(xaxistitle, 10, 600, paint);

                    paint.TextSize = 24;
                    canvas.DrawText(figurename + "\n" + "<b>th</b>", 350, 600, paint);
                }

                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite($"{graphename}{numColumns}.png"))
                {
                    data.SaveTo(stream);
                }
            }
        }

        static void PlotActivityHorizontally(List<List<HashSet<int>>> activeCellsColumn, int highlightTouch, int maxcycles, string graphename, string xaxistitle, string yaxistitle, string figurename, int minCell, int maxCell)
        {
            int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;
            int cellWidth = 6;
            int cellHeight = 6;
            int cellSpacing = 4;

            using (var surface = SKSurface.Create(new SKImageInfo(700, 600)))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.White);

                for (int t = 0; t < activeCellsColumn.Count; t++)
                {
                    if (t < numTouches)
                    {
                        for (int c = 0; c < activeCellsColumn[t].Count; c++)
                        {
                            foreach (int cell in activeCellsColumn[t][c])
                            {
                                var paint = new SKPaint
                                {
                                    Color = SKColors.Black,
                                    IsStroke = false,
                                    Style = SKPaintStyle.Fill
                                };
                                var rect = SKRect.Create(
                                    c * (cellWidth + cellSpacing),
                                    t * (cellHeight + cellSpacing),
                                    cellWidth,
                                    cellHeight);
                                canvas.DrawRect(rect, paint);
                            }

                            if (t == highlightTouch)
                            {
                                var paint = new SKPaint
                                {
                                    Color = new SKColor(255, 0, 0, 128),
                                    IsStroke = true,
                                    StrokeWidth = 3
                                };
                                var rect = SKRect.Create(
                                    0,
                                    c * (cellHeight + cellSpacing),
                                    (numTouches + 1) * (cellWidth + cellSpacing), // Adjust width to cover all touches
                                    cellHeight);
                                canvas.DrawRect(rect, paint);
                            }
                        }
                    }
                }

                using (var paint = new SKPaint())
                {
                    paint.TextSize = 20;
                    paint.Color = SKColors.Black;
                    canvas.DrawText(yaxistitle, 10, 600, paint);

                    paint.TextSize = 24;
                    canvas.DrawText(figurename + "\n" + "<b>Three</b>", 350, 600, paint);
                }

                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite($"{graphename}{numColumns}.png"))
                {
                    data.SaveTo(stream);
                }
            }
        }
    }
}














////CODE 1- random image


//using Microsoft.Maui.Graphics;
//using Microsoft.Maui.Graphics.Skia;
//using SkiaSharp;
//using SkiaSharp.Views.Maui;
//using System;
//using System.IO;
//using System.Collections.Generic;
//using CsvHelper;

//namespace NeocortexApi.SdrDrawerLib
//{
//    class SdrDrawer
//    {
//        static void Main(string[] args)
//        {
//            if (args.Length < 11)
//            {
//                Console.WriteLine("Insufficient command line arguments.");
//                return;
//            }

//            string filename = args[0];
//            string graphename = args[1];
//            int maxcycles = int.Parse(args[2]);
//            int highlighttouch = int.Parse(args[3]);
//            string axis = args[4];
//            string yaxistitle = args[5];
//            string xaxistitle = args[6];
//            int? mincellrange = args[7] != null ? int.Parse(args[7]) : (int?)null;
//            int? maxcellrange = args[8] != null ? int.Parse(args[8]) : (int?)null;
//            string subplottitle = args[9];
//            string figurename = args[10];
//            string[] lines = File.ReadAllLines(filename);
//            List<List<HashSet<int>>> dataSets = new List<List<HashSet<int>>>();
//            List<int> allCells = new List<int>();

//            foreach (string line in lines)
//            {
//                string[] values = line.Split(',');
//                List<HashSet<int>> dataSet = new List<HashSet<int>>();

//                foreach (string value in values)
//                {
//                    int cell = int.Parse(value.Trim());
//                    allCells.Add(cell);
//                    dataSet.Add(new HashSet<int>() { cell });
//                }

//                dataSets.Add(dataSet);
//            }

//            int maxCell = allCells.Max() + 100;
//            int minCell = allCells.Min() - 100;

//            // Rest of your code here...
//            Console.WriteLine("SDR image generated successfully!");



//            if (axis == "x")
//            {
//                PlotActivityHorizontally(dataSets, highlighttouch);
//            }
//            else
//            {
//                PlotActivityVertically(dataSets, highlighttouch);
//            }

//            void PlotActivityVertically(List<List<HashSet<int>>> activeCellsColumn, int highlightTouch)
//            {
//                int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
//                int numColumns = activeCellsColumn[0].Count;
//                int cellWidth = 6;
//                int cellHeight = 6;
//                int cellSpacing = 4;

//                using (var surface = SKSurface.Create(new SKImageInfo(700, 600)))
//                {
//                    var canvas = surface.Canvas;
//                    canvas.Clear(SKColors.White);

//                    for (int t = 0; t < numTouches; t++)
//                    {
//                        for (int c = 0; c < numColumns; c++)
//                        {
//                            foreach (int cell in activeCellsColumn[t][c])
//                            {
//                                var paint = new SKPaint
//                                {
//                                    Color = SKColors.Black,
//                                    IsStroke = false, // Ensure rectangles are filled
//                                    Style = SKPaintStyle.Fill // Fill the rectangles
//                                };
//                                var rect = SKRect.Create(
//                                    c * (cellWidth + cellSpacing),
//                                    t * (cellHeight + cellSpacing),
//                                    cellWidth,
//                                    cellHeight);
//                                canvas.DrawRect(rect, paint);
//                            }

//                            if (t == highlightTouch)
//                            {
//                                var paint = new SKPaint
//                                {
//                                    Color = new SKColor(255, 0, 0, 128),
//                                    IsStroke = true,
//                                    StrokeWidth = 1
//                                };
//                                var rect = SKRect.Create(
//                                    c * (cellWidth + cellSpacing),
//                                    0,
//                                    cellWidth,
//                                    (numTouches + 1) * (cellHeight + cellSpacing)); // Adjust height to cover all touches
//                                canvas.DrawRect(rect, paint);
//                            }
//                        }
//                    }

//                    // Draw axis titles and figure name
//                    using (var paint = new SKPaint())
//                    {
//                        paint.TextSize = 20;
//                        paint.Color = SKColors.Black;
//                        canvas.DrawText(xaxistitle, 10, 600, paint);

//                        paint.TextSize = 24;
//                        canvas.DrawText(figurename + "\n" + "<b>Three cortical columns</b>", 350, 600, paint);
//                    }

//                    // Save the image to a file
//                    using (var image = surface.Snapshot())
//                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
//                    using (var stream = File.OpenWrite($"{graphename}{numColumns}.png"))
//                    {
//                        data.SaveTo(stream);
//                    }
//                }
//            }



//            void PlotActivityHorizontally(List<List<HashSet<int>>> activeCellsColumn, int highlightTouch)
//            {
//                int numTouches = Math.Min(maxcycles, activeCellsColumn.Count);
//                int numColumns = activeCellsColumn[0].Count;

//                using (var surface = SKSurface.Create(new SKImageInfo(700, 600)))
//                {
//                    var canvas = surface.Canvas;
//                    canvas.Clear(SKColors.White);

//                    for (int t = 0; t < activeCellsColumn.Count; t++)
//                    {
//                        if (t <= numTouches)
//                        {
//                            for (int c = 0; c < activeCellsColumn[t].Count; c++)
//                            {
//                                foreach (int cell in activeCellsColumn[t][c])
//                                {
//                                    var paint = new SKPaint
//                                    {
//                                        Color = SKColors.Black,
//                                        IsStroke = true,
//                                        StrokeWidth = 2
//                                    };
//                                    var rect = SKRect.Create(cell * 10, t * 10, 6, 6);
//                                    canvas.DrawRect(rect, paint);
//                                }

//                                if (t == highlightTouch)
//                                {
//                                    var paint = new SKPaint
//                                    {
//                                        Color = new SKColor(255, 0, 0, 128),
//                                        IsStroke = true,
//                                        StrokeWidth = 3
//                                    };
//                                    var rect = SKRect.Create(-95 * 10, t * 10, 4100, 4100);
//                                    canvas.DrawRect(rect, paint);
//                                }
//                            }
//                        }
//                    }

//                    using (var paint = new SKPaint())
//                    {
//                        paint.TextSize = 20;
//                        paint.Color = SKColors.Black;
//                        canvas.DrawText(xaxistitle, 10, 600, paint);

//                        paint.TextSize = 24;
//                        canvas.DrawText(figurename + "\n" + "<b>Three cortical columns</b>", 350, 600, paint);
//                    }

//                    using (var image = surface.Snapshot())
//                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
//                    using (var stream = File.OpenWrite($"{graphename}{numColumns}.png"))
//                    {
//                        data.SaveTo(stream);
//                    }
//                }
//            }
//        }
//    }
//}


















////using System;
////using CsvHelper;
////using SkiaSharp;

////namespace NeocortexApi.SdrDrawerLib
////{
////    public class SdrDrawer
////    {
////        public SdrDrawer()
////        {
////        }
////    }
////}

