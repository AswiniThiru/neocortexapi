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

`OxyPlot Nuget Package` : A .NET library for creating plots and charts.

**Installation**

To use the SDR Plotting Library in your C# projects, follow these steps:

1. Install the OxyPlot.WindowsForms package from NuGet Package Manager or Package 
2. Add references to the library DLL files (SdrDrawerLib.dll, DrawDiagram.Models.dll) in your project.
3. Ensure that all required classes (SdrDrawer, SdValueModal, Filedatahelper, SdrHelper) are accessible in your code files.

**Classes**

**1. SdrDrawer Class** 

Purpose:

This class contains methods for plotting activity data vertically and horizontally.

**Methods used in SdrDrawer Class**

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


**MAUI Desktop App**

The MAUI desktop app is a multi-platform application built using the .NET MAUI framework, allowing users to generate and visualize Sparse Distributed Representation (SDR) diagrams. SDR is a data representation technique commonly used in various fields such as neuroscience, machine learning, and pattern recognition.

**Dependencies**

The MAUI desktop app relies on the following dependencies:

- `DrawDiagram.Models`: Contains the SdValueModel class for managing input parameters.

- `NeocortexApi.SdrDrawerLib`: Provides the SdrHelper class for generating SDR diagrams.

- `Microsoft.AspNetCore.Components`: Required for handling components in Blazor apps.
  
- `Microsoft.JSInterop`: Used for JavaScript interoperation for UI interactions.

**File Handling and Processing Page - Home Page**

The File Handling and Processing Page is a component of the MAUI desktop app responsible for managing file input from the user, processing the content of the selected file, and transitioning to other pages or actions based on the processed data.

**Functionality**

**a. HandleFileChange Method:**
- Handles the event triggered when a file is selected by the user.

- Reads the content of the selected file asynchronously and stores it in a string variable.

- Invokes the Processcontent method to process the file content.

**b. Gotoinout Method:**

- Invoked to proceed to another page or action.

- Checks if a file has been selected; if not, it triggers the file processing.

- Displays an alert if the file data is empty.

- Sets the file data using Filedatahelper.setfiledata and navigates to another page.

**c. Processcontent Method:**

- Processes the content of the selected file to extract relevant information.

- Uses regular expressions to identify specific patterns in the file content.

- Cleans up the file content by removing certain patterns using regex replacement.

- Extracts cycle values from the file content and sets the Filedatahelper.imagepath accordingly.

**Usage**

1. Selecting a File:

- Users can select a file using the provided file input component.

- The selected file's content is then processed and prepared for further actions.

2. Processing File Content:

- The content of the selected file is cleaned and relevant information is extracted using regex patterns.

- Cycle values are identified and used to set the image path for further processing.

3. Navigating to Other Pages:
  
- After processing the file content, users can proceed to other pages or actions within the app.

- Empty file data triggers an alert to notify the user before proceeding.

**Input Page**

The Input Page is a component of the MAUI desktop app responsible for gathering user input to configure parameters for generating Sparse Distributed Representation (SDR) diagrams.

**Functionality**

**a. Initialization:**

Upon initialization, the maxCycles property of the SdValueModel instance (model) is set based on the value retrieved from Filedatahelper.imagepath.

**b. HandleClick Method:**

- Validates the input fields in the form.

- If all required fields are filled, retrieves file data from Filedatahelper.getfiledata().

- Sets the application data path and generates the SDR diagram based on the input parameters using SdrHelper.newgeneratesdr.

- Navigates to the "output" page to display the generated diagram.

**c. BackToHome Method:**

- Navigates back to the home page ("/").

- SetDefaultValue Method:

- Sets default values for the input fields in the form.

- Invokes JavaScript interop to set default values in the UI.

- Updates the UI state.

**d. SetManualValue Method:**

- Allows the user to manually edit input values.

- Invokes JavaScript interop to enable manual editing in the UI.

- Updates the UI state.

**Usage**

1. Input Form: Users fill out the input form with parameters required for generating the SDR diagram.

2. Validation: Input fields are validated to ensure all required fields are filled.

3. Generation of SDR Diagram: Upon successful validation, the SDR diagram is generated based on the provided parameters.

4. Navigation: Users can navigate back to the home page or proceed to view the generated diagram.

**Output Page**

The Output Page is a component of the MAUI desktop app responsible for displaying and managing the output generated from Sparse Distributed Representation (SDR) diagrams.

**Functionality**

**a. Initialization:** 

Upon initialization, the vertical plot is enabled by default (isVerticalPlotEnabled).

**b. SVGPathAsync Method:**

Asynchronously fetches SVG path from a file and generates SDR diagrams based on the retrieved data.

**c. GetBase64Image Method:**

Converts an SVG file to a base64 string for download.

**d. onchangefilename Method:**

- Handles the event when the filename is changed.

- Updates the filename in Filedatahelper.Sdvalue and generates a new graph.

**e. HandleInput Method:**

- Handles the input event and updates the progress value.

- Updates Filedatahelper.Sdvalue.maxCycles and generates a new graph.

**f. DownloadImage Method:**

- Downloads the generated SVG images as horizontal and vertical plots.

- Invokes JavaScript interop to initiate the download and displays an alert upon completion.

**Usage**

1. Manual Input and Adjustment: Input the filename and adjust the progress value to generate customized SDR diagrams.

2. Download Images: Download the generated horizontal and vertical SVG images for further use or sharing.















 
