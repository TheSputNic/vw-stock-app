using Microsoft.CodeAnalysis.Razor;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using VWStockApp.Data;
using VWStockApp.Models;
using VWStockApp.Services;

namespace VWStockApp.Data
{
	public static class DbSeed
	{
		public static void Seed(AppDbContext context)
		{
			// Seeds the database with basic values, see VWStockApp.Database/dbo/Seed Scripts for more comprehensive data

			// context.Database.EnsureCreated();

			// Check for any cars
			if (context.StockItem.Any())
			{
				return;		// DB has been seeded
			}

			var makes = new Make[]
			{
				new Make{Name="Volkswagen"}
			};

			context.Makes.AddRange(makes);
			context.SaveChanges();

			var bodies = new Body[]
			{
				new Body{Name="Hatchback"},
				new Body{Name="Sedan"},
				new Body{Name="MUV/SUV"},
				new Body{Name="Coupe"},
				new Body{Name="Convertible"},
				new Body{Name="Panel Van"},
				new Body{Name="Van"},
				new Body{Name="Truck"}
			};

			context.Bodies.AddRange(bodies);
			context.SaveChanges();

			var colours = new Colour[]
			{
				new Colour{Name="Tornado Red"},
				new Colour{Name="Honey Yellow Metallic"},
				new Colour{Name="Teal Blue"},
				new Colour{Name="Candy / Pure White"},
				new Colour{Name="Dark Metallic Silver"},
				new Colour{Name="Deep Black Pearl Effect"}
			};

			context.Colours.AddRange(colours);
			context.SaveChanges();

			var carModels = new CarModel[]
			{
				new CarModel{MakeID=1, Name="up!", YearModel=DateTime.Parse("2019-01-01"), BodyID=bodies.Single(s => s.Name == "Hatchback").ID},
				new CarModel{MakeID=1, Name="Vivo", YearModel=DateTime.Parse("2019-01-01"), BodyID=bodies.Single(s => s.Name == "Hatchback").ID}
			};

			context.CarModels.AddRange(carModels);
			context.SaveChanges();

			var trimLevels = new TrimLevel[]
			{
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "up!").ID, Name="Take up!", Price=182700m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "up!").ID, Name="up! beats", Price=214900m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "Vivo").ID, Name="Trendline", Price=212700m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "Vivo").ID, Name="Comfortline", Price=225200m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "Vivo").ID, Name="Highline", Price=253900m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "Vivo").ID, Name="Maxx", Price=257000m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "Vivo").ID, Name="GT", Price=288200m},
				new TrimLevel{CarModelID=carModels.Single(s => s.Name == "Vivo").ID, Name="Sound Edition", Price=241200m}
			};

			context.TrimLevels.AddRange(trimLevels);
			context.SaveChanges();

			var features = new Feature[]
			{
				new Feature{TrimLevelID=trimLevels.First(s => s.CarModelID == 1 && s.Name == "Trendline").ID, Description="Radio R140G BT/USB/SD"},
				new Feature{TrimLevelID=trimLevels.First(s => s.CarModelID == 1 && s.Name == "Trendline").ID, Description="14\" Steel Wheels"},
				new Feature{TrimLevelID=trimLevels.First(s => s.CarModelID == 1 && s.Name == "Trendline").ID, Description="ISOFIX anchorage points"},
				new Feature{TrimLevelID=trimLevels.First(s => s.CarModelID == 1 && s.Name == "Trendline").ID, Description="Front Electric Windows"},
				new Feature{TrimLevelID=trimLevels.First(s => s.CarModelID == 2 && s.Name == "Take up!").ID, Description="ph"},
				new Feature{TrimLevelID=trimLevels.First(s => s.CarModelID == 2 && s.Name == "up! beats").ID, Description="ph"}
				
			};

			context.Features.AddRange(features);
			context.SaveChanges();
			
			var stockItems = new StockItem[]
			{
				new StockItem{Make=context.Makes.Single(s => s.Name == "Volkswagen"),
							CarModel=context.CarModels.Single(s => s.Name == "up!"),
							TrimLevel=context.TrimLevels.Single(s => s.Name == "Take up!"),
							Colour=context.Colours.Single(s => s.Name == "Tornado Red"),
							PriceModifier = 0},
				new StockItem{Make=context.Makes.Single(s => s.Name == "Volkswagen"),
							CarModel=context.CarModels.Single(s => s.Name == "up!"),
							TrimLevel=context.TrimLevels.Single(s => s.Name == "up! beats"),
							Colour=context.Colours.Single(s => s.Name == "Teal Blue"),
							PriceModifier = 0},
				new StockItem{Make=context.Makes.Single(s => s.Name == "Volkswagen"),
							CarModel=context.CarModels.Single(s => s.Name == "Vivo"),
							TrimLevel=context.TrimLevels.Single(s => s.Name == "Trendline"),
							Colour=context.Colours.Single(s => s.Name == "Tornado Red"),
							PriceModifier = 0},
				new StockItem{Make=context.Makes.Single(s => s.Name == "Volkswagen"),
							CarModel=context.CarModels.Single(s => s.Name == "Vivo"),
							TrimLevel=context.TrimLevels.Single(s => s.Name == "Sound Edition"),
							Colour=context.Colours.Single(s => s.Name == "Dark Metallic Silver"),
							PriceModifier = 0},
				new StockItem{Make=context.Makes.Single(s => s.Name == "Volkswagen"),
							CarModel=context.CarModels.Single(s => s.Name == "Vivo"),
							TrimLevel=context.TrimLevels.Single(s => s.Name == "GT"),
							Colour=context.Colours.Single(s => s.Name == "Deep Black Pearl Effect"),
							PriceModifier = 0}
			};

			context.StockItem.AddRange(stockItems);
			context.SaveChanges();

		}
	}
}