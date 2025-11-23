using AtividadeWeb1.Context;
using AtividadeWeb1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeWeb1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        MainContext ctx = new MainContext();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ctx.Customers.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var CustomerExistente = ctx.Customers.FirstOrDefault(u => u.CustomerId == id);
            if (CustomerExistente == null)
                return BadRequest("Customer nao localizado");

            return Ok(CustomerExistente);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Customer customer)
        {
            try
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
                return CreatedAtAction(nameof(Customer), customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Customer customer)
        {
            if (id != customer.CustomerId)
                return BadRequest("Customer nao Coincide");


            var CustomerExistente = ctx.Customers.Find(customer);
            if (CustomerExistente == null)
                return BadRequest("Customer nao localizado");

            ctx.Entry(CustomerExistente).CurrentValues.SetValues(customer);

            try
            {
                await ctx.SaveChangesAsync();
                return Ok(CustomerExistente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
