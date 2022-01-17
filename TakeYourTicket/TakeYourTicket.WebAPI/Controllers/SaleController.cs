using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TakeYourTicket.Infrastructure.EF.InputModels;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace TakeYourTicket.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    public class SaleController : Controller
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<SaleController> _logger;

        public SaleController(ISaleRepository saleRepository, ILogger<SaleController> logger)
        {
            _saleRepository = saleRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleInputModel sale)
        {
            if (!Guid.TryParse(sale.SessionId, out var sessionId))
            {
                return BadRequest("Invalid Id");
            }

            Sale newSale = new Sale(sale.Quantity, sessionId);
            _logger.LogInformation("Sale {saleId} created in memory", newSale.Id);

            Sale createdSale = await _saleRepository.Create(newSale);
            _logger.LogInformation("Sale {saleId} created in the database", createdSale.Id);

            return Ok();
        }
    }
}
