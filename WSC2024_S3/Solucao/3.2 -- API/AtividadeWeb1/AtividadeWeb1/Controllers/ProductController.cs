using AtividadeWeb1.Context;
using AtividadeWeb1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeWeb1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        MainContext ctx = new MainContext();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ctx.Products.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(ctx.Products.FirstOrDefault(x => x.ProductId == id));
        }

        [HttpPost]
        public IActionResult CriarProduto([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                ctx.Products.Add(product);
                ctx.SaveChanges();

                return CreatedAtAction(nameof(CriarProduto), product);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Product product)
        {
            if (id != product.ProductId)
                return BadRequest("Id do produto nao confere");

            var ProductExistente = ctx.Products.Find(id);
            if (ProductExistente == null)
                return NotFound("Produto nao localizado");

            ProductExistente.ProductId = product.ProductId;
            ProductExistente.ProductName = product.ProductName;
            ProductExistente.Category = product.Category;
            ProductExistente.Price = product.Price;
            ProductExistente.Cost = product.Cost;
            ProductExistente.Description = product.Description;
            ProductExistente.Seasonal = product.Seasonal;
            ProductExistente.Active = product.Active;
            ProductExistente.IntroducedDate = product.IntroducedDate;
            ProductExistente.Ingredients = product.Ingredients;

            try
            {
                await ctx.SaveChangesAsync();
                return Ok(ProductExistente);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var ProductExistente = ctx.Products.Find(id);
            if (ProductExistente == null)
                return BadRequest("Product não localizado");

            ctx.Products.Remove(ProductExistente);
            ctx.SaveChanges();

            return NoContent();
        }

    }
}
