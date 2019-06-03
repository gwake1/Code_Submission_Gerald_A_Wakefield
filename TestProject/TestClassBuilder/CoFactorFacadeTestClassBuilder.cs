using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Facade;
using Code_Submission_Gerald_A_Wakefield.Interface;

namespace TestProject.TestClassBuilder
{
    public class CoFactorFacadeTestClassBuilder
    {
        private IInputService _inputService;
        private IFactorService _factorService;

        public CoFactorFacadeTestClassBuilder()
        {
            BootStrapper.Init();
            _inputService = ServiceInjector.Retrieve<IInputService>();
            _factorService = ServiceInjector.Retrieve<IFactorService>();
        }

        public CoFactorFacadeTestClassBuilder WithInputService(IInputService inputService)
        {
            _inputService = inputService;
            return this;
        }

        public CoFactorFacadeTestClassBuilder WithFactorService(IFactorService factorService)
        {
            _factorService = factorService;
            return this;
        }

        public CoFactorFacade Build()
        {
            return new CoFactorFacade(_inputService, _factorService);
        }
    }
}
