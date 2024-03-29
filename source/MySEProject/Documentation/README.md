
# ML23/24-7 Implement the SDR representation in the MAUI application.


## Introduction

Sparse Distributed Representation (SDR) is a powerful concept in neuroscience and machine learning that enables efficient encoding and representation of information across different domains. Visualization of SDRs plays an important role in understanding their structure, properties, and applications. In this context, the development of software tools to generate SDR images becomes important for researchers and professionals. This research project focuses on creating a multiplatform app UI (MAUI) application for generating SDR images. This application leverages the capabilities of the NeocortexApi framework and different plotting libraries like OxyPlot library and aims to provide the user with an intuitive interface to input parameters and visualize her SDR in 2D.
The motivation behind this project stems from the need for accessible and user-friendly tools to investigate and analyze SDRs. By developing the MAUI application, we aim to democratize the process of SDR visualization and make it available to a wide range of users, including researchers, educators, and hobbyists. The main objective of this research is to bridge the gap between neuroscience, machine learning, and software engineering by providing a practical solution for generating SDR images. This application aims to allow users to explore the complex structures and patterns encoded in her SDR by implementing a user-friendly interface and efficient drawing functionality. 


## Architecture



## Exploring NeocortexApi.SdrDrawerLib Library

### Purpose

The primary purpose of SdrDrawerLib is to visualize activity data in a graphical format, allowing users to analyze patterns and trends in the data. It offers methods to plot activity both vertically and horizontally, providing flexibility in data representation.

## Classes

### 1. SdrDrawer Class

Purpose:

This class contains methods for plotting activity data vertically and horizontally.

#### Methods used in SdrDrawer Class

**a. PlotActivityVertically Method:**

Purpose: This method plots activity vertically based on provided parameters.

Parameters:

- `activeCellsColumn`: List of hash sets representing active cells in each column.

- `highlightTouch`: Index of the touch to highlight.

- `maxCycles`: Maximum number of cycles.

- `minCell, maxCell`: Minimum and maximum cell values.

- `yAxisTitle, xAxisTitle, subPlotTitle, figureName, path`: Titles and path parameters for the plot.

Code:
```
public static string PlotActivityVertically(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName, string path)
        {
            // Initialize outputdata to empty string
            Filedatahelper.Sdvalue.outputdatavertical = "";

            // Calculate the number of touches and columns
            int numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;

            // Create a new plot model with the provided figure name
            var model = new PlotModel { Title = subPlotTitle };

            // Set default and border colors for the RectangleBarSeries
            var defaultSeriesColor = OxyColor.FromRgb(64,224,208);
            var borderSeriesColor = OxyColor.FromRgb(0,0,0); 

            // Iterate over columns and add series to the plot model
            for (int c = 0; c < numColumns; c++)
            {
                var series = new RectangleBarSeries { Title = $"Column {c + 1}", FillColor = defaultSeriesColor, StrokeColor = borderSeriesColor }; // Set fill color to  and border color to orange

                // Add items to the series for each touch and cell
                for (int t = 0; t < activeCellsColumn.Count; t++)
                {
                    if (t == highlightTouch)
                    {
                        series.Items.Add(new RectangleBarItem(t - 0.5, -95, t + 0.5, 4100)); // Highlight the touch
                    }

                    foreach (var cell in activeCellsColumn[t])
                    {
                        series.Items.Add(new RectangleBarItem(t, cell, t + 0.6, cell + 1)); // Add cell to the series
                    }
                }

                model.Series.Add(series); // Add the series to the plot model
            }

            // Add axes to the plot model
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = xAxisTitle, Minimum = 0, Maximum = numTouches });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = yAxisTitle, Minimum = minCell, Maximum = maxCell });

            // Calculate and append graph values for each cycle to the outputdatavertical
            for (int i = 0; i < numTouches; i++)
            {
                double xValue = i;
                double yValue = (double)i / numTouches * (maxCell - minCell) + minCell;
                Filedatahelper.Sdvalue.outputdatavertical += $"Cycle {i + 1}: X={xValue}, Y={yValue}<br/>";
            }

            // Set plot background and border colors
            model.PlotAreaBackground = OxyColor.FromRgb(227, 253, 215);
            model.PlotAreaBorderColor = OxyColor.FromRgb(227, 253, 215);

            // Specify the directory where the SVG file will be saved
            string directory = $"C:\\svgimages";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string svgFilePath = Path.Combine(directory, $"VerticalPlot.svg");

            // Export the plot model to an SVG file
            var exporter = new SvgExporter { Width = 400, Height = 500 };
            using (var stream = new FileStream(svgFilePath, FileMode.Create))
            {
                exporter.Export(model, stream);
            }

            Filedatahelper.setimagepath(directory); // Set the image path in Filedatahelper
            return Path.GetFullPath(directory); // Return the full path of the generated SVG file
        }
```

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

Code:

```
public static string PlotActivityHorizontally(List<HashSet<int>> activeCellsColumn, int highlightTouch, int maxCycles, int minCell, int maxCell, string yAxisTitle, string xAxisTitle, string subPlotTitle, string figureName, string path)
        {
            // Initialize outputdata to empty string
            Filedatahelper.Sdvalue.outputdatahorizontal = "";

            // Calculate the number of touches and columns
            int numTouches = Math.Min(maxCycles, activeCellsColumn.Count);
            int numColumns = activeCellsColumn[0].Count;

            // Create a new plot model with the provided figure name
            var model = new PlotModel { Title = subPlotTitle };

            // Set default and border colors for the RectangleBarSeries
            var defaultSeriesColor = OxyColor.FromRgb(64, 224, 208);    
            var borderSeriesColor = OxyColor.FromRgb(0,0,0); // black for border

            // Iterate over columns and add series to the plot model
            for (int c = 0; c < numColumns; c++)
            {
                var series = new RectangleBarSeries { Title = $"Column {c + 1}", FillColor = defaultSeriesColor, StrokeColor = borderSeriesColor }; // Set fill color to blue and border color to orange

                // Add items to the series for each touch and cell
                for (int t = 0; t < activeCellsColumn.Count && t <= numTouches; t++)
                {
                    if (t == highlightTouch)
                    {
                        series.Items.Add(new RectangleBarItem(-95, t - 0.5, 4100, t + 0.5)); // Highlight the touch
                    }

                    foreach (var cell in activeCellsColumn[t])
                    {
                        series.Items.Add(new RectangleBarItem(cell, t, cell + 1, t + 0.6)); // Add cell to the series
                    }
                }

                model.Series.Add(series); // Add the series to the plot model
            }

            // Add axes to the plot model
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = xAxisTitle, Minimum = minCell, Maximum = maxCell });
            model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = yAxisTitle, Minimum = 0, Maximum = numTouches });

            // Calculate and append graph values for each cycle to the outputdatahorizontal
            for (int i = 0; i < numTouches; i++)
            {
                double xValue = i;
                double yValue = (double)i / numTouches * (maxCell - minCell) + minCell;
                Filedatahelper.Sdvalue.outputdatahorizontal += $"Cycle {i + 1}: X={xValue}, Y={yValue}<br/>";
            }

            // Set plot background and border colors
            model.PlotAreaBackground = OxyColor.FromRgb(227, 253, 215);
            model.PlotAreaBorderColor = OxyColor.FromRgb(227, 253, 215);

            // Specify the directory where the SVG file will be saved
            string directory = $"C:\\svgimages";
            if (!Directory.Exists(directory))
			{ Directory.CreateDirectory(directory); }
                

            string svgFilePath = Path.Combine(directory, $"HorizontalPlot.svg");

            var exporter = new SvgExporter { Width = 400, Height = 500 };
			using (var stream = new FileStream(svgFilePath, FileMode.Create))
			{
				exporter.Export(model, stream);
			}

            // Set Image directory as static 
            Filedatahelper.setimagepath(directory);
            // Return the full path of the generated SVG file
            return Path.GetFullPath(directory);
		}
```

Explanation:

Similar to PlotActivityVertically but plots the data horizontally by swapping the x and y values in the series.
Calculates and appends graph values for each cycle to outputdatahorizontal.
Sets plot background and border colors.
Specifies the directory for saving the SVG file.
Exports the plot model to an SVG file.
Sets the image 

### 2. SdValueModel Class

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

Code:

```
namespace DrawDiagram.Models
{
	public class SdValueModel
	{
		public  string textfile { get; set; } = "";
		public  string graphname { get; set; } = "";
		public  int maxCycles { get; set; } = 0;
		public  int hightouch { get; set; } = 0;
		public  string yaxis { get; set; } = "";
		public  string xaxis { get; set; } = "";
		public  int minrange { get; set; } = 0;
		public  int maxrange { get; set; } = 0;
		public  string subplottitle { get; set; } = "";
		public  string fname { get; set; } = "";
		public  string axis { get; set; } = "";
		public string fileData { get; set; } = "";
		public string datapath { get; set; } = "";
		public string outputdatavertical { get; set; } = "";
        public string outputdatahorizontal { get; set; } = "";
    }
}

```

Usage:

The SdValueModel class serves as a data container for passing input parameters and storing output data when working with the SdrDrawerLib library. It can be instantiated and populated with relevant values before invoking the plotting methods.

Notes:

- Ensure that the properties are correctly initialized with appropriate values before using them for plotting.
- The SdValueModel class provides a convenient way to organize and manage input and output data for diagram plotting operations.

### 3. Filedatahelper Class

Purpose:

The primary purpose of the Filedatahelper class is to provide convenient methods for accessing and manipulating file data, image paths, and instances of SdValueModal. It serves as a central location for managing these shared resources across multiple components of the library.

Properties:

- `filedata`: A static string property that stores file data as a string.
- `imagepath`: A static string property that stores the image path.
- `Sdvalue`: A static property that stores the current instance of SdValueModal.

#### Methods used in Filedatahelper Class

- `getfiledata()`: Retrieves the stored file data as a string.

- `getimagepath()`: Retrieves the stored image path as a string.

- `getcurrentSD()`: Retrieves the current instance of SdValueModal.

- `setcurrentSD(SdValueModel model)`: Sets the current instance of SdValueModal.

- `setfiledata(string content)`: Sets the file data with the provided content.

- `setimagepath(string path)`: Sets the image path with the provided path.

Code:

```
public static class Filedatahelper
    {
        /// <summary>
        /// Stores the file data as a string.
        /// </summary>
        public static string filedata;

        /// <summary>
        /// Stores the image path.
        /// </summary>
        public static string imagepath;

        /// <summary>
        /// Stores the current SdValueModel instance.
        /// </summary>
        public static SdValueModel Sdvalue = new SdValueModel();

        /// <summary>
        /// Retrieves the file data.
        /// </summary>
        /// <returns>The file data as a string.</returns>
        public static string getfiledata()
        {
            return filedata;
        }

        /// <summary>
        /// Retrieves the image path.
        /// </summary>
        /// <returns>The image path as a string.</returns>
        public static string getimagepath()
        {
            return imagepath;
        }

        /// <summary>
        /// Retrieves the current SdValueModel instance.
        /// </summary>
        /// <returns>The current SdValueModel instance.</returns>
        public static SdValueModel getcurrentSD()
        {
            return Sdvalue;
        }

        /// <summary>
        /// Sets the current SdValueModel instance.
        /// </summary>
        /// <param name="model">The SdValueModel instance to set.</param>
        public static void setcurrentSD(SdValueModel model)
        {
            Sdvalue = model;
        }

        /// <summary>
        /// Sets the file data.
        /// </summary>
        /// <param name="content">The file data to set.</param>
        public static void setfiledata(string content)
        {
            filedata = content;
        }

        /// <summary>
        /// Sets the image path.
        /// </summary>
        /// <param name="path">The image path to set.</param>
        public static void setimagepath(string path)
        {
            imagepath = path;
        }
    }
```

Usage:

The Filedatahelper class provides static methods and properties that can be accessed directly without instantiation. It can be used to manage file-related operations and store data within the SdrDrawerLib library.

Notes:

- Ensure that the properties and methods of the Filedatahelper class are used appropriately within the context of the SdrDrawerLib library.
- This class provides a centralized approach for managing shared resources and data across different components of the library.

### 4. SdrHelper Class

Purpose:

The primary purpose of the SdrHelper class is to process data from an instance of SdValueModel, extract necessary parameters, and utilize the SdrDrawer class to generate SDR plots both vertically and horizontally.

#### Methods used in SdrHelper Class:

newgeneratesdr(SdValueModel model): Generates SDR plots based on the provided SdValueModel instance. It processes the data, extracts parameters, and invokes methods from the SdrDrawer class to create both vertical and horizontal plots.

Code:

```
public static class SdrHelper
    {
        /// <summary>
        /// Generates an SDR plot based on the provided SdValueModel instance.
        /// </summary>
        /// <param name="model">The SdValueModel instance containing the data for the plot.</param>
        public static void newgeneratesdr(SdValueModel model)
        {
            try
            {
                // Initializing list for datasets.
                List<HashSet<int>> dataSets = new List<HashSet<int>>();
                // Initializing list for all cells.
                List<int> allCells = new List<int>();

                // Assuming the fileContent contains the CSV data for the SDR plot.
                string fileContent = model.fileData;
                string[] lines = fileContent.Split('\n');
				
				// Processing each line of the CSV data.
				foreach (var line in lines)
                {
					var values = line.Split(',');
                    // Initializing HashSet for each line.
                    HashSet<int> cellSet = new HashSet<int>();
                    foreach (var value in values)
                    {
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            // Parsing cell value to integer.
                            int cellValue = int.Parse(value.Trim());
                            cellSet.Add(cellValue);
                            allCells.Add(cellValue);
                        }
                    }

                    dataSets.Add(cellSet);
                }

                // Extracting additional parameters from the model.
                string graphName = model.graphname;
                string axis = model.axis;
                int maxCell = allCells.Max() + 100;
                int minCell = allCells.Min() - 100;
                int maxCycles = model.maxCycles;
                int highlightTouch = model.hightouch;
                string yAxisTitle = model.yaxis;
                string xAxisTitle = model.xaxis;
                string subPlotTitle = model.subplottitle;
                string figureName = model.textfile;

                // Setting the current SD in the Filedatahelper.
                Filedatahelper.setcurrentSD(model);

                // Plotting the activity vertically and horizontally.
                SdrDrawer.PlotActivityVertically(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName, model.datapath);
                SdrDrawer.PlotActivityHorizontally(dataSets, highlightTouch, maxCycles, minCell, maxCell, yAxisTitle, xAxisTitle, subPlotTitle, figureName, model.datapath);
            }
            catch (Exception ex)
            {
                // Exception handling if any error occurs during the plot generation.
            }
        }

    }
```

Usage:

The SdrHelper class provides a simple interface for generating SDR plots. It accepts an instance of SdValueModel containing relevant data and parameters for plot generation.

Notes:

- Ensure that the SdrDrawer class and SdValueModal model are properly configured before invoking the newgeneratesdr2 method.
- Exception handling is implemented within the method to handle errors during plot generation.
- The generated plots will be saved in SVG format at the specified data path.

---

## Exploring MAUI Desktop App

The MAUI desktop app is a multi-platform application built using the .NET MAUI framework, allowing users to generate and visualize Sparse Distributed Representation (SDR) diagrams. SDR is a data representation technique commonly used in various fields such as neuroscience, machine learning, and pattern recognition.


## File Handling and Processing Page - Home Page

The File Handling and Processing Page is a component of the MAUI desktop app responsible for managing file input from the user, processing the content of the selected file, and transitioning to other pages or actions based on the processed data.

![image](https://github.com/AswiniThiru/neocortexapi/assets/148788581/85c0994d-f72e-4e2d-ba3f-1e29ce76bf03)

Steps to collect the SDR data:

1. Go to: https://github.com/AswiniThiru/neocortexapi/blob/Team_MAUI/source/NeoCortexApi.sln

2. Run the program.cs file and copy the required SDR data from the Application Output window and paste it in a text/csv file to proceed futher.

3. You can also find the example files for testing purpose under txt & csv files for testing under this folder https://github.com/AswiniThiru/neocortexapi/tree/Team_MAUI/source/MySEProject/Documentation
   
**Usage**

1. Selecting a File:

- Users can select a text ot csv file using the provided file input component or can paste the SDR input data in the textbox.

- The selected file's content is then processed and prepared for further actions.

2. Navigating to Other Pages:
  
- After processing the file content, users can proceed to other pages or actions within the app.

- Empty file/textbox data triggers an alert to notify the user before proceeding.

## Input Page

The Input Page is a component of the MAUI desktop app responsible for gathering user input to configure parameters for generating Sparse Distributed Representation (SDR) diagrams.

![image (1)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/550f7266-0fd9-4a9c-bcfc-67922a778aae)

**Usage**

1. Input Form: Users fill out the input form with parameters required for generating the SDR diagram either by selecting the `Set Default Values` button or by `Set Manual Values` button.

2. Validation: Input fields are validated to ensure all required fields are filled.

3. Generation of SDR Diagram: Upon successful validation, the SDR diagram is generated based on the provided parameters.

4. Navigation: Users can navigate back to the home page or proceed to view the generated diagram.

## Output Page

The Output Page is a component of the MAUI desktop app responsible for displaying and managing the output generated from Sparse Distributed Representation (SDR) diagrams.

![image (2)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/6b57572c-91bb-44d9-b6fe-2e7e6ec5c17c)
![image (3)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/9132be0d-ca66-4dd0-8860-c1711e72ea75)
![image (5)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/36903f6b-f89e-4779-8f97-3f35693be60c)


**Usage**

1. Manual Plot selection Adjustments: Type of plot can be selected and the number of cycles can be adjusted to generate customized SDR diagrams.

2. Download Images: Download the generated horizontal and vertical SVG images for further use or sharing.


---

# Step-by-Step Guide: Setting Up MAUI Desktop App with NeocortexApi.SdrDrawerLib Library 

This guide provides you instructions to integrate the NeocortexApi.SdrDrawerLib library into a MAUI desktop application for generating SDR (Sparse Distributed Representation) diagrams.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet)
- Visual Studio 2022 or Visual Studio Code (with .NET 8 support)
- Basic knowledge of C# and Blazor

Ensure that you have the .NET 8 SDK installed on your development machine before proceeding with the setup. You can download and install it from the provided link. Additionally, having Visual Studio 2022 or Visual Studio Code with .NET 8 support will facilitate the development process. Familiarity with C# and Blazor programming languages will also be beneficial for implementing the application logic and user interface components.

## Steps to Implement NeocortexApi.SdrDrawerLib in a MAUI Desktop App

### Step 1: Create a New MAUI Project

1. Open Visual Studio 2022.
2. Create a new MAUI App project.
3. Choose the appropriate project template for desktop applications.
4. Name your project and click "Create".

### Step 2: Add Required Dependencies

1. Add the following packages to your project:
   - `Microsoft.AspNetCore.Components`
   - `Microsoft.JSInterop`
   - And other dependencies mentioned in the description.

### Step 3: Reference NeocortexApi.SdrDrawerLib Library

1. Right-click on your MAUI project in the Solution Explorer.
2. Select "Add" > "Reference...".
3. In the Reference Manager window, navigate to the location of the "NeocortexApi.SdrDrawerLib" project.
4. Select the "NeocortexApi.SdrDrawerLib" project and click "OK" to add the reference.
5. Ensure that the "NeocortexApi.SdrDrawerLib" library is now listed under the References section of your MAUI project.

### Step 4: Create Models

1. Create a `Models` folder in your project.
2. Add the following models to the `Models` folder:
   - `SdValueModel`: Represents the input parameters for SDR plotting.
   - Any other models required for your application.

### Step 5: Implement Pages

1. Create Blazor component pages for Home, InputPage, and OutputPage in the `Components/Pages` folder.
2. Implement the functionality for each page:
   - **Home Page**: Provide an overview and introduction to the application.
   - **InputPage**: Allow users to input parameters for generating SDR diagrams.
   - **OutputPage**: Display and manage the generated SDR diagrams.

### Step 6: Configure Navigation

1. Implement navigation between pages using routing or navigation components.
2. Ensure smooth navigation flow between Home, InputPage, and OutputPage.

### Step 7: Integrate NeocortexApi.SdrDrawerLib

1. In the InputPage and OutputPage components, utilize the methods provided by the "NeocortexApi.SdrDrawerLib" library to generate SDR diagrams based on input parameters.
2. Utilize the `SdValueModel` class to manage input parameters and pass them to the methods in the "NeocortexApi.SdrDrawerLib" library.

### Step 8: Handle User Input and Interactions

1. Implement event handlers and methods to handle user input and interactions on the InputPage and OutputPage components.
2. Validate user input and provide appropriate feedback or error messages.

### Step 9: Test and Debug

1. Test the application thoroughly to ensure all features work as expected.
2. Debug any issues or errors encountered during testing.

### Step 10: Build and Deploy

1. Build the MAUI desktop app for your target platform.
2. Deploy the application to your desired environment or distribute it to users.

## Conclusion

This project introduces a user-friendly MAUI desktop application for generating and visualizing Sparse Distributed Representations (SDRs). By integrating the NeocortexApi.SdrDrawerLib library, the application provides intuitive interfaces for inputting parameters, generating SDR diagrams, and analyzing results, thereby democratizing SDR visualization. Through thorough testing and community contributions, the project aims to advance SDR visualization and foster innovation across interdisciplinary domains.

--- 












 
