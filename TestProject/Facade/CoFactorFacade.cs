using Code_Submission_Gerald_A_Wakefield.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using TestProject.TestClassBuilder;

namespace TestProject.Facade
{
    [TestClass]
    public class CoFactorFacade
    {
        [TestMethod]
        public void CoFactorFacade_WithValues3_5_ANDMaxValue1000_ExpectedResult233168()
        {
            //Arrange
            var expected = 233168;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var facade = new CoFactorFacadeTestClassBuilder().WithUtil(util).Build();
            facade.Load("3");
            facade.Load("5");

            //Act
            var result = facade.Calculate();

            //Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void CoFactorFacade_WithValues3_5_ANDMaxValue10_ExpectedResult23()
        {
            //Arrange
            var expected = 23;
            var maxValue = 10;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var facade = new CoFactorFacadeTestClassBuilder().WithUtil(util).Build();
            facade.Load("3");
            facade.Load("5");

            //Act
            var result = facade.Calculate();

            //Assert
            result.Should().Be(expected);

        }

        [TestMethod]
        public void CoFactorFacade_InvalidLoadAttempts_ReturnsFalse()
        {
            //Arrange
            var facade = new CoFactorFacadeTestClassBuilder().Build();
            facade.Load("3");
            facade.Load("5");

            //Act
            var result = facade.Load("7");

            //Assert
            result.Should().BeFalse();
        }
    }
}
