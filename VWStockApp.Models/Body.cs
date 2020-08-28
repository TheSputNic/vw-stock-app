using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VWStockApp.Models
{
	public class Body
	{
		public int ID { get; set; }

		[StringLength(50, MinimumLength = 3)]
		[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
		public string Name { get; set; }
	}
}
