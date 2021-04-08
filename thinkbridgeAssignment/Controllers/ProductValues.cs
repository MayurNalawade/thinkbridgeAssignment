using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thinkbridgeAssignment.Model;
using thinkbridgeAssignment.Repository;

namespace thinkbridgeAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductValues : ControllerBase
    {
        IProduct context;
        public ProductValues(IProduct _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var categories = await context.GetProducts();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet("{id:min(1)}")]
        public async Task<IActionResult> GetProductDetail(int id)
        {
            var product = await context.GetProductDetail(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product p)
        {
            if (id != p.ProductId)
            {
                return BadRequest();
            }
           await context.PutProduct(id, p);
           return CreatedAtAction("GetProductDetail", new { id = p.ProductId }, p);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product products)
        {
             await context.PostProducts(products);
            return CreatedAtAction("GetProductDetail", new { id = products.ProductId }, products);
        }

        [HttpDelete("{id:min(1)}")]
        [Route("DeletePost")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            int result = 0;

            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await context.DeleteProduct(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
