using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Graphics;

class Program
{
    static void Main()
    {
        // Read inputs from the terminal
        Console.WriteLine("Enter filename:");
        string filename = Console.ReadLine();

        Console.WriteLine("Enter graphename:");
        string graphename = Console.ReadLine();

        Console.WriteLine("Enter maxcycles:");
        int maxcycles = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter highlighttouch:");
        int highlighttouch = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter yAxisTitle:");
        string yAxisTitle = Console.ReadLine();

        Console.WriteLine("Enter xAxisTitle:");
        string xAxisTitle = Console.ReadLine();

        Console.WriteLine("Enter subPlotTitle:");
        string subPlotTitle = Console.ReadLine();

        Console.WriteLine("Enter figureName:");
        string figureName = Console.ReadLine();

        // Read data from file
        List<List<int>> dataSets = new List<List<int>>();
        List<int> allCells = new List<int>();

        // Assuming you've replaced this block with file reading from filename variable
        // using (StreamReader reader = new StreamReader(filename))
        // {
        //     string line;
        //     while ((line = reader.ReadLine()) != null)
        //     {
        //         // Read data from file and populate dataSets and allCells
        //     }
        // }

        int maxCell = allCells.Count > 0 ? allCells.Max() + 100 : 100;
        int minCell = allCells.Count > 0 ? allCells.Min() - 100 : 0;

        // Create graphics surface
        var surface = new GraphicsSurface(800, 600);

        // Draw activity
        if (graphename.Contains("-a"))
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
                surface.DrawLine(new SolidPaint { Color = Colors.Blue }, (int)x1, (int)y1, (int)x2, (int)y1);
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
                surface.DrawLine(new SolidPaint { Color = Colors.Blue }, (int)x1, (int)y1, (int)x2, (int)y2);
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

internal class GraphicsSurface
{
    private readonly List<Line> lines = new List<Line>();

    public GraphicsSurface(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; }
    public int Height { get; }

    public void DrawLine(SolidPaint solidPaint, int x1, int y1, int x2, int y2)
    {
        lines.Add(new Line { SolidPaint = solidPaint, X1 = x1, Y1 = y1, X2 = x2, Y2 = y2 });
    }

    public void DrawText(string text, int x, int y, SolidPaint solidPaint, TextStyle textStyle)
    {
        // Implement text drawing logic here
    }

    public void SaveToFile(string filePath)
    {
        // Implement saving to file logic here
    }

    // Inner class to represent a line
    private class Line
    {
        public SolidPaint? SolidPaint { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
    }
}
