Project Description:

In this project, our team will be developing a .Net Multi-platform App UI and there will be an interface where we will feed the SDR values from either Spatial pool or Multisequence learning and there will be an interface where we can see the SDR output image.


SDR Plot Generation Method:

This method, newgeneratesdr, is used to generate an SDR (Sparse Distributed Representation) plot based on the provided model. 
The method takes an SdValueModel model as input, which contains the necessary data for generating the plot.

Input Parameters

SdValueModel model: The model containing the data required for plot generation.
fileData: The CSV data for the SDR plot.
graphname: Name of the graph.
axis: Axis information.
maxCycles: Maximum cycles.
hightouch: Highlight touch.
yaxis: Y-axis title.
xaxis: X-axis title.
subplottitle: Subplot title.
fname: Figure name.
datapath: Data path.


Implementation Details
Data Processing: The method reads the CSV data from fileData and processes it to create a list of data sets (dataSets) and a list of all cell values (allCells).
Plot Configuration: 
It calculates the maximum and minimum cell values, maxCell and minCell respectively, and sets other parameters required for plotting.
Plot Generation: 
It sets the current SD in the Filedatahelper and then calls two methods from SdrDrawer to plot the activity vertically and horizontally (PlotActivityVertically and PlotActivityHorizontally respectively).

**Usage**
To use this method, provide an instance of SdValueModel with the required data, and then call newgeneratesdr with this instance as the argument.

SdValueModel model = new SdValueModel
{
    fileData = "CSV Data",
    graphname = "Graph Name",
    axis = "Axis Information",
    maxCycles = 10, // Example value
    hightouch = 5, // Example value
    yaxis = "Y-axis Title",
    xaxis = "X-axis Title",
    subplottitle = "Subplot Title",
    fname = "Figure Name",
    datapath = "Data Path"
};

newgeneratesdr2(model);


Teju


**SDR Plotting Library** 
**Purpose**

The primary purpose of SdrDrawerLib is to visualize activity data in a graphical format, allowing users to analyze patterns and trends in the data. It offers methods to plot activity both vertically and horizontally, providing flexibility in data representation.Namespaces and Classes:
Namespaces:
OxyPlot.Axes, OxyPlot.Series, and OxyPlot: These namespaces belong to the OxyPlot library, which is used for creating plots and charts.
System, System.Collections.Generic, System.IO: Standard .NET namespaces.
NeocortexApi.SdrDrawerLib.Models: Namespace for the SdrDrawer class.

**Classes Used**

**SdrDrawer:** This class contains methods for plotting activity data vertically and horizontally.

**Methods**

**PlotActivityVertically Method:**

Purpose: This method plots activity vertically based on provided parameters.

Parameters:

activeCellsColumn: List of hash sets representing active cells in each column.
highlightTouch: Index of the touch to highlight.
maxCycles: Maximum number of cycles.
minCell, maxCell: Minimum and maximum cell values.
yAxisTitle, xAxisTitle, subPlotTitle, figureName, path: Titles and path parameters for the plot.

Explanation:

It initializes some variables and creates a new plot model.
Iterates over columns and adds series to the plot model, with optional highlighting.
Adds axes to the plot model.
Calculates and appends graph values for each cycle to outputdatavertical.
Sets plot background and border colors.
Specifies the directory for saving the SVG file.
Exports the plot model to an SVG file.
Sets the image path in Filedatahelper and returns the full path of the generated SVG file.

**PlotActivityHorizontally Method:**

Purpose: This method plots activity horizontally based on provided parameters.

Parameters: Same as PlotActivityVertically.

Explanation:

Similar to PlotActivityVertically but plots the data horizontally by swapping the x and y values in the series.
Calculates and appends graph values for each cycle to outputdatahorizontal.
Sets plot background and border colors.
Specifies the directory for saving the SVG file.
Exports the plot model to an SVG file.
Sets the image 



 
