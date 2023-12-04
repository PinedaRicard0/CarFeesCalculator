using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TOTAL_CAR_FEES.APPLICATION.Fees.Models;
using TOTAL_CAR_FEES.APPLICATION.Fees.Queries;

namespace TOTAL_CAR_FEES.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/prices")]
    public class PricesController : ControllerBase
	{
        private readonly IMediator _mediator;

        public PricesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("get-car-fees")]
		public async Task<IActionResult> GetCarPriceAndFees([FromQuery] string basePrice, [FromQuery] string vehicleType)
		{
			try
			{
				TotalFeesResponse result = await _mediator.Send(new CalculateCarFeesQuery(basePrice, vehicleType));
				return Ok(result);
			}
			catch (ArgumentException ax)
			{
				return BadRequest($"{ax.Message}");
			}
		}
	}
}

