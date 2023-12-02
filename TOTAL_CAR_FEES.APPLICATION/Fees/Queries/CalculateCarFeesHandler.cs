using System;
using MediatR;
using TOTAL_CAR_FEES.APPLICATION.Fees.Models;

namespace TOTAL_CAR_FEES.APPLICATION.Fees.Queries
{
	public class CalculateCarFeesHandler : IRequestHandler<CalculateCarFeesQuery, TotalFeesResponse>
	{
        private  List<string> vehicleTypes = new List<string> { "common", "luxury" };

		public CalculateCarFeesHandler()
		{
		}

        public async Task<TotalFeesResponse> Handle(CalculateCarFeesQuery request, CancellationToken cancellationToken)
        {
            _ = request.basePrice ?? throw new ArgumentException(nameof(request.basePrice), "Request param needed to handle this task");
            _ = request.vehicleType ?? throw new ArgumentException(nameof(request.vehicleType), "Request param needed to handle this task");
            _ = !ValidateBasePrice(request.basePrice) ? throw new ArgumentException(nameof(request.basePrice), "Invalid value") : true;
            _ = !ValidateVehycloeType(request.vehicleType) ? throw new ArgumentException(nameof(request.vehicleType), "Invalid value") : true;
            TotalFeesResponse test = new();
            return test;
        }

        private bool ValidateBasePrice(string price)
        {
            return decimal.TryParse(price, out decimal result);
        }

        private bool ValidateVehycloeType(string type)
        {
            return vehicleTypes.Contains(type.ToLower());
        }
    }
}