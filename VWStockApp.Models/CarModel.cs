using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VWStockApp.Models
{
	public class CarModel
	{
		public int ID { get; set; }

		public int MakeID { get; set; }

		public int? BodyID { get; set; }

		[StringLength(50)]
		public string Name { get; set; }

		[Display(Name = "Year Model")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString ="{0:yyyy}", ApplyFormatInEditMode = true)]
		public DateTime YearModel { get; set; }

		[Display(Name = "Body Type")]
		public Body Body { get; set; }

		public ICollection<TrimLevel> TrimLevels { get; set; }
		public ICollection<Colour> Colours { get; set; }
	}
}
