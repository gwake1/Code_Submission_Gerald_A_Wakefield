using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Interface;
using Code_Submission_Gerald_A_Wakefield.Model;
using Telerik.JustMock;

namespace TestProject.TestClassBuilder
{
    public class FactorModelClassBuilder
    {
        IUtil _util = Mock.Create<IUtil>();

        public FactorModelClassBuilder()
        {
            BootStrapper.Init();
            _util = ServiceInjector.Retrieve<IUtil>();
        }

        public FactorModelClassBuilder WithUtil(IUtil util)
        {
            _util = util;
            return this;
        }

        public Factor Build(int value, int sum)
        {
            return new Factor(_util, value, sum);
        }
    }
}
