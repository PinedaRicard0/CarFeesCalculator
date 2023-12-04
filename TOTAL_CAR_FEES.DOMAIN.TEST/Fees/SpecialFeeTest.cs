using System;
namespace TOTAL_CAR_FEES.DOMAIN.TEST.Fees
{
	public partial class FeesServiceTest
    {
        [Test]
        [TestCase("luxuri")]
        [TestCase("comon")]
        [TestCase("luxry")]
        [TestCase("luxuri")]
        public void TestSpecialFee_ArgumentExceptionWhenNoValidVehicleType(string type)
        {
            Assert.That(() => _feesService?.CalculateSpecialFee(50, type), Throws.ArgumentException);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-0.01)]
        [TestCase(-5)]
        public void TestSpecialFee_ArgumentExceptionWhenValueEqualOrLessThanZero(decimal value)
        {
            Assert.That(() => _feesService?.CalculateSpecialFee(value, "luxury"), Throws.ArgumentException);
        }

        [Test]
        [TestCase(398, "common", 7.96)]
        [TestCase(501, "common", 10.02)]
        [TestCase(57, "common", 1.14)]
        [TestCase(1800, "luxury", 72.00)]
        [TestCase(1100, "common", 22.00)]
        [TestCase(1000000, "luxury", 40000.00)]
        public void TestSpecialFee_ExcpectedResultWhenParamsOkay(decimal value, string type, decimal expectedResult)
        {
            //Act
            decimal? result = _feesService?.CalculateSpecialFee(value, type);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}

