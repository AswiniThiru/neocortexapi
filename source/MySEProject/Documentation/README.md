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


teju

****ML22/23-8 Implement the SDR representation in the MAUI application.****

**Problem Statement**

In the realm of machine learning and neuroscience, Sparse Distributed Representations (SDRs) serve as a cornerstone for encoding complex data patterns. However, the visualization of SDRs, particularly in multi-modal applications, poses significant challenges in terms of accessibility and usability. Existing visualization tools often rely on command-line interfaces or specialized software, limiting their adoption and comprehension among non-technical users. To address this gap, this project endeavors to develop an intuitive, interactive SDR visualization tool within the MAUI framework. By leveraging MAUI's capabilities, this tool aims to empower users of all backgrounds to effortlessly explore and interpret intricate data patterns represented by SDRs. By democratizing SDR visualization, this project seeks to bridge the gap between raw data and actionable insights, fostering innovation and understanding across diverse domains.

**Introduction**

Sparse Distributed Representation (SDR) is a powerful concept in neuroscience and machine learning that enables efficient encoding and representation of information across different domains. Visualization of SDRs plays an important role in understanding their structure, properties, and applications. In this context, the development of software tools to generate SDR images becomes important for researchers and professionals. This research project focuses on creating a multiplatform app UI (MAUI) application for generating SDR images. This application leverages the capabilities of the NeocortexApi framework and different plotting libraries like OxyPlot library and aims to provide the user with an intuitive interface to input parameters and visualize her SDR in 2D.
The motivation behind this project stems from the need for accessible and user-friendly tools to investigate and analyze SDRs. By developing the MAUI application, we aim to democratize the process of SDR visualization and make it available to a wide range of users, including researchers, educators, and hobbyists. The main objective of this research is to bridge the gap between neuroscience, machine learning, and software engineering by providing a practical solution for generating SDR images. This application aims to allow users to explore the complex structures and patterns encoded in her SDR by implementing a user-friendly interface and efficient drawing functionality. 


**NeocortexApi.SdrDrawerLib Library** 

**Purpose**

The primary purpose of SdrDrawerLib is to visualize activity data in a graphical format, allowing users to analyze patterns and trends in the data. It offers methods to plot activity both vertically and horizontally, providing flexibility in data representation.

**Dependencies**

OxyPlot Nuget Package : A .NET library for creating plots and charts.

**Installation**

To use the SDR Plotting Library in your C# projects, follow these steps:

1. Install the OxyPlot.WindowsForms package from NuGet Package Manager or Package 
2. Add references to the library DLL files (SdrDrawerLib.dll, DrawDiagram.Models.dll) in your project.
3. Ensure that all required classes (SdrDrawer, SdValueModal, Filedatahelper, SdrHelper) are accessible in your code files.

**Classes**

**1. SdrDrawer** 

Purpose:

This class contains methods for plotting activity data vertically and horizontally.

**Methods used in SdrDrawer**

**a. PlotActivityVertically Method:**

Purpose: This method plots activity vertically based on provided parameters.

Parameters:

- `activeCellsColumn`: List of hash sets representing active cells in each column.

- `highlightTouch`: Index of the touch to highlight.

- `maxCycles`: Maximum number of cycles.

- `minCell, maxCell`: Minimum and maximum cell values.

- `yAxisTitle, xAxisTitle, subPlotTitle, figureName, path`: Titles and path parameters for the plot.

Explanation:

It initializes some variables and creates a new plot model.
Iterates over columns and adds series to the plot model, with optional highlighting.
Adds axes to the plot model.
Calculates and appends graph values for each cycle to outputdatavertical.
Sets plot background and border colors.
Specifies the directory for saving the SVG file.
Exports the plot model to an SVG file.
Sets the image path in Filedatahelper and returns the full path of the generated SVG file.

**b. PlotActivityHorizontally Method:**

Purpose: This method plots activity horizontally based on provided parameters.

Parameters: Same as PlotActivityVertically.

Explanation:

Similar to PlotActivityVertically but plots the data horizontally by swapping the x and y values in the series.
Calculates and appends graph values for each cycle to outputdatahorizontal.
Sets plot background and border colors.
Specifies the directory for saving the SVG file.
Exports the plot model to an SVG file.
Sets the image 

**2. SdValueModel Class**  

Purpose:

The primary purpose of the SdValueModel class is to provide a structured way to store input parameters and output data for generating diagrams using the `SdrDrawerLib` library. It encapsulates properties for text file paths, graph names, axis titles, range limits, subplot titles, and output data generated during the plotting process.

Properties:

- `textfile`: Path to the text file containing input data.
- `graphname`: Name of the graph or diagram being plotted.
- `maxCycles`: Maximum number of cycles for the plot.
- `hightouch`: Index of the touch to highlight in the plot.
- `yaxis`: Title of the y-axis.
- `xaxis`: Title of the x-axis.
- `minrange`: Minimum value of the range for the plot.
- `maxrange`: Maximum value of the range for the plot.
- `subplottitle`: Title of the subplot.
- `fname`: File name or identifier.
- `axis`: Axis information.
- `fileData`: Data from the input file.
- `datapath`: Path to the data file.
- `outputdatavertical`: Output data generated for vertical plotting.
- `outputdatahorizontal`: Output data generated for horizontal plotting.

Usage:

The SdValueModel class serves as a data container for passing input parameters and storing output data when working with the SdrDrawerLib library. It can be instantiated and populated with relevant values before invoking the plotting methods.

Notes:

- Ensure that the properties are correctly initialized with appropriate values before using them for plotting.
- The SdValueModel class provides a convenient way to organize and manage input and output data for diagram plotting operations.

**3. Filedatahelper Class**

Purpose:

The primary purpose of the Filedatahelper class is to provide convenient methods for accessing and manipulating file data, image paths, and instances of SdValueModal. It serves as a central location for managing these shared resources across multiple components of the library.

Properties:

- `filedata`: A static string property that stores file data as a string.
- `imagepath`: A static string property that stores the image path.
- `Sdvalue`: A static property that stores the current instance of SdValueModal.

**Methods used in Filedatahelper Class**

- `getfiledata()`: Retrieves the stored file data as a string.

- `getimagepath()`: Retrieves the stored image path as a string.

- `getcurrentSD()`: Retrieves the current instance of SdValueModal.

- `setcurrentSD(SdValueModel model)`: Sets the current instance of SdValueModal.

- `setfiledata(string content)`: Sets the file data with the provided content.

- `setimagepath(string path)`: Sets the image path with the provided path.


Usage:

The Filedatahelper class provides static methods and properties that can be accessed directly without instantiation. It can be used to manage file-related operations and store data within the SdrDrawerLib library.

Notes:

- Ensure that the properties and methods of the Filedatahelper class are used appropriately within the context of the SdrDrawerLib library.
- This class provides a centralized approach for managing shared resources and data across different components of the library.

**4. SdrHelper Class**

Purpose:

The primary purpose of the SdrHelper class is to process data from an instance of SdValueModel, extract necessary parameters, and utilize the SdrDrawer class to generate SDR plots both vertically and horizontally.

**Methods used in SdrHelper Class:**

newgeneratesdr(SdValueModel model): Generates SDR plots based on the provided SdValueModel instance. It processes the data, extracts parameters, and invokes methods from the SdrDrawer class to create both vertical and horizontal plots.

Usage:

The SdrHelper class provides a simple interface for generating SDR plots. It accepts an instance of SdValueModel containing relevant data and parameters for plot generation.

Notes:

- Ensure that the SdrDrawer class and SdValueModal model are properly configured before invoking the newgeneratesdr2 method.
- Exception handling is implemented within the method to handle errors during plot generation.
- The generated plots will be saved in SVG format at the specified data path.










 
