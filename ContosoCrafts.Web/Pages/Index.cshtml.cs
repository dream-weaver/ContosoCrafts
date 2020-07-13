using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.Web.Models;
using ContosoCrafts.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.Web.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly JsonFileProductService productService;

		public IEnumerable<Product> Products { get; private set; }
		public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
		{
			_logger = logger;
			this.productService = productService;
		}

		public void OnGet()
		{
			//Products = productService.GetProducts();
		}
	}
}
