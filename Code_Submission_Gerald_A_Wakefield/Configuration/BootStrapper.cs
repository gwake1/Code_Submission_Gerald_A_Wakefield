using Code_Submission_Gerald_A_Wakefield.Common;
using Code_Submission_Gerald_A_Wakefield.Contracts;
using Code_Submission_Gerald_A_Wakefield.Services;

namespace Code_Submission_Gerald_A_Wakefield.Configuration
{
    public static class Bootstrapper
    {
        public static void Init()
        {
            ServiceInjector.Register<IUtil, Util>();
            ServiceInjector.Register<IInputService, InputService>();
            ServiceInjector.Register<IFactorService, FactorService>();
        }
    }
}
