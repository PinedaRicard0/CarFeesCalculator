using System;
using TOTAL_CAR_FEES.DOMAIN.Attributes;

namespace TOTAL_CAR_FEES.DOMAIN.Services
{
    [DomainService]
	public class FeesService
	{
		public FeesService()
		{
		}

		public decimal CalculateBasicFee(decimal value, string vehicleType)
		{
			return 651651;
		}

        public decimal CalculateSpecialFee(decimal value, string vehicleType)
        {
            return 51561;
        }

        public decimal CalculateAssociationFee(decimal value, string vehicleType)
        {
            return 4546;
        }

        public decimal GetFixedFee(decimal value, string vehicleType)
        {
            return 100;
        }
    }
}

