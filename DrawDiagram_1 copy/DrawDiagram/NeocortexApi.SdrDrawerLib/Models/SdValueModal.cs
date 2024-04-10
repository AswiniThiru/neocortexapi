using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
