using Microsoft.Maui.Controls;
using System;

namespace Maui_App1;

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadPlot();
        }

        private void LoadPlot()
        {
            // Specify the path to the generated HTML file
            string htmlFilePath = "path_to_your_generated_html_file.html";

            // Load the HTML file into the WebView
            plotWebView.Source = new UrlWebViewSource { Url = new Uri(htmlFilePath).AbsoluteUri };
        }
    }



