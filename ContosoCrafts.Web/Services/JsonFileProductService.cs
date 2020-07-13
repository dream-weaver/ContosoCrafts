using ContosoCrafts.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ContosoCrafts.Web.Services
{
	public class JsonFileProductService
	{
		private readonly IWebHostEnvironment webHostEnvironment;

		public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
		{
			this.webHostEnvironment = webHostEnvironment;
		}
		public string JsonFileName
		{
			get { return Path.Combine(webHostEnvironment.WebRootPath, "data", "products.json"); }
		}
		public IEnumerable<Product> GetProducts()
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
					new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
			}
		}

		public void AddRating(string productId, int rating)
		{
			var products = GetProducts();
			//LINQ
			var product = products.First(p => p.Id == productId);
			if (product.Ratings == null)
			{
				product.Ratings = new int[] { rating };
			}
			else
			{
				var ratings = product.Ratings.ToList();
				ratings.Add(rating);
				product.Ratings = ratings.ToArray();
			}

			using (var outputStream = File.OpenWrite(JsonFileName))
			{
				JsonSerializer.Serialize<IEnumerable<Product>>(
					new Utf8JsonWriter(outputStream, new JsonWriterOptions
					{
						SkipValidation = true,
						Indented = true
					}),
					products
				);
			}
		}
	}
}
