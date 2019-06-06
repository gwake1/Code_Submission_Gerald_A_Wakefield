using Code_Submission_Gerald_A_Wakefield.Contracts;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using TestProject.TestClassBuilder;

namespace TestProject.Service
{
    [TestClass]
    public class FactorServiceTest
    {
        [TestMethod]
        public void GetGreatestMultiple_WithValidEvenNumber_ReturnsIntGreaterThanZero()
        {
            //Arrange
            var input = 2;
            var expected = 0;
            var service = new FactorServiceTestClassBuilder().Build();

            //Act
            var result = service.GetGreatestMultiple(input);

            //Assert
            result.Should().BeGreaterThan(expected, "because all valid input values should return a GetGreatestMultiple value greater than Zero");
        }

        [TestMethod]
        public void GetGreatestMultiple_WithValidEvenNumber_ReturnsExpectedLessThanConfigMaxValue()
        {
            //Arrange
            var input = 2;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var service = new FactorServiceTestClassBuilder().WithUtil(util).Build();

            //Act
            var result = service.GetGreatestMultiple(input);

            //Assert
            result.Should().BeLessThan(util.MaxValue, "because 2 is evenly divisible into 1000, it should return 998 as the Greatest Multiple");
        }

        [TestMethod]
        public void GetGreatestMultiple_WithValidOddNumber_ReturnsExpectedGreaterThanZero()
        {
            //Arrange
            var input = 5;
            var expected = 0;
            var service = new FactorServiceTestClassBuilder().Build();

            //Act
            var result = service.GetGreatestMultiple(input);

            //Assert
            result.Should().BeGreaterThan(expected, "because valid odd factors should return a positive number less than the default value of 1000");
        }

        [TestMethod]
        public void GetGreatestMultiple_WithValidOddNumber_ReturnsExpectedLessThanConfigMaxValue()
        {
            var input = 5;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var service = new FactorServiceTestClassBuilder().WithUtil(util).Build();

            //Act
            var result = service.GetGreatestMultiple(input);

            //Assert
            result.Should().BeLessThan(util.MaxValue, "because an odd number has remained that must be removed when finding the factor's greatest multiple");
        }

        [TestMethod]
        public void GetSum_WithValidNumber_ReturnGreaterThanMinSum()
        {
            //Arrange
            var input = 3;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var service = new FactorServiceTestClassBuilder().WithUtil(util).Build();

            //Act
            var result = service.GetSum(input);

            //Assert
            result.Should().BeGreaterThan(util.MinSum, "because the sum should be greater than (Max Value / 2) - 1");
        }

        [TestMethod]
        public void GetSum_WithValidValueof3_Returns166833()
        {
            //Arrange
            var input = 3;
            var expected = 166833;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var service = new FactorServiceTestClassBuilder().WithUtil(util).Build();

            //Act
            var result = service.GetSum(input);

            //Assert
            result.Should().Be(expected, "because the valid value of 3's sum sum to the default value of 1000 should be 166833");
        }

        [TestMethod]
        public void GetSum_WithValidalueof5_Returns99500()
        {
            //Arrange
            var input = 5;
            var expected = 99500;
            var maxValue = 1000;
            var minSum = (maxValue / 2) - 1;
            var util = Mock.CreateLike<IUtil>(config => config.MaxValue == maxValue && config.MaxInputValue == maxValue - 1 && config.MinSum == minSum);
            var service = new FactorServiceTestClassBuilder().WithUtil(util).Build();

            //Act
            var result = service.GetSum(input);

            //Assert
            result.Should().Be(expected, "because the valid value of 5's sum sum to the default value of 1000 should be 99500");
        }
    }
}
