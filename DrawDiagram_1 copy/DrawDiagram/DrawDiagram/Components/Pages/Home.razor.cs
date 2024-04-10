
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using NeocortexApi.SdrDrawerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawDiagram.Components.Pages
{
    public partial class Home
    {
        bool isfileselected = false;
        string filedata ="";
        private async Task HandleFileChange(InputFileChangeEventArgs e)
        {
            var file = e.File;

            // Read the file content
            byte[] buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);
            string fileContent = Encoding.UTF8.GetString(buffer);
            isfileselected= true;
            Processcontent(fileContent);

        }

        private async Task  Gotoinout()
        {
            if (!isfileselected)
            {
                Processcontent(filedata);
            }
            if ( filedata=="")
            {
				await jsruntime.InvokeVoidAsync("alert", "Input Data is empty!");
            }
            else
            {
				Filedatahelper.setfiledata(filedata);
				mynav.NavigateTo($"input");
			}
          
        }
        private void Processcontent( string fileContent)
        {
            string pattern = @"(?:^.*SDR:\s*|Cycle.*Stability: False.*\r?\n*)";

            string pattern2 = @"cycle=(\d+)";
            Match match = Regex.Match(fileContent, pattern2, RegexOptions.RightToLeft);


            if (match.Success)
            {
                string cycleValue = match.Groups[1].Value;
                Filedatahelper.imagepath = cycleValue;
            }
            else
            {
                Filedatahelper.imagepath = "0";
            }

            string result = Regex.Replace(fileContent, pattern, "", RegexOptions.Multiline);

			string pattern3 = @"\[cycle=\d+, i=\d+, cols=\:\d+\s.*\]";
			 result = Regex.Replace(result, pattern3, "", RegexOptions.Multiline);
			result = result.Replace("\"", ""); // Remove double quotes
           // Process the file content as needed
           // For example, you can parse the content or perform validations
			filedata = result;
            // here File read and set as globaly and can access this from any page and class 

        }
    }
}
