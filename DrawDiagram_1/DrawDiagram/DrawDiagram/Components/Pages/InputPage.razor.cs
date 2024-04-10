using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using DrawDiagram.Models;

using Microsoft.JSInterop;
using NeocortexApi.SdrDrawerLib;

namespace DrawDiagram.Components.Pages
{
    partial class InputPage
    {
		SdValueModel model = new SdValueModel();
        string disable = "false";
        bool isanabled = true;
		private string inputValue = "";
        List<Dropdown> mincellslist = new List<Dropdown>();
		List<Dropdown> maxcelleslist = new List<Dropdown>();
        protected override void OnInitialized()
        {
            try
            {
                if (Convert.ToInt32(Filedatahelper.imagepath) == 0)
                {
                    model.maxCycles = 100;

                }
                else if (Convert.ToInt32(Filedatahelper.imagepath) > 0)
                {
                    model.maxCycles = Convert.ToInt32(Filedatahelper.imagepath);
                }
            }
            catch (Exception ex)
            {
                model.maxCycles = 100;
            }


            for (var i = 100; i <= 5000; i += 10)
			{
                maxcelleslist.Add(new Dropdown { value = i });
			}
			for (var i = 0; i <= 100; i += 10)
			{
			mincellslist.Add(new Dropdown { value = i });
			}
		}
		public async void handleclick()
        {

            if (model.graphname=="" || model.textfile=="" || model.yaxis=="" || model.xaxis =="" || model.subplottitle=="")
            {
				
			}
            else
            {
				// Get the file data from the Filedatahelper
				model.fileData = Filedatahelper.getfiledata();

				// Get the application data path
				model.datapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

				// Generate the SDR based on the model data
				SdrHelper.newgeneratesdr(model);

				// Navigate to the "output" page
				mynav.NavigateTo("output");
			}
         

        }

        private void backtohome()
        {
            mynav.NavigateTo("/");
        }
        public async Task setdefaultvalue()
        {
            model.graphname = "test1";
            model.fname = "CortialColumn";
            model.yaxis = "Yaxis";
            model.xaxis = "Xaxis";
            model.minrange = 50;
            model.maxrange = 4000;
            model.subplottitle = "single column";
            model.hightouch = 8;
            model.textfile = "CortialColumn";
            await jsruntime.InvokeVoidAsync("defaultValues");
            StateHasChanged();

		}

        private async Task setmanualvalue()
        {
			await jsruntime.InvokeVoidAsync("editAbleValues");
			StateHasChanged();
		}
     
       
    }

    public class Dropdown
    {
        public int value { get; set; }
    }
}
