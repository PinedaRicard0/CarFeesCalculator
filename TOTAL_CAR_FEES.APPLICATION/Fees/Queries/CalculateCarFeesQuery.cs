using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using TOTAL_CAR_FEES.APPLICATION.Fees.Models;

namespace TOTAL_CAR_FEES.APPLICATION.Fees.Queries
{
	public record CalculateCarFeesQuery([Required] string basePrice, [Required] string vehicleType) : IRequest<TotalFeesResponse>;
}

