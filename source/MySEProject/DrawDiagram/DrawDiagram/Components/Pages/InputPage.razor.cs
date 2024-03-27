using System;
using System.Collections.Generic;
using System.Linq;

using DrawDiagram.Models;

using Microsoft.JSInterop;
using NeocortexApi.SdrDrawerLib;

namespace DrawDiagram.Components.Pages
{
    partial class InputPage
    {
		SdValueModal model = new SdValueModal();
        string disable = "false";
        bool isanabled = true;
		private string inputValue = "";
		public async void handleclick()
        {
            // Get the current cycle from JavaScript
            string cycle = await jsruntime.InvokeAsync<string>("getcycle");
            // Set the maxCycles in the model
            model.maxCycles = Convert.ToInt32(cycle);

            // Get the number of high touches from JavaScript
            model.hightouch = Convert.ToInt32(await jsruntime.InvokeAsync<string>("gettouches"));

            // Get the file data from the Filedatahelper
            model.fileData = Filedatahelper.getfiledata();

            // Get the application data path
            model.datapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Generate the SDR based on the model data
            SdrHelper.newgeneratesdr2(model);

            // Navigate to the "output" page
            mynav.NavigateTo("output");

        }

        public async Task setdefaultvalue()
        {
            model.graphname = "test1";
            model.fname = "CortialColumn";
            model.maxCycles = 19;
            model.yaxis = "Yaxis";
            model.xaxis = "Xaxis";
            model.minrange = 50;
            model.maxrange = 4000;
            model.subplottitle = "single column";
            model.hightouch = 100;
            model.textfile = "test1";
            await jsruntime.InvokeVoidAsync("defaultValues");
            StateHasChanged();

		}

        private async Task setmanualvalue()
        {
			await jsruntime.InvokeVoidAsync("editAbleValues");
			StateHasChanged();
		}
     
       
    }
}
