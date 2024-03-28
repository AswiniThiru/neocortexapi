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
 
