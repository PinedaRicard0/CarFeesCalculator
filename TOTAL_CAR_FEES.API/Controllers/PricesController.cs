using System;
using Microsoft.AspNetCore.Mvc;

namespace TOTAL_CAR_FEES.API.Controllers
{

    [ApiController]
    [Route("api/prices")]
    public class PricesController : ControllerBase
	{
		public PricesController()
		{
		}

		[HttpGet("get-car-fees")]
		public IActionResult GetCarPriceAndFees([FromQuery] string basePrice, [FromQuery] string vehicleType)
		{
			return Ok();
		}
	}
}

