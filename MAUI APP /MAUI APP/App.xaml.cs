//Define intital page

namespace MAUI_APP;					    //Declare that the following code is oart of MAUI app namespace 

public partial class App : Application  //Declare a public partial class anmed App, which inherits form the application class
{									    //start of the class body
	public App()						//constructor for the App class
	{									//start of contructor body
		InitializeComponent();          //Call a method to initialize components associated with the App class

		var navPage = new NavigationPage(new MainPage()); // create a new instance of NavigationPage and set its initial content to an instance of MainPage class
		navPage.BarBackground = Colors.Beige;			  //set the background color of the navigation bar to beige
		navPage.BarTextColor = Colors.White;			  // set the text color of the navigation bar to white 


		MainPage = new AppShell();		//set the MainPage property to a new instance of the AppShell class
	}									//end of the constructor body
}										//end of the class body
