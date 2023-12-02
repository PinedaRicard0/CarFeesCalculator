using System;
using System.Globalization;
using Humanizer;
using MediatR;
using TOTAL_CAR_FEES.APPLICATION.Fees.Models;
using TOTAL_CAR_FEES.DOMAIN.Services;

namespace TOTAL_CAR_FEES.APPLICATION.Fees.Queries
{
	public class CalculateCarFeesHandler : IRequestHandler<CalculateCarFeesQuery, TotalFeesResponse>
	{
        private const string BASIC = "Basic";
        private const string SPECIAL = "Special";
        private const string ASSOCIATION = "Association";
        private const string STORAGE = "Storage";
        private  List<string> vehicleTypes = new List<string> { "common", "luxury" };
        private FeesService _feesService;

        public CalculateCarFeesHandler(FeesService feesService)
		{
            _feesService = feesService;

        }

        public async Task<TotalFeesResponse> Handle(CalculateCarFeesQuery request, CancellationToken cancellationToken)
        {
            #region Validations
            _ = request.basePrice ?? throw new ArgumentException(nameof(request.basePrice), "Request param needed to handle this task");
            _ = request.vehicleType ?? throw new ArgumentException(nameof(request.vehicleType), "Request param needed to handle this task");
            _ = !ValidateBasePrice(request.basePrice) ? throw new ArgumentException(nameof(request.basePrice), "Invalid value") : true;
            _ = !ValidateVehycloeType(request.vehicleType) ? throw new ArgumentException(nameof(request.vehicleType), "Invalid value") : true;
            #endregion

            #region Fees Calculations
            decimal decimalBasePrice = decimal.Parse(request.basePrice);
            decimal basicFee = _feesService.CalculateBasicFee(decimal.Parse(request.basePrice), request.vehicleType.ToLower());
            decimal specialFee = _feesService.CalculateSpecialFee(decimal.Parse(request.basePrice), request.vehicleType.ToLower());
            decimal associationFee = _feesService.CalculateAssociationFee(decimal.Parse(request.basePrice), request.vehicleType.ToLower());
            decimal fixFee = _feesService.GetFixedFee();
            #endregion

            #region PreparingResponse
            TotalFeesResponse response = new()
            {
                VehiclePrice = decimalBasePrice.ToString("C", new CultureInfo("en-US")),
                VehicleType = request.vehicleType.Humanize(LetterCasing.Title),
                Total = (basicFee + specialFee + associationFee + fixFee + decimalBasePrice).ToString("C", new CultureInfo("en-US")),
                Fees = new List<Fee>()
            };
            response.Fees.Add(new Fee() { Name = BASIC, Value = basicFee.ToString("C", new CultureInfo("en-US")) });
            response.Fees.Add(new Fee() { Name = SPECIAL, Value = specialFee.ToString("C", new CultureInfo("en-US")) });
            response.Fees.Add(new Fee() { Name = ASSOCIATION, Value = associationFee.ToString("C", new CultureInfo("en-US")) });
            response.Fees.Add(new Fee() { Name = STORAGE, Value = fixFee.ToString("C", new CultureInfo("en-US")) });
            #endregion

            return response;
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