using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.TestClassBuilder;

namespace TestProject.Facade
{
    [TestClass]
    public class CoFactorFacade
    {
        [TestMethod]
        public void CoFactorFacade_InitialCondition_ExpectedResult()
        {
            //Arrange
            var facade = new CoFactorFacadeTestClassBuilder().Build();
            facade.Load("3");
            facade.Load("5");
            var expected = 233168;

            //Act
            var result = facade.Calculate();

            //Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        public void CoFactorFacade_InvalidLoadAttempts_ReturnsInvalidOperationException()
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
