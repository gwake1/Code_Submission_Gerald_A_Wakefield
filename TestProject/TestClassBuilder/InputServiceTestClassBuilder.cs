using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Contracts;
using Code_Submission_Gerald_A_Wakefield.Services;
using Telerik.JustMock;

namespace TestProject.TestClassBuilder
{
    public class InputServiceTestClassBuilder
    {
        IInputService _inputService = Mock.Create<IInputService>();
        IUtil _util = Mock.Create<IUtil>();

        public InputServiceTestClassBuilder()
        {
            Bootstrapper.Init();
            _util = ServiceInjector.Retrieve<IUtil>();
        }

        public InputServiceTestClassBuilder WithInputService(IInputService inputService)
        {
            _inputService = inputService;
            return this;
        }

        public InputServiceTestClassBuilder WithUtil(IUtil util)
        {
            _util = util;
            return this;
        }

        public InputService Build()
        {
            return new InputService(_util);
        }
    }
}
