using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TST.CORE.Helpers;
using TST.SERVICE.Service.Interfaces;

namespace TST.BaseProject.Controllers
{
    public class JsonController : Controller
    {
        private readonly ICategoryService _categoryService;
        public JsonController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("categorias/get")]
        public async Task<IActionResult> GetCategory()
        {
            var data = await _categoryService.GetAll();
            var result = data.Select(x => new
            {
                id = x.Id,
                text = x.Name
            }).ToList();
            return Ok(result);
        }
    }
}
