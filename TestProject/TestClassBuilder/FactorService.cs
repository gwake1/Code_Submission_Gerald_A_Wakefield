using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Interface;
using Code_Submission_Gerald_A_Wakefield.Services;
using Telerik.JustMock;

namespace TestProject.TestClassBuilder
{
    public class FactorServiceTestClassBuilder
    {
        IUtil _util = Mock.Create<IUtil>();

        public FactorServiceTestClassBuilder()
        {
            BootStrapper.Init();
            _util = ServiceInjector.Retrieve<IUtil>();
        }

        public FactorServiceTestClassBuilder WithUtil(IUtil util)
        {
            _util = util;
            return this;
        }

        public FactorService Build()
        {
            return new FactorService(_util);
        }

    }
}
