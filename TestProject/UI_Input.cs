using Code_Submission_Gerald_A_Wakefield.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UI_Input
    {

        [TestMethod]
        public void ReadInt_WithValidString_ReturnsAnInt()
        {
            //Arrange
            var service = new InputService();
            var validNum = "7";

            //Act
            var result = service.ReadInt(validNum);

            //Assert
            result.Should().BeOfType(typeof(int), "because the valid inputs prompted to the user will be positive whole-number integers");
        }

        [TestMethod]
        public void ReadInt_WithValidStringValue7_ReturnsIntValue7()
        {
            //Arrange
            var service = new InputService();
            var validNum = "7";

            //Act
            var result = service.ReadInt(validNum);

            //Assert
            result.Should().Be(7, "because the console reads in user input as a string that must be converted to an integer");
        }

        [TestMethod]
        public void ReadInt_WithNegativeString_ReturnsArgumentException()
        {
            //Arrange
            var service = new InputService();
            var invalidNum = "-1";

            //Act
            Action action = () => service.ReadInt(invalidNum);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage("Please provide a Numeric Value greater than Zero");
        }

        [TestMethod]
        public void ReadInt_WithInvalidCharString_ReturnsArgumentException()
        {
            //Arrange
            var service = new InputService();
            var invalidString = "Hello";

            //Act
            Action action = () => service.ReadInt(invalidString);

            //Assert
            action.Should().Throw<ArgumentException>().WithMessage("Please Provide Only One Numeric Value");
        }

        [TestMethod]
        public void ReadInt_WithMultipleInts_ReturnsArgumentException()
        {
            //Arrange
            var service = new InputService();
            var invalidInts = "1 2 3";

            //Act
            Action action = () => service.ReadInt(invalidInts);

            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [TestMethod]
        public void ReadInt_WithEmptyString_ReturnsArgumentNullException()
        {
            //Arrange
            var service = new InputService();
            var emptyString = String.Empty;

            //Act
            Action action = () => service.ReadInt(emptyString);

            //Assert
            action.Should().Throw<ArgumentNullException>();
        }
    }
}
