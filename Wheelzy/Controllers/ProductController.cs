using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Interfaces;
using Wheelzy.Model.DTO;
using Wheelzy.Model.Entites;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wheelzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto newProdutDto)
        {
            var product = _mapper.Map<Product>(newProdutDto);
            await _productService.InsertProduct(product);
            return Ok(new { mesagge = "Se ha creado con exito" });
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var response = await _productService.GetProduct(id);
            return Ok(response);
        }

        [HttpGet("GetListProduct")]
        public ActionResult<List<Product>> GetListProduct()
        {
            var response = _productService.GetProducts();
            return Ok(response);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool delete = await _productService.DeleteProduct(id);
            if (delete)
                return Ok(new { mesagge = "Se Ha eliminado correctamente" });
            else
                return BadRequest();
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            bool update = await _productService.UpdateProduct(product);
            if (update)
                return Ok(new { mesagge = "Se ha actualizado correctamente" });
            else
                return BadRequest();
        }

        [HttpPost("UpdateStatusProduct/{id}/{status}")]
        public async Task<IActionResult> UpdateStatusProduct(int id, bool status)
        {
            bool update = await _productService.UpdateStatus(id, status);
            if (update)
                return Ok(new { mesagge = "Se ha actualizado correctamente" });
            else
                return BadRequest();
        }
    }
}
