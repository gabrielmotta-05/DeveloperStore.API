using DeveloperStore.API.Data;
using DeveloperStore.API.Models;
using DeveloperStore.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeveloperStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly SaleService _saleService;

        public SaleController(ApplicationDbContext context, SaleService saleService)
        {
            _context = context;
            _saleService = saleService;
        }

        // POST: api/Sale
        //Cria uma nova venda e calcula o valor total e descontos.
        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            if (sale == null || sale.Items == null || !sale.Items.Any())
            {
                return BadRequest("A venda deve ter pelo menos 1 item.");
            }

            // Calculando os valores da venda e aplicando as regras de negócio
            var calculatedSale = _saleService.CalculateSale(sale);

            // Adicionando a venda no banco de dados
            _context.Sales.Add(calculatedSale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = calculatedSale.Id }, calculatedSale);
        }

        // GET: api/Sale/5
        //Retorna os detalhes de uma venda existente, incluindo seus itens.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            var sale = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }
    }
}
