using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Interface;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using TestProject.TestClassBuilder;

namespace TestProject.Model
{
    [TestClass]
    public class FactorModelTest
    {
        private static IUtil _Default_Util;
        [ClassInitialize]
        public static void ClasssInitializer(TestContext context)
        {
            BootStrapper.Init();
            _Default_Util = ServiceInjector.Retrieve<IUtil>();
        }

        [TestMethod]
        public void FactorModel_WithValidValue_ReturnValueGreaterThanZero()
        {
            //Arrange
            var value = 3;
            var sum = 166833;

            //Act
            var factor = new FactorModelClassBuilder().Build(value, sum);

            //Assert
            factor.Value.Should().BeGreaterThan(0, "because the valid values for Factor.Value are between Zero and Config Max Value - 1");
        }

        [TestMethod]
        public void FactorModel_WithValidValue_ReturnValueLessThanConfigMax()
        {
            //Arrange
            var value = 3;
            var sum = 166833;

            //Act
            var factor = new FactorModelClassBuilder().Build(value, sum);

            //Assert
            factor.Value.Should().BeLessThan(_Default_Util.MaxValue, "because the valid values for Factor.Value are between Zero and Config Max Value - 1");
        }

        [TestMethod]
        public void FactorModel_WithInputValue499_ReturnsSumOf998()
        {
            //Arrange
            var value = 499;
            var sum = 499;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;

            var util = Mock.CreateLike<IUtil>(mV => mV.MaxValue == maxValue);

            //Act
            var factor = new FactorModelClassBuilder().WithUtil(util).Build(value, sum);

            //Assert
            factor.Sum.Should().BeGreaterOrEqualTo(minSum, "because the Sum value is 998 with a Max Value of 1000 for Input of 499");
        }
    }
}
