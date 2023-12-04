using System;
using TOTAL_CAR_FEES.DOMAIN.Services;

namespace TOTAL_CAR_FEES.TEST.Fees
{
	public class FeesServiceTest
	{
        private const string LUXURY = "luxury";
        private const string COMMON = "common";

        private FeesService? _feesService;

        public void Init()
		{
			_feesService = new FeesService();
        }

        [DataTestMethod]
        [DataRow("luxuri")]
        [DataRow("comon")]
        [DataRow("luxry")]
        [DataRow("luxuri")]
        public void TestBasciFee_ArgumentExceptionWhenNoValidVehicleType(string type)
        {
            //Arrange
            ArgumentException? exception = null;

            //Act
            try
            {
                _feesService.CalculateBasicFee(200, type);
            }
            catch (ArgumentException ex)
            {
                exception = ex;
            }

            // Assert
            Assert.IsNotNull(exception);
        }

	}
}

