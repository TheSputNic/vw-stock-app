using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VWStockApp.Models
{
	public class Feature
	{
		public int ID { get; set; }
		public int TrimLevelID { get; set; }

		[StringLength(100, MinimumLength = 3, ErrorMessage ="Please limit your feature description to under 100 characters")]
		public string Description { get; set; }
	}
}
