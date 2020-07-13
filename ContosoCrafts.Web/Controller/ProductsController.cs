using ContosoCrafts.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Web.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly JsonFileProductService productService;

		public ProductsController(JsonFileProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		public IActionResult GetProducts()
		{	
			return Ok(productService.GetProducts());
		}

		[Route("Rate")]
		[HttpGet]
		public IActionResult GetRatings(
			[FromQuery] string ProductID,
			[FromQuery] int Rating)
		{
			productService.AddRating(ProductID, Rating);
			return Ok();
		}
	}
}
