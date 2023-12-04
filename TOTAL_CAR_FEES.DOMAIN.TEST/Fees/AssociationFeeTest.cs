using System;
namespace TOTAL_CAR_FEES.DOMAIN.TEST.Fees
{
    public partial class FeesServiceTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(-0.01)]
        [TestCase(-5)]
        public void TestAssociationFee_ArgumentExceptionWhenValueEqualOrLessThanZero(decimal value)
        {
            Assert.That(() => _feesService?.CalculateAssociationFee(value), Throws.ArgumentException);
        }

        [Test]
        [TestCase(398, 5.00)]
        [TestCase(501,  10.00)]
        [TestCase(57, 5.00)]
        [TestCase(1800, 15.00)]
        [TestCase(1100, 15.00)]
        [TestCase(1000000, 20.00)]
        public void TestAssociationFee_ExcpectedResultWhenParamsOkay(decimal value, decimal expectedResult)
        {
            //Act
            decimal? result = _feesService?.CalculateAssociationFee(value);
            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}

