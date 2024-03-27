

1:   NeocortexApi.SdrDrawerLib2
     This is class liberary project .NET CORE 8.0 version
     Including Packes this project have classes and functionalities are 

     SDR Plot Generation Method
This method, newgeneratesdr2, is used to generate an SDR (Sparse Distributed Representation) plot based on the provided model. 
The method takes an SdValueModal model as input, which contains the necessary data for generating the plot.

******Input Parameters*****
SdValueModal model: The model containing the data required for plot generation.
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


*******Implementation Details***********
Data Processing: The method reads the CSV data from fileData and processes it to create a list of data sets (dataSets) and a list of all cell values (allCells).
Plot Configuration: 
It calculates the maximum and minimum cell values, maxCell and minCell respectively, and sets other parameters required for plotting.
Plot Generation: 
It sets the current SD in the Filedatahelper and then calls two methods from SdrDrawer to plot the activity vertically and horizontally (PlotActivityVertically and PlotActivityHorizontally respectively).

**Usage**
To use this method, provide an instance of SdValueModal with the required data, and then call newgeneratesdr2 with this instance as the argument.

SdValueModal model = new SdValueModal
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

*****************************************************************************************************************************

### Filedatahelper Class

The `Filedatahelper` class is a utility class that provides methods for storing and retrieving file data, image paths, and instances of the `SdValueModal` class. This class is designed to assist in managing data related to SDR plots.

#### Members

- `filedata`: A static string variable that stores the file data as a string.
- `imagepath`: A static string variable that stores the image path.
- `Sdvalue`: A static instance of the `SdValueModal` class that stores the current `SdValueModal` instance.

#### Methods

- `getfiledata()`: A static method that retrieves the stored file data as a string.
- `getimagepath()`: A static method that retrieves the stored image path as a string.
- `getcurrentSD()`: A static method that retrieves the current `SdValueModal` instance.
- `setcurrentSD(SdValueModal model)`: A static method that sets the current `SdValueModal` instance.
- `setfiledata(string content)`: A static method that sets the file data.
- `setimagepath(string path)`: A static method that sets the image path.

#### Usage

This class can be used to store and retrieve file data, image paths, and `SdValueModal` instances in a convenient and organized manner, making it easier to manage data related to SDR plots in the application.





********************************************************************************************************************************************

****   DrawDiagram MAUI Application *************

This is Cross platform application which include Class liberary Project To Plot the graph 

FLOW
 
 USER select .txt or excel file which having data Application first read the content and save in helperclass and then click on next button and then select some parameters to plot the specific Graph and On submit button click the filedata content and other information passed in a modal to generater class and generate two graph Horizontal and vertical and file saved in directory and then open the Output page where display graph in image and txt formate and user can also change their. 






           