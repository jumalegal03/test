using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TS.BaseProject.Models;
using Microsoft.AspNetCore.Authorization;
using TST.SERVICE.Service.Interfaces;
using TST.CORE.Services.Interfaces;
using TST.BaseProject.ViewModels.HomeViewModels;
using TST.ENTITIES.Models.Generals;

namespace BaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataTableService _dataTableService;
        private readonly IProductService _productService;
        
        public HomeController(ILogger<HomeController> logger,
            IDataTableService dataTableService,
            IProductService productService)
        {
            _logger = logger;
            _dataTableService = dataTableService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("get-productos")]
        public async Task<IActionResult> GetMusicalGenre(string search = null, string category = null)
        {
            var sentParameters = _dataTableService.GetSentParameters();
            var result = await _productService.GetAllDatatable(sentParameters, search, category);

            return Ok(result);
        }

        [HttpPost("comprar/post")]
        public async Task<IActionResult> ShoppProduct(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(id))
                return BadRequest($"No se encontró el producto");

            var product = await _productService.Get(id);
            
            if(product.Stock <= 0)
                return BadRequest($"No tenemos stock disponible del producto {product.Name}");

            product.Stock--;
            await _productService.Update(product);
            return Ok();
        }

        [HttpGet("{id}/get")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest($"No se encontró el producto");
            var product = await _productService.GetWithData(id);
            return Ok(product);
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
