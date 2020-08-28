using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace VWStockApp.Models
{
	public class StockItem
	{
		public int ID { get; set; }

		[Display(Name = "Make")]
		public int? MakeID { get; set; }
		[Display(Name = "Model")]
		public int? CarModelID { get; set; }
		[Display(Name = "Trim Level")]
		public int? TrimLevelID { get; set;}
		[Display(Name = "Colour")]
		public int? ColourID { get; set; }

		public Make Make { get; set; }

		[Display(Name = "Model")]
		public CarModel CarModel { get; set; }

		[Display(Name = "Trim Level")]
		public TrimLevel TrimLevel { get; set; }
		public Colour Colour { get; set; }

		[Display(Name = "Price Modifier")]
		[DataType(DataType.Currency)]
		[Column(TypeName = "money")]
		public decimal PriceModifier { get; set; }

	}
}
