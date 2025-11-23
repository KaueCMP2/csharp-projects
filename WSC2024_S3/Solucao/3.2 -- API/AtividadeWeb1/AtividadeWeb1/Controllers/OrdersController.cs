using AtividadeWeb1.Context;
using AtividadeWeb1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtividadeWeb1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        MainContext ctx = new MainContext();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ctx.Orders.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var OrderExistente = ctx.Orders.FirstOrDefault(u => u.TransactionId == id);

            if (OrderExistente == null)
                return NotFound("Order não localizada");

            return Ok(OrderExistente);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Order order)
        {
            try
            {
                ctx.Orders.Add(order);
                ctx.SaveChanges();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/Complete")]
        public async Task<IActionResult> Complete(int id, [FromBody] Order order)
        {
            if (id != order.TransactionId)
                return BadRequest("Order não localizada");

            var OrderExistente = ctx.Orders.Find(id);
            if (OrderExistente == null)
                return NotFound("Order não localizada");

            OrderExistente.Status = order.Status;

            if (order.Status == "complete")
            {
                try
                {
                    ctx.SaveChanges();
                    return Ok(OrderExistente);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            else
                return BadRequest("O Status da order precisa estar como \"Complete\"");
        }

        [HttpPut("{id}/Cancel")]
        public async Task<IActionResult> Cancel(int id, [FromBody] Order order)
        {
            if (id != order.TransactionId)
                return BadRequest("Id do produto nao confere");

            var OrderExistente = ctx.Orders.Find(id);
            if (OrderExistente == null)
                return NotFound("Produto nao localizado");

            OrderExistente.Status = order.Status;

            try
            {
                await ctx.SaveChangesAsync();
                return Ok(OrderExistente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        }
    }
