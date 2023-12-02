using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TOTAL_CAR_FEES.APPLICATION.Fees.Queries;

namespace TOTAL_CAR_FEES.API.Controllers
{

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
		public IActionResult GetCarPriceAndFees([FromQuery] string basePrice, [FromQuery] string vehicleType)
		{
			object result = _mediator.Send(new CalculateCarFeesQuery(basePrice, vehicleType));
			return Ok(result);
		}
	}
}

