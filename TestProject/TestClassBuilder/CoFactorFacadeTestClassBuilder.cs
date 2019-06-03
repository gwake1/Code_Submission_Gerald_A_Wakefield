using Code_Submission_Gerald_A_Wakefield.Configuration;
using Code_Submission_Gerald_A_Wakefield.Facade;
using Code_Submission_Gerald_A_Wakefield.Interface;

namespace TestProject.TestClassBuilder
{
    public class CoFactorFacadeTestClassBuilder
    {
        private IUtil _util;
        private IInputService _inputService;
        private IFactorService _factorService;

        public CoFactorFacadeTestClassBuilder()
        {
            BootStrapper.Init();
            _util = ServiceInjector.Retrieve<IUtil>();
            _inputService = ServiceInjector.Retrieve<IInputService>();
            _factorService = ServiceInjector.Retrieve<IFactorService>();
        }

        public CoFactorFacadeTestClassBuilder WithUtil(IUtil util)
        {
            _util = util;
            return this;
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
            return new CoFactorFacade(_util, _inputService, _factorService);
        }
    }
}
