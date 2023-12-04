using System;
using TOTAL_CAR_FEES.DOMAIN.Services;

namespace TOTAL_CAR_FEES.DOMAIN.TEST.Fees
{
	[TestFixture]
	public partial class FeesServiceTest
	{

        private FeesService? _feesService;

        [SetUp]
        public void SetUp()
        {
            _feesService = new FeesService();
        }

        [Test]
        [TestCase("luxuri")]
        [TestCase("comon")]
        [TestCase("luxry")]
        [TestCase("luxuri")]
        public void TestBasciFee_ArgumentExceptionWhenNoValidVehicleType(string type)
        {
            Assert.That(() => _feesService?.CalculateBasicFee(50,type), Throws.ArgumentException);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-0.01)]
        [TestCase(-5)]
        public void TestBasicFee_ArgumentExceptionWhenValueEqualOrLessThanZero(decimal value)
        {
            Assert.That(() => _feesService?.CalculateBasicFee(value, "luxury"), Throws.ArgumentException);
        }

        [Test]
        public void TestBasicFee_ReturnTenWhenFeeCalculationIsLessThanTenForCommon()
        {
            //arrange
            decimal value = 99.999m;
            string type = "Common";
            decimal expectedResult = 10;

            //Act
            decimal? result = _feesService?.CalculateBasicFee(value, type);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestBasicFee_ReturnTwentyFiveWhenFeeCalculationIsLessThanTwentyFiveForLuxury()
        {
            //arrange
            decimal value = 249.999m;
            string type = "Luxury";
            decimal expectedResult = 25;

            //Act
            decimal? result = _feesService?.CalculateBasicFee(value, type);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestBasicFee_ReturnFiftyWhenFeeCalculationIsMoreThanFiftyForCommon()
        {
            //arrange
            decimal value = 500.01m;
            string type = "Common";
            decimal expectedResult = 50;

            //Act
            decimal? result = _feesService?.CalculateBasicFee(value, type);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestBasicFee_ReturnTwoHundreFiveWhenFeeCalculationIsLessThanTwoHundreForLuxury()
        {
            //arrange
            decimal value = 2000.01m;
            string type = "Luxury";
            decimal expectedResult = 200;

            //Act
            decimal? result = _feesService?.CalculateBasicFee(value, type);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(398,"common",39.80)]
        [TestCase(501,"common",50)]
        [TestCase(57,"common",10)]
        [TestCase(1800,"luxury",180)]
        [TestCase(1100,"common",50)]
        [TestCase(1000000,"luxury",200)]
        public void TestBasicFee_ExcpectedResultWhenParamsOkay(decimal value, string type, decimal expectedResult)
        {
            //Act
            decimal? result = _feesService?.CalculateBasicFee(value, type);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}

