using Microsoft.Maui.Graphics;
using System;
using System.Drawing;
using NeoCortexApi;

namespace Test_App;


// Define the ICanvas interface
public interface ICanvas
{
    void DrawLine(int x1, int y1, int x2, int y2);
}

// Implement a class that uses ICanvas to draw a line
public class LineDrawer
{
    private ICanvas canvas;

    public LineDrawer(ICanvas canvas)
    {
        this.canvas = canvas;
    }

    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        canvas.DrawLine(x1, y1, x2, y2);
    }
}

// Example implementation of ICanvas using System.Console
public class ConsoleCanvas : ICanvas
{
    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Drawing line from ({x1}, {y1}) to ({x2}, {y2})");
    }
}


