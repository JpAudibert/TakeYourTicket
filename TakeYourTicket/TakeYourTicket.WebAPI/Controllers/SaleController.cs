using Microsoft.AspNetCore.Mvc;
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

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleInputModel sale)
        {
            try
            {
                if (!Guid.TryParse(sale.SessionId, out var sessionId))
                {
                    return BadRequest("Invalid Id");
                }

                Sale newSale = new Sale(sale.Quantity, sessionId);

                Sale createdSale = await _saleRepository.Create(newSale);

                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}
