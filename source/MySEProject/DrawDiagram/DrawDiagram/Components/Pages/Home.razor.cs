
using Microsoft.AspNetCore.Components.Forms;
using NeocortexApi.SdrDrawerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawDiagram.Components.Pages
{
    public partial class Home
    {
       
        string filedata;
        private async Task HandleFileChange(InputFileChangeEventArgs e)
        {
            var file = e.File;

            // Read the file content
            byte[] buffer = new byte[file.Size];
            await file.OpenReadStream().ReadAsync(buffer);
            string fileContent = Encoding.UTF8.GetString(buffer);

            // Process the file content as needed
            // For example, you can parse the content or perform validations
            filedata = fileContent;
            // here File read and set as globaly and can access this from any page and class 
          

        }

        private void Gotoinout()
        {
            Filedatahelper.setfiledata(filedata);
            mynav.NavigateTo($"input");
        }
    }
}
