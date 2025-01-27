using DeveloperStore.API.Models;
using DeveloperStore.API.Requests;
using DeveloperStore.API.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SaleController> _logger;
        private readonly SaleService _saleService;

        public SaleController(IMediator mediator, ILogger<SaleController> logger, SaleService saleService)
        {
            _mediator = mediator;
            _logger = logger;
            _saleService = saleService;
        }

        // POST: api/Sale
        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            _logger.LogInformation("Iniciando criação de venda.");

            if (sale == null || sale.Items == null || !sale.Items.Any())
            {
                _logger.LogWarning("A venda não contém itens.");
                return BadRequest("A venda deve ter pelo menos 1 item.");
            }

            try
            {
                var createdSale = await _mediator.Send(new CreateSaleRequest(sale));
                _logger.LogInformation($"Venda criada com sucesso. Id: {createdSale.Id}");
                return CreatedAtAction(nameof(GetSale), new { id = createdSale.Id }, createdSale);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar a venda.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        // GET: api/Sale/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            _logger.LogInformation($"Buscando venda com ID {id}.");

            try
            {
                var sale = await _mediator.Send(new GetSaleByIdRequest(id));
                return Ok(sale);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning($"Venda com ID {id} não encontrada.");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar a venda.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
    }
}
