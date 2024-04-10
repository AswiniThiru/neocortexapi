
# ML22/23-7 Implement the SDR representation in the MAUI application.


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

1. Input Form: Users fill out the input form with parameters required for generating the SDR diagram.

2. Validation: Input fields are validated to ensure all required fields are filled.

3. Generation of SDR Diagram: Upon successful validation, the SDR diagram is generated based on the provided parameters.

4. Navigation: Users can navigate back to the home page or proceed to view the generated diagram.

## Output Page

The Output Page is a component of the MAUI desktop app responsible for displaying and managing the output generated from Sparse Distributed Representation (SDR) diagrams.

![image (2)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/6b57572c-91bb-44d9-b6fe-2e7e6ec5c17c)
![image (3)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/9132be0d-ca66-4dd0-8860-c1711e72ea75)
![image (5)](https://github.com/AswiniThiru/neocortexapi/assets/148788581/36903f6b-f89e-4779-8f97-3f35693be60c)


**Usage**

1. Manual Input and Adjustment: Input the filename and adjust the progress value to generate customized SDR diagrams.

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












 
