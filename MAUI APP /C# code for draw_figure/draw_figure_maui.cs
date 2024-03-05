using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Graphics;

class Program
{
    static void Main(string[] args)
    {
        // Parse command line arguments
        if (args.Length < 8)
        {
            Console.WriteLine("Usage: draw_figure <filename> <graphename> <maxcycles> <highlighttouch> <yaxistitle> <xaxistitle> <subplottitle> <figurename>");
            return;
        }

        string filename = args[0];
        string graphename = args[1];
        int maxcycles = int.Parse(args[2]);
        int highlighttouch = int.Parse(args[3]);
        string yAxisTitle = args[4];
        string xAxisTitle = args[5];
        string subPlotTitle = args[6];
        string figureName = args[7];

        // Read data from file
        List<List<int>> dataSets = new List<List<int>>();
        List<int> allCells = new List<int>();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                List<int> cellData = new List<int>();
                foreach (string value in values)
                {
                    cellData.Add(int.Parse(value.Trim()));
                    allCells.Add(int.Parse(value.Trim()));
                }
                dataSets.Add(cellData);
            }
        }

        int maxCell = allCells.Max() + 100;
        int minCell = allCells.Min() - 100;

        // Create graphics surface
        var surface = new GraphicsSurface(800, 600);

        // Draw activity
        if (args.Contains("-a"))
        {
            DrawActivityHorizontally(surface, dataSets, maxcycles, highlighttouch, yAxisTitle, xAxisTitle, subPlotTitle, figureName, maxCell, minCell);
        }
        else
        {
            DrawActivityVertically(surface, dataSets, maxcycles, highlighttouch, yAxisTitle, xAxisTitle, subPlotTitle, figureName, maxCell, minCell);
        }

        // Save or display the plot
        surface.SaveToFile("output.png");
        // Or surface.Show();
    }

    static void DrawActivityVertically(GraphicsSurface surface, List<List<int>> dataSets, int maxcycles, int highlightTouch, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName, int maxCell, int minCell)
    {
        // Draw activity data on the surface vertically
        // Implement your drawing logic here for vertical plots

        // Example:
        // Draw axes
        surface.DrawLine(new SolidPaint { Color = Colors.Black }, 50, 50, 50, 550); // y-axis
        surface.DrawLine(new SolidPaint { Color = Colors.Black }, 50, 550, 750, 550); // x-axis

        // Draw data points
        // Iterate through dataSets and draw data points based on your data

        // Example:
        Random rand = new Random();
        foreach (var dataSet in dataSets)
        {
            for (int i = 0; i < dataSet.Count - 1; i++)
            {
                float x1 = 50 + i * (700 / maxcycles);
                float y1 = 550 - dataSet[i] * (500 / (maxCell - minCell));
                float x2 = 50 + (i + 1) * (700 / maxcycles);
                float y2 = 550 - dataSet[i + 1] * (500 / (maxCell - minCell));
                surface.DrawLine(new SolidPaint { Color = Colors.Blue }, x1, y1, x2, y2);
            }
        }

        // Draw legend, titles, etc.
        // You need to add labels, titles, legends, etc., based on your requirements

        // Example:
        // Add axis titles
        surface.DrawText(xAxisTitle, 400, 570, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 12 });
        surface.DrawText(yAxisTitle, 10, 300, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 12 });

        // Add subplot title
        surface.DrawText(subPlotTitle, 400, 20, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 16 });

        // Add figure name
        surface.DrawText(figureName, 400, 580, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 14 });
    }

    static void DrawActivityHorizontally(GraphicsSurface surface, List<List<int>> dataSets, int maxcycles, int highlightTouch, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName, int maxCell, int minCell)
    {
        // Draw activity data on the surface horizontally
        // Implement your drawing logic here for horizontal plots

        // Example:
        // Draw axes
        surface.DrawLine(new SolidPaint { Color = Colors.Black }, 50, 50, 50, 550); // y-axis
        surface.DrawLine(new SolidPaint { Color = Colors.Black }, 50, 550, 750, 550); // x-axis

        // Draw data points
        // Iterate through dataSets and draw data points based on your data

        // Example:
        Random rand = new Random();
        foreach (var dataSet in dataSets)
        {
            for (int i = 0; i < dataSet.Count - 1; i++)
            {
                float x1 = 50 + dataSet[i] * (700 / (maxCell - minCell));
                float y1 = 550 - i * (500 / maxcycles);
                float x2 = 50 + dataSet[i + 1] * (700 / (maxCell - minCell));
                float y2 = 550 - (i + 1) * (500 / maxcycles);
                surface.DrawLine(new SolidPaint { Color = Colors.Blue }, x1, y1, x2, y2);
            }
        }

        // Draw legend, titles, etc.
        // You need to add labels, titles, legends, etc., based on your requirements

        // Example:
        // Add axis titles
        surface.DrawText(xAxisTitle, 400, 570, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 12 });
        surface.DrawText(yAxisTitle, 10, 300, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 12 });

        // Add subplot title
        surface.DrawText(subPlotTitle, 400, 20, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 16 });

        // Add figure name
        surface.DrawText(figureName, 400, 580, new SolidPaint { Color = Colors.Black }, new TextStyle { FontSize = 14 });
    }
}
