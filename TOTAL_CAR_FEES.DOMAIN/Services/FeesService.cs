using System;
using TOTAL_CAR_FEES.DOMAIN.Attributes;

namespace TOTAL_CAR_FEES.DOMAIN.Services
{
    [DomainService]
	public class FeesService
	{
        private const string LUXURY = "luxury";
        private const string COMMON = "common";

		public decimal CalculateBasicFee(decimal value, string vehicleType)
		{
            _ = value <= 0 ? throw new ArgumentException("Can not perform the calculation") : true;
            decimal tenPercent = (decimal)0.1;
            decimal tenPercentFee = value * tenPercent;
            if (vehicleType.ToLower().Equals(LUXURY))
            {
                return (tenPercentFee >= 25 && tenPercentFee <= 200) ? tenPercentFee : (tenPercentFee < 25) ? 25 : 200;
            }
            else if (vehicleType.ToLower().Equals(COMMON))
            {
                return (tenPercentFee >= 10 && tenPercentFee <= 50) ? tenPercentFee : (tenPercentFee < 10) ? 10 : 50;
            }
            throw new ArgumentException("Can not perform the calculation");
		}

        public decimal CalculateSpecialFee(decimal value, string vehicleType)
        {
            _ = value <= 0 ? throw new ArgumentException("Can not perform the calculation") : true;

            decimal twoPercent = (decimal)0.02;
            decimal fourPercent = (decimal)0.04;

            if (vehicleType.ToLower().Equals(LUXURY))
            {
                return value * fourPercent;
            }
            else if (vehicleType.ToLower().Equals(COMMON))
            {
                return value * twoPercent;
            }
            throw new ArgumentException("Can not perform the calculation");
        }

        public decimal CalculateAssociationFee(decimal value, string vehicleType)
        {
            return 4546;
        }

        public decimal GetFixedFee()
        {
            return 100;
        }
    }
}

