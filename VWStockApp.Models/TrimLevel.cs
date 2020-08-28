using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VWStockApp.Models
{
	public class TrimLevel
	{
		public int ID { get; set; }

		[Display(Name = "Model ID")]
		public int CarModelID { get; set; }

		[StringLength(50)]
		[Display(Name = "Trim Name")]
		public string Name { get; set; }

		[DataType(DataType.Currency)]
		[Column(TypeName = "money")]
		public decimal Price { get; set; }

		public ICollection<Feature> Features { get; set; }
	}
}
